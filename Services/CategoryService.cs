using Ecommerce.Client.Models;
using Microsoft.AspNetCore.Components.Forms;
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

        //  Get all categories
        public async Task<List<CategoryDto>> AllCategory()
        {
            var categories = await _http.GetFromJsonAsync<List<CategoryDto>>("Category/allcategories");
            return categories ?? new List<CategoryDto>();
        }

        //  Get category by ID
        public async Task<CategoryDto?> GetById(string id)
        {
            return await _http.GetFromJsonAsync<CategoryDto>($"Category/{id}");
        }

        //  Add new category with image upload
        public async Task<CategoryDto?> AddCategory(string name, string description, IBrowserFile file)
        {
            var content = new MultipartFormDataContent();
            if (!string.IsNullOrEmpty(name))
                content.Add(new StringContent(name), "Name");
            if (!string.IsNullOrEmpty(description))
                content.Add(new StringContent(description), "Description");
            if (file != null)
                content.Add(new StreamContent(file.OpenReadStream(524288)), "ImgUrl", file.Name);

            var response = await _http.PostAsync("Category", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                // Log or handle errorContent for debugging
                return null;
            }

            return await response.Content.ReadFromJsonAsync<CategoryDto>();
        }

        // Update category with optional image upload
        public async Task<CategoryDto?> UpdateCategory(string id, string name, string description, IBrowserFile? file = null)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(id), "Id");
            if (!string.IsNullOrEmpty(name))
                content.Add(new StringContent(name), "Name");
            if (!string.IsNullOrEmpty(description))
                content.Add(new StringContent(description), "Description");
            if (file != null)
                content.Add(new StreamContent(file.OpenReadStream(524288)), "ImgUrl", file.Name);

            var response = await _http.PutAsync($"Category/{id}", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                // Log or handle errorContent for debugging
                return null;
            }

            return await response.Content.ReadFromJsonAsync<CategoryDto>();
        }

        // Delete category by ID
        public async Task<bool> DeleteCategory(string id)
        {
            var response = await _http.DeleteAsync($"Category/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}