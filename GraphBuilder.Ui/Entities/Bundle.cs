using System;
using System.Collections.Generic;
using System.Text;

namespace GraphBuilder.Ui.Entities
{
    public class Bundle : Product
    {
        public new static string Label = "Bundle:" + Product.Label;
        public IEnumerable<Product> Products { get; private set; }
        public Bundle(string name, Brand brand, double price, IEnumerable<Product> products) : base(name, brand, price)
        {
            Products = products;
        }
    }
}
