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
    }
}
