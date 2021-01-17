using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CanteenManager.Core.Models;
using CanteenManager.Core.Repositories;
using CanteenManager.Infrastructure.DTO;

namespace CanteenManager.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderService(
            IOrderRepository orderRepository,
            IMapper mapper
        )
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(OrderDto orderDto)
        {
            var order = mapper.Map<OrderDto, Order>(orderDto);

            await orderRepository.AddAsync(order);
        }

        public async Task DeleteAsync(int orderId)
        {
            await orderRepository.RemoveAsync(orderId);
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await orderRepository.GetAllAsync();

            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetAsync(int orderId)
        {
            var order = await orderRepository.GetAsync(orderId);

            return mapper.Map<Order, OrderDto>(order);
        }
    }
}