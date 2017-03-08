using System;

namespace GraphBuilder.Entities
{
    public abstract class Product
    {
        public static string Label = "Product";
        public Guid Id { get; private set; }
        public string Name { get; protected set; }
        public Brand Brand { get; protected set; }

        public Product(string name, Brand brand)
        {
            Id = Guid.NewGuid();
            Name = name;
            Brand = brand;
        }
    }
}