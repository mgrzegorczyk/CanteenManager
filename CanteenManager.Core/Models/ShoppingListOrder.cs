namespace CanteenManager.Core.Models
{
    public class ShoppingListOrder
    {
        public Order Order { get; protected set; }
        public ShoppingList ShoppingList { get; protected set; }

        protected ShoppingListOrder() { }

        public ShoppingListOrder(ShoppingList shoppingList, Order order)
        {
            Order = order;
            ShoppingList = shoppingList;
        }
    }
}