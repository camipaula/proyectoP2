using System.ComponentModel.DataAnnotations;

namespace APIPROYECTO1.Models
{
    public class PrendaUsuario
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public int MarcaIdMarca { get; set; }
        [Required]
        public int CategoriaIdCategoria { get; set; }
        [Required]

        public int Cantidad { get; set; }
        [Required]

        public float Precio { get; set; }
    }
}
