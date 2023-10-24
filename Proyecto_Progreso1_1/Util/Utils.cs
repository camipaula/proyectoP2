using Proyecto_Progreso1_1.Models;
namespace Proyecto_Progreso1_1.Util
{
    public class Utils
    {
        public static List<Prenda> ListaPrenda = new List<Prenda>()
        {
            new Prenda()
            {
                IdPrenda = 1,
                Nombre = "prenda1",
                Descripcion = "Pantalon",
                Marca= "zara",
                Cantidad=2
                
            },
            new Prenda()
            {
                IdPrenda = 2,
                Nombre = "prenda2",
                Descripcion = "falda",
                Marca= "zara",
                Cantidad=3

            }

        };
    }
}
 