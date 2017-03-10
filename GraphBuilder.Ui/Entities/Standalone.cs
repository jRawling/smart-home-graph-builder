using System.Collections.Generic;

namespace GraphBuilder.Ui.Entities
{
    public class Standalone : Product
    {
        public new static string Label = "Standalone:" + Product.Label;
        public App NativeApp { get; private set; }
        public IEnumerable<App> ThirdyPartyApps { get; private set; }

        public Standalone(string name, Brand brand, double price, App nativeApp, IEnumerable<App> thirdPartyApps) : base(name, brand, price)
        {
            NativeApp = nativeApp;
            ThirdyPartyApps = thirdPartyApps;
        }
    }
}