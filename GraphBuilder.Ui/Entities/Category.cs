using System;

namespace GraphBuilder.Entities
{
    public class Category
    {
        public static string Label = "Category";
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}