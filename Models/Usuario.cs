using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroConnect.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public List<Gado> Gados { get; set; }
        public List<Plantacao> Plantacoes { get; set; }
        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public string Cidade { get; set; }

        public string Telefone { get; set; }

        public string Cpf { get; set; }
    }
}
