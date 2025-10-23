using Ecommerce.Client.Models;
using System.Net.Http.Json;

namespace Ecommerce.Client.Services
{
    public class ProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _http.GetFromJsonAsync<List<ProductDto>>("Product");
            return products ?? new List<ProductDto>();
        }

        public async Task<ProductDto?> GetByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<ProductDto>($"Product/{id}");
        }

        public async Task<bool> CreateAsync(ProductDto product)
        {
            var response = await _http.PostAsJsonAsync("Product", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(string id, ProductDto product)
        {
            var response = await _http.PutAsJsonAsync($"Product/{id}", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _http.DeleteAsync($"Product/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
