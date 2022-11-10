using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApiClients.Entities;
using WebApiClients.Infra.Data;
using WebApiClients.Model;

namespace WebApiClients.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Users.Response>), 200)]
        public async Task<ActionResult<IEnumerable<Users.Response>>> GetAllUsers()
        {
            var response = await _context.Clientes.ToListAsync();

            foreach (var user in response)
            {
                await _context.Enderecos.FindAsync(user.Id);
            };

            return Ok(response);
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(Users.Response), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Users.Response>> CreateUser([FromBody] Users.Request user)
        {
            var exists = await _context.Clientes.FirstOrDefaultAsync(x => x.Nome.Equals(user.Nome));
            if (exists != null)
            {
                return BadRequest("Usuario já existente!");
            }

            _context.Clientes.Add(ConvertData(user));
            await _context.SaveChangesAsync();

            var response = await _context.Clientes.FirstOrDefaultAsync(x => x.Nome.Equals(user.Nome));

            return Ok(response);
        }

        [HttpPut("change")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Users.Response>> AddAddressToUser([Required][FromQuery] int userId, [FromBody] Users.Request user)
        {
            var exists = await _context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (exists is null)
            {
                return BadRequest("Usuario não existente!");
            }

            exists = ConvertData(user);
            exists.Id = userId;

            _context.Entry(exists).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var response = await _context.Clientes.FindAsync(userId);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> DeleteUser([FromQuery] int userId)
        {
            var exists = await _context.Clientes.FindAsync(userId);
            if (exists is null) 
            { 
                return BadRequest("Usuário inexistente!");
            }

            _context.Remove(exists);
            await _context.SaveChangesAsync();

            return Accepted();
        }

        private ClientModel ConvertData(Users.Request user)
        {
            List<AddressModel> addressModel = new List<AddressModel>();
            var address = new AddressModel
            {
                Cep = user.Endereco.Cep,
                Logradouro = user.Endereco.Logradouro,
                Uf = user.Endereco.Uf,
                Bairro = user.Endereco.Bairro,
                Cidade = user.Endereco.Cidade,
                Status = user.Endereco.Status
            };

            addressModel.Add(address);
            var userModel = new ClientModel
            {
                Nome = user.Nome,
                DataNascimento = user.DataNascimento,
                Status = user.Status,
                Endereco = addressModel
            };

            return userModel;
        }
    }
}