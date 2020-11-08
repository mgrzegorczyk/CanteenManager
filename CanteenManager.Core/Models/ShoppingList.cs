using System;
using System.Collections.Generic;

namespace CanteenManager.Core.Models
{
    public class ShoppingList
    {
        public int Id { get; protected set; }
        public int Month { get; protected set; }
        public int Year { get; protected set; }
        public IEnumerable<ShoppingListOrder> ShoppingListOrders { get; protected set; }

        protected ShoppingList() { }

        public ShoppingList(int month, int year)
        {
            Id = new Random().Next();
            Month = month;
            Year = year;
        }

        public void SetMonth(int monthNumber) 
        {
            if(Month == monthNumber)
            {
                return;
            }

            if(monthNumber < 1 || monthNumber > 12)
            {
                throw new Exception($"{monthNumber} is not a month number!");
            }

            Month = monthNumber;
        }
        public void SetYear(int year) 
        {
            if(Year == year)
            {
                return;
            }

            if(year < 1)
            {
                throw new Exception($"{year} is not A.D. year!");
            }

            Year = year;
        }
        public void SetOrders(IEnumerable<ShoppingListOrder> shoppingListOrders)
        {
            ShoppingListOrders = shoppingListOrders;
        }
    }
}