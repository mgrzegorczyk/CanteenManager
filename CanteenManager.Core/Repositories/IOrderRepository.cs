using System.Collections.Generic;
using System.Threading.Tasks;
using CanteenManager.Core.Models;

namespace CanteenManager.Core.Repositories
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task RemoveAsync(int orderId);
        Task<Order> GetAsync(int orderId);
        Task<IEnumerable<Order>> GetAllAsync();
    }
}