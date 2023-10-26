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
                Cantidad=2,
                Precio=40
                
            },
            new Prenda()
            {
                IdPrenda = 2,
                Nombre = "prenda2",
                Descripcion = "falda",
                Marca= "zara",
                Cantidad=3,
                Precio=20
            }

        };

        public static List<Accesorio> ListaAccesorio = new List<Accesorio>()
        {
            new Accesorio()
            {
                IdAccesorio = 1,
                Nombre = "Collar",
                Descripcion = "Collar blanco de plata",
                Marca= "cartier",
                Cantidad=2,
                Precio=11

            },
            new Accesorio()
            {
                IdAccesorio = 2,
                Nombre = "Aretes",
                Descripcion = "Aretes largos",
                Marca= "buccellati",
                Cantidad=3,
                Precio=20
            }

        };


        public static List<Promocion> ListaPromocion = new List<Promocion>()
        {
            new Promocion()
            {
                IdPromocion = 1,
                Nombre = "Promocion 1",
                Descripcion = "Blusa azul",
                Marca= "shein",
                Cantidad=2,
                Precio=13

            },
            new Promocion()
            {
                IdPromocion = 2,
                Nombre = "Promocion 2",
                Descripcion = "Aretes largos",
                Marca= "shein",
                Cantidad=3,
                Precio=15
            }

        };


    }
}
 