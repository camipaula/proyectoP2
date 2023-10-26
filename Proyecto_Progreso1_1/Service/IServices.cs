using Proyecto_Progreso1_1.Models;

namespace Proyecto_Progreso1_1.NewFolder
{
    public interface IServices
    {
        Task<List<Prenda>> GetAllPrendas();
        Task<Prenda> GetPrenda(int IdPrenda);
        Task<Prenda> CreatePrenda(Prenda prenda);
        Task<Prenda> UpdatePrenda(int IdPrenda, Prenda prenda);
        void DeletePrenda(int IdPrenda);



        Task<List<Accesorio>> GetAllAccesorios();
        Task<Accesorio> GetAccesorio(int IdAccesorio);
        Task<Accesorio> CreateAccesorio(Accesorio accesorio);
        Task<Accesorio> UpdateAccesorio(int IdAccesorio, Accesorio accesorio);
        void DeleteAccesorio(int IdAccesorio);


        Task<List<Promocion>> GetAllPromociones();
        Task<Promocion> GetPromocion(int IdPromocion);
        Task<Promocion> CreatePromocion(Promocion promocion);
        Task<Promocion> UpdatePromocion(int IdPromocion, Promocion promocion);
        void DeletePromocion(int IdPromocion);
    }
}
