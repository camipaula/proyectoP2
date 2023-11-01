using System.ComponentModel.DataAnnotations;

namespace Proyecto_Progreso1_1.Models
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }

        public int categoriaIdCategoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
