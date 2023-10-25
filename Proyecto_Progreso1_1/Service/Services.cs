using Proyecto_Progreso1_1.Models;
namespace Proyecto_Progreso1_1.NewFolder
{
    public class Services : IServices
    {
        //inicializa httpClient
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://localhost:5184";

        public Services()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_url)
            };
        }

        // Realiza una solicitud HTTP para obtener la lista de prendas
        public async Task<List<Prenda>> GetAllPrendas()

        {

            var response = await _httpClient.GetFromJsonAsync<List<Prenda>>("api/Prenda");
            return response;
        }

        public async Task<Prenda> GetPrenda(int IdPrenda)
        {
            // Obtiene 1 solo prendas por su Id
            var response = await _httpClient.GetFromJsonAsync<Prenda>($"api/Prenda/{IdPrenda}");
            return response;
        }

        // Realiza una solicitud HTTP POST para crear una prenda

        public async Task<Prenda> CreatePrenda(Prenda prenda)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Prenda", prenda);
            return await response.Content.ReadFromJsonAsync<Prenda>();
        }

        public async Task<Prenda> UpdatePrenda(int IdPrenda, Prenda prenda)
        {
            // Realiza una solicitud HTTP PUT para modificar una prenda
            var response = await _httpClient.PutAsJsonAsync($"api/Prenda/{IdPrenda}", prenda);
            return await response.Content.ReadFromJsonAsync<Prenda>();
        }

        // Realiza una solicitud HTTP para eliminar una prenda

        public async void DeletePrenda(int IdPrenda)
        {
            _httpClient.DeleteAsync($"api/Prenda/{IdPrenda}");
        }

    }
}
