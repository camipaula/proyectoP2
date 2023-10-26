using System.ComponentModel.DataAnnotations;

namespace APIPROYECTO1.Models
{
    public class Promocion
    {
        [Key]
        public int IdPromocion { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public string Marca { get; set; }

        public int Cantidad { get; set; }

        public float Precio { get; set; }
    }
}
