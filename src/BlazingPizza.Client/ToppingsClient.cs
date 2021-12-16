using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingPizza.Client
{
    public class ToppingsClient
    {
        private readonly HttpClient httpClient;

        public ToppingsClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Topping>> GetToppings() =>
            await httpClient.GetFromJsonAsync<IEnumerable<Topping>>("toppings");
        
        public async Task<Topping> GetTopping(int id) =>
            await httpClient.GetFromJsonAsync<Topping>($"toppings/{id}");

        public async Task<bool> PostTopping(Topping topping)
        {
            var response = await httpClient.PostAsJsonAsync("toppings", topping);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> PutTopping(Topping topping)
        {
            var response = await httpClient.PutAsJsonAsync("toppings", topping);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteTopping(int id)
        {
            var response = await httpClient.DeleteAsync($"toppings/{id}");
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
    }
}