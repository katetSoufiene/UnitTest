using System;

namespace ProductLibrary
{
    public class Product
    {
        private bool _frozen = false;
        public string Name { get; }
        public int Quantity { get; private set; }

        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public void Increase(int quantity)
        {
            if (_frozen)
            {
                throw new Exception("Product frozen");
            }

            if (quantity < 0 || quantity >= int.MaxValue - Quantity)
            {
                throw new ArgumentOutOfRangeException("quantity");
            }

            Quantity += quantity;
        }

        public void Decrease(int quantity)
        {
            if (_frozen)
            {
                throw new Exception("Product frozen");
            }

            if (quantity > Quantity)
            {
                throw new ArgumentOutOfRangeException("quantity");
            }

            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("quantity");
            }

            Quantity -= quantity; 
        }

    }
}
