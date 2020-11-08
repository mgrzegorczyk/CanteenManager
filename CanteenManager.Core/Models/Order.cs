using System;
using System.Collections.Generic;

namespace CanteenManager.Core.Models
{
    public class Order
    {
        public int Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public string Description { get; protected set; }
        public IEnumerable<OrderProduct> OrderProducts { get; protected set; }

        protected Order() { }

        public Order(Guid userId, string description)
        {
            Id = new Random().Next();
            UserId = userId;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetDescription(string description)
        {
            if (Description == description)
            {
                return;
            }

            Description = description;
        }

        public void SetProducts(IEnumerable<OrderProduct> orderProducts)
        {
            OrderProducts = orderProducts;
        }
    }
}