using System.ComponentModel.DataAnnotations;

namespace WebApiClients.Entities
{
    public class Address
    {
        public class Request 
        {
            [Required]
            public int IdCliente { get; set; }
            [Required]
            [MaxLength(100)]
            public string Logradouro { get; set; }
            [Required]
            [MaxLength(8)]
            public string Cep { get; set; }
            [Required]
            [MaxLength(2)]
            public string Uf { get; set; }
            [Required]
            [MaxLength(100)]
            public string Cidade { get; set; }
            [Required]
            [MaxLength(60)]
            public string Bairro { get; set; }
            public EAdressStatus Status { get; set; }
        }

        public class Response
        {
            public int IdCliente { get; set; }
            public string Logradouro { get; set; }
            public string Cep { get; set; }
            public string Uf { get; set; }
            public string Cidade { get; set; }
            public string Bairro { get; set; }
            public int Id { get; set; }
            public DateTime DataInclusao { get; set; }
            public EAdressStatus Status { get; set; }
        }

        public enum EAdressStatus
        {
            Inativo, //0
            Ativo    //1
        }
    }
}