using System.Collections.Generic;

namespace GraphBuilder.Entities
{
    public class Standalone : Product
    {
        public new static string Label = "Standalone:" + Product.Label;
        public App NativeApp { get; private set; }
        public IEnumerable<App> ThirdyPartyApps { get; private set; }

        public Standalone(string name, Brand brand, App nativeApp, IEnumerable<App> thirdPartyApps) : base(name, brand)
        {
            NativeApp = nativeApp;
            ThirdyPartyApps = thirdPartyApps;
        }
    }
}