using System.ComponentModel.DataAnnotations;

namespace APIPROYECTO1.Models
{
    public class Prenda
    {
        [Key]
        public int IdPrenda { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]

        public int Cantidad { get; set; }
        [Required]

        public float Precio { get; set; }

        public int CategoriaIdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }

        public int MarcaIdMarca { get; set; }
        public virtual Marca Marca { get; set; }



    }
}
