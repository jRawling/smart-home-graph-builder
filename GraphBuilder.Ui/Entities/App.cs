using System;
using System.Collections.Generic;

namespace GraphBuilder.Ui.Entities
{
    public class App : Node
    {
        public static string Label = "App";
        public string Name { get; private set; }
        public IEnumerable<Store> AvailableOn { get; private set; }
        public Brand Brand { get; private set; }

        public App(string name, Brand brand, IEnumerable<Store> stores) : base()
        {
            Name = name;
            Brand = brand;
            AvailableOn = stores;
        }
    }
}