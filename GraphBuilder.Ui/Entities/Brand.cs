using System;

namespace GraphBuilder.Ui.Entities
{
    public class Brand : Node
    {
        public static string Label = "Brand";
        public string Name { get; private set; }

        public Brand(string name) : base()
        {
            Name = name;
        }
    }
}