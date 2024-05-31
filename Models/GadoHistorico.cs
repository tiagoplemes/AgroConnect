using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroConnect.Models
{
    public class GadoHistorico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Saude { get; set; }

        public string Reproducao { get; set; }

        public string Vacina { get; set; }
    }
}
