using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroConnect.Models
{
    public class Gado
    {
        public Gado() { }
        public Gado(GadoHistorico historico)
        {
            Historico = historico;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Raca { get; set; }

        public double Peso { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int HistoricoId { get; set; }
        public GadoHistorico? Historico { get; set; }
    }
}
