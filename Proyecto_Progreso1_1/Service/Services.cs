using Proyecto_Progreso1_1.Models;
using System.Text.Json;

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



        ///////////////////////////ACCESORIO///////////////////////////////////////
        // Realiza una solicitud HTTP para obtener la lista de accesorios
        public async Task<List<Accesorio>> GetAllAccesorios()

        {

            var response = await _httpClient.GetFromJsonAsync<List<Accesorio>>("api/Accesorio");

            Console.WriteLine(JsonSerializer.Serialize(response));

            return response;
        }

        public async Task<Accesorio> GetAccesorio(int IdAccesorio)
        {
            // Obtiene 1 solo accesorio por su Id
            var response = await _httpClient.GetFromJsonAsync<Accesorio>($"api/Accesorio/{IdAccesorio}");
            return response;
        }

        // Realiza una solicitud HTTP POST para crear un accesorio

        public async Task<Accesorio> CreateAccesorio(Accesorio accesorio)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Accesorio", accesorio);
            return await response.Content.ReadFromJsonAsync<Accesorio>();
        }

        public async Task<Accesorio> UpdateAccesorio(int IdAccesorio, Accesorio accesorio)
        {
            // Realiza una solicitud HTTP PUT para modificar un accesorio
            var response = await _httpClient.PutAsJsonAsync($"api/Accesorio/{IdAccesorio}", accesorio);
            return await response.Content.ReadFromJsonAsync<Accesorio>();
        }

        // Realiza una solicitud HTTP para eliminar un accesorio

        public async void DeleteAccesorio(int IdAccesorio)
        {
            _httpClient.DeleteAsync($"api/Accesorio/{IdAccesorio}");
        }

        ///////////////////////////PROMOCIONES///////////////////////////////////////
        // Realiza una solicitud HTTP para obtener la lista de accesorios
        public async Task<List<Promocion>> GetAllPromociones()

        {

            var response = await _httpClient.GetFromJsonAsync<List<Promocion>>("api/Promocion");
            return response;
        }

        public async Task<Promocion> GetPromocion(int IdPromocion)
        {
            // Obtiene 1 solo accesorio por su Id
            var response = await _httpClient.GetFromJsonAsync<Promocion>($"api/Promocion/{IdPromocion}");
            return response;
        }

        // Realiza una solicitud HTTP POST para crear un accesorio

        public async Task<Promocion> CreatePromocion(Promocion promocion)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Promocion", promocion);
            return await response.Content.ReadFromJsonAsync<Promocion>();
        }

        public async Task<Promocion> UpdatePromocion(int IdPromocion, Promocion promocion)
        {
            // Realiza una solicitud HTTP PUT para modificar un accesorio
            var response = await _httpClient.PutAsJsonAsync($"api/Promocion/ {IdPromocion}", promocion);
            return await response.Content.ReadFromJsonAsync<Promocion>();
        }

        // Realiza una solicitud HTTP para eliminar un accesorio

        public async void DeletePromocion(int IdPromocion)
        {
            _httpClient.DeleteAsync($"api/Promocion/{IdPromocion}");
        }

    }
}
