using System;

namespace GraphBuilder.Ui.Entities
{
    public class Category : Node
    {
        public static string Label = "Category";
        public string Name { get; private set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}