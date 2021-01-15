using System;

namespace CanteenManager.Core.Models
{
    public class Product
    {
        public string Name { get; protected set; }

        protected Product() { }
        public Product(string name)
        {
            Name = name;
        }

        public void SetProductName(string name)
        {
            if (Name == name)
            {
                return;
            }

            Name = name;
        }
    }
}