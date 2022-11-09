using System.ComponentModel.DataAnnotations;

namespace WebApiClients.Entities
{
    public class Users
    {
        public class Request
        {
            [Required]
            [MaxLength(200)]
            public string Nome { get; set; }
            [Required]
            public DateTime DataNascimento { get; set; }
            public Address.Request Endereco { get; set; }
            public EUserStatus Status { get; set; }
        }

        public class Response { 
            public int Id { get; set; }
            public string Nome { get; set; }
            public DateTime DataNascimento { get; set; }
            public DateTime DataInclusao { get; set; }
            public EUserStatus Status { get; set; }
            public IEnumerable<Address.Response> Endereco { get; set; }
        }

        public enum EUserStatus
        {
            Ativo, //0
            Inativo, // 1
        }
    }
}