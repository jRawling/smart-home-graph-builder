using System;
using System.Collections.Generic;
using System.Text;

namespace GraphBuilder.Ui.Entities
{
    public class Bundle : Product
    {
        public new static string Label = "Bundle:" + Product.Label;
        public Bundle(string name, Brand brand, double price) : base(name, brand, price) { }
    }
}
