﻿using System;

namespace GraphBuilder.Ui.Entities
{
    public class AppStore : Node
    {
        public static string Label = "AppStore";
        public string Name { get; private set; }

        public AppStore(string name) : base()
        {
            Name = name;
        }
    }
}