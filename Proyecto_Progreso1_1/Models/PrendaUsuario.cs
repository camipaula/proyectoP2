namespace Proyecto_Progreso1_1.Models
{
    public class PrendaUsuario
    {
        public int idPrenda { get; set; }

        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int MarcaIdMarca { get; set; }
        public int CategoriaIdCategoria { get; set; }
        public int cantidad { get; set; }

        public float precio { get; set; }
    }
}
