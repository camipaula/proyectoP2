namespace Proyecto_Progreso1_1.Models
{
    public class PrendaUsuario
    {
        public int idPrenda { get; set; }

        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int marcaIdMarca { get; set; }
        public int categoriaIdCategoria { get; set; }
        public int cantidad { get; set; }

        public float precio { get; set; }
    }
}
