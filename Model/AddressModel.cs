using static WebApiClients.Entities.Address;
using System.ComponentModel.DataAnnotations;

namespace WebApiClients.Model
{
    public class AddressModel
    {
        public int IdCliente { get; set; }
        [MaxLength(100)]
        public string Logradouro { get; set; }
        [MaxLength(8)]
        public string Cep { get; set; }
        [MaxLength(2)]
        public string Uf { get; set; }
        [MaxLength(100)]
        public string Cidade { get; set; }
        [MaxLength(60)]
        public string Bairro { get; set; }
        public int Id { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.UtcNow;
        public EAdressStatus Status { get; set; }
        public ClientModel Usuario { get; set; }
    }
}
