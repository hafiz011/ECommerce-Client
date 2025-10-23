using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Client.Models
{
    public class CategoryDto
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        public string? Name { get; set; }
        public string? ImgUrlPath { get; set; }  // image URL from API
        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
