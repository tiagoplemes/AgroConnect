using System.ComponentModel.DataAnnotations;

namespace AgroConnect.Models
{
    public class Usuario
    {
        [Key]
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Cpf { get; set; }
    }
}
