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
    }
}