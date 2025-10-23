namespace Ecommerce.Client.Models
{
    public class ProductDto
    {
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
        public decimal Price { get; set; }
        public List<string> Images { get; set; } = new();
        public List<string> Tags { get; set; } = new();
        public int StockQuantity { get; set; }
        public List<DiscountDto> Discounts { get; set; } = new();
        public string? SellerId { get; set; }
        public bool IsNew { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Dictionary<string, string> Attributes { get; set; } = new();
    }

    public class DiscountDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Code { get; set; } = string.Empty;
        public decimal Percentage { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsActive { get; set; } = true;
        public string? ProductId { get; set; }
    }
}
