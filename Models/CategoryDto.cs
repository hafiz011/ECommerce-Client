using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Client.Models
{
    public class CategoryDto
    {
        public string? Id { get; set; }  // For update
        public string Name { get; set; }
        public byte[]? ImageData { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; } // For preview
    }


}
