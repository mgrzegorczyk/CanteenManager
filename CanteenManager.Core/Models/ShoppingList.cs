using System.Collections.Generic;

namespace CanteenManager.Core.Models
{
    public class ShoppingList
    {
        public int Id { get; protected set; }
        public int Month { get; protected set; }
        public int Year { get; protected set; }
        public IEnumerable<ShoppingListOrder> ShoppingListOrders { get; protected set; }
    }
}