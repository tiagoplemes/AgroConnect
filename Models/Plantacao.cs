using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroConnect.Models
{
    public class Plantacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
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
