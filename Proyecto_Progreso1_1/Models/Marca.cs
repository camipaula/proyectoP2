using System.ComponentModel.DataAnnotations;

namespace Proyecto_Progreso1_1.Models
{
    public class Marca
    {
        [Key]
        public int idMarca { get; set; }
        public int marcaIdMarca { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }


    }
}
