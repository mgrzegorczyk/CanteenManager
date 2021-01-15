using System.Collections.Generic;
using System.Threading.Tasks;
using CanteenManager.Infrastructure.DTO;

namespace CanteenManager.Infrastructure.Services
{
    public interface IProductService : IService
    {
        Task AddAsync(string name);
        Task DeleteAsync(string name);
        Task<ProductDto> GetAsync(string name);
        Task<IEnumerable<ProductDto>> GetAllAsync();
    }
}