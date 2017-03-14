using System;

namespace GraphBuilder.Ui.Entities
{
    public class AppStore : Node
    {
        public static string Label = "AppStore";
        public string Name { get; private set; }
		public Brand Brand { get; private set; }

        public AppStore(string name, Brand brand) : base()
        {
            Name = name;
			Brand = brand;
        }
    }
}