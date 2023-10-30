using System.ComponentModel.DataAnnotations;

namespace Proyecto_Progreso1_1.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }


    }
}
