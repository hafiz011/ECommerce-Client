using Ecommerce.Client.Models;

namespace Ecommerce.Client.Services
{
    public class CartService
    {
        private readonly List<ProductDto> _items = new();

        public IReadOnlyList<ProductDto> Items => _items;

        public Task AddAsync(ProductDto p)
        {
            _items.Add(p);
            return Task.CompletedTask;
        }

        public int Count() => _items.Count;
    }
}
