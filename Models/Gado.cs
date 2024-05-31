using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroConnect.Models
{
    public class Gado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Raca { get; set; }

        public double Peso { get; set; }

        public double Dono { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public GadoHistorico Historico { get; set; }
    }
}
