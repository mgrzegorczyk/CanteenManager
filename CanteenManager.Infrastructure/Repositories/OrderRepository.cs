using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanteenManager.Core.Models;
using CanteenManager.Core.Repositories;

namespace CanteenManager.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static ISet<Order> _orders = new HashSet<Order>()
        {
            new Order(new Guid(),"Test Description"),
        };

        public async Task AddAsync(Order order)
        {
            await Task.FromResult(_orders.Add(order));
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await Task.FromResult(_orders);
        }

        public async Task<Order> GetAsync(int orderId)
        {
            return await Task.FromResult(_orders.SingleOrDefault());
        }

        public async Task RemoveAsync(int orderId)
        {
            var order = await GetAsync(orderId);
            _orders.Remove(order);
            await Task.CompletedTask;
        }
    }
}