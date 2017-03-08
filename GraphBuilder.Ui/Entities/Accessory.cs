using System.Collections.Generic;

namespace GraphBuilder.Entities
{
    public class Accessory : Standalone
    {
        public new static string Label = "Accessory:" + Product.Label;
        public Hub Requires { get; private set; }

        public Accessory(string name, Brand brand, App nativeApp, IEnumerable<App> thirdPartyApps, Hub requires) : base(name, brand, nativeApp, thirdPartyApps)
        {
            Requires = requires;
        }
    }
}