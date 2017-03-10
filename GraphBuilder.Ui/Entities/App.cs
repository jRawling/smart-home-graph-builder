using System;
using System.Collections.Generic;

namespace GraphBuilder.Ui.Entities
{
    public class App
    {
        public static string Label = "App";
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<AppStore> AvailableOn { get; private set; }
        public Brand Brand { get; private set; }

        public App(string name, Brand brand, IEnumerable<AppStore> appStores)
        {
            Id = Guid.NewGuid();
            Name = name;
            Brand = brand;
            AvailableOn = appStores;
        }
    }
}