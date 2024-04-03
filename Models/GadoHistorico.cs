using System.ComponentModel.DataAnnotations;

namespace AgroConnect.Models
{
    public class GadoHistorico
    {
        [Key]
        public string Id { get; set; }

        public string Saude { get; set; }

        public string Reproducao { get; set; }

        public string Vacina { get; set; }
    }
}
