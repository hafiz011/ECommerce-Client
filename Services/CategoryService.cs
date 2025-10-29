using Ecommerce.Client.Models;
using System.Net.Http.Json;

namespace Ecommerce.Client.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CategoryDto>> AllCategory()
        {
            try
            {
                var res = await _http.GetFromJsonAsync<List<CategoryDto>>("Category/allcategories");
                return res ?? new List<CategoryDto>();
            }
            catch
            {
                return new List<CategoryDto>();
            }
        }



        // Get category by ID
        public async Task<CategoryDto?> GetById(string id)
        {
            return await _http.GetFromJsonAsync<CategoryDto>($"Category/{id}");
        }

        // Add new category
        public async Task<bool> AddCategory(CategoryDto category)
        {
            var response = await _http.PostAsJsonAsync("Category", category);
            return response.IsSuccessStatusCode;
        }

        // Update existing category
        public async Task<bool> UpdateCategory(string id, CategoryDto category)
        {
            var response = await _http.PutAsJsonAsync($"Category/{id}", category);
            return response.IsSuccessStatusCode;
        }

        // Delete category by ID
        public async Task<bool> DeleteCategory(string id)
        {
            var response = await _http.DeleteAsync($"Category/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
