using System.ComponentModel.DataAnnotations;
using static WebApiClients.Entities.Users;

namespace WebApiClients.Model
{
    public class ClientModel
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.UtcNow;
        public EUserStatus Status { get; set; }
        public IEnumerable<AddressModel> Endereco { get; set; }
    }
}
