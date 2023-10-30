using System.ComponentModel.DataAnnotations;

namespace APIPROYECTO1.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
