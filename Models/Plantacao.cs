using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgroConnect.Models
{
    public class Plantacao
    {
        [Key]
        public string Id { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Tipo { get; set; }

        public int Quantidade { get; set; }

        [DisplayName("Data Plantio")]
        public DateTime DataPlantio { get; set; }

        [DisplayName("Data Colheita")]
        public DateTime DataColheita { get; set; }
    }
}
