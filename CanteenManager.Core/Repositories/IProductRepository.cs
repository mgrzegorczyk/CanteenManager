using System.Collections.Generic;
using System.Threading.Tasks;
using CanteenManager.Core.Models;

namespace CanteenManager.Core.Repositories
{
    public interface IProductRepository : IRepository
    {
        Task AddAsync(Product product);
        Task RemoveAsync(string name);
        Task<Product> GetAsync(string name);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}