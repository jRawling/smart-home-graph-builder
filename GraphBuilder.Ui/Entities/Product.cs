using System;

namespace GraphBuilder.Ui.Entities
{
    public abstract class Product
    {
        public static string Label = "Product";
        public Guid Id { get; private set; }
        public string Name { get; protected set; }
        public Brand Brand { get; protected set; }

        public double Price { get; protected set; }

        public Product(string name, Brand brand, double price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Brand = brand;
            Price = price;
        }
    }
}