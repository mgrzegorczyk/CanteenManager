using System;

namespace CanteenManager.Infrastructure.DTO
{
    public class OrderDto
    {
        public int Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public string Description { get; protected set; }
    }
}