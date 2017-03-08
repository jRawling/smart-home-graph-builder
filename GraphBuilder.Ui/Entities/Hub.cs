namespace GraphBuilder.Entities
{
    public class Hub : Product
    {
        public new static string Label = "Hub:" + Product.Label;
        public Hub(string name, Brand brand) : base(name, brand) { }
    }
}