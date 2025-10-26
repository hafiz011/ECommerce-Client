namespace Ecommerce.Client.Models
{
    public class ProductDto
    {

        public string? Id { get; set; }
        public string Name { get; set; } = "";
        public string? ShortDescription { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public string? ImageUrl { get; set; }
        public string? HoverImageUrl { get; set; } // optional for hover swap
        public bool IsNew { get; set; }
        public bool IsOnSale { get; set; }
        public double Rating { get; set; } = 0;
    }
}
