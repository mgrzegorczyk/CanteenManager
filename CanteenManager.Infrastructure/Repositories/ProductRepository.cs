using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanteenManager.Core.Models;
using CanteenManager.Core.Repositories;

namespace CanteenManager.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static ISet<Product> _products = new HashSet<Product>()
        {
            new Product("TestProduct"),
        };

        public async Task AddAsync(Product product)
        {
            await Task.FromResult(_products.Add(product));
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product> GetAsync(string name)
        {
            return await Task.FromResult(_products.SingleOrDefault(product => product.Name == name));
        }

        public async Task RemoveAsync(string name)
        {
            var product = await GetAsync(name);
            _products.Remove(product);
            await Task.CompletedTask;
        }
    }
}