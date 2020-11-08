using System;

namespace CanteenManager.Core.Models
{
    public class Product
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        protected Product() { }
        public Product(string name)
        {
            Id = new Random().Next();
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