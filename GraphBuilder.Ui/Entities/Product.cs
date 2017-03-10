using System;

namespace GraphBuilder.Ui.Entities
{
    public abstract class Product : Node
    {
        public static string Label = "Product";
        public string Name { get; protected set; }
        public Brand Brand { get; protected set; }

        public double Price { get; protected set; }

        public Product(string name, Brand brand, double price) : base()
        {
            Name = name;
            Brand = brand;
            Price = price;
        }
    }
}