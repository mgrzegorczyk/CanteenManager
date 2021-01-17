using System.Collections.Generic;
using System.Threading.Tasks;
using CanteenManager.Infrastructure.DTO;

namespace CanteenManager.Infrastructure.Services
{
    public interface IOrderService : IService
    {
        Task AddAsync(OrderDto orderDto);
        Task DeleteAsync(int orderId);
        Task<OrderDto> GetAsync(int orderId);
        Task<IEnumerable<OrderDto>> GetAllAsync(); 
    }
}