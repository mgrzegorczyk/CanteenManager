namespace CanteenManager.Core.Models
{
    public class OrderProduct
    {
        public Order Order { get; protected set; }
        public Product Product { get; protected set; }

        protected OrderProduct() { }

        public OrderProduct(Order order,Product product)
        {
            Order = order;
            Product = product;
        }
    }
}