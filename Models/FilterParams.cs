namespace Ecommerce.Client.Models
{
    public class FilterParams
    {
        public string? Search { get; set; }
        public string? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
