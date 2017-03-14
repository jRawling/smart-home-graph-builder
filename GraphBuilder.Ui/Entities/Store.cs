using System;

namespace GraphBuilder.Ui.Entities
{
    public class Store : Node
    {
        public static string Label = "Store";
        public string Name { get; private set; }
		public Brand Brand { get; private set; }

        public Store(string name, Brand brand) : base()
        {
            Name = name;
			Brand = brand;
        }
    }
}