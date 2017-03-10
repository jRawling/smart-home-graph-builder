namespace GraphBuilder.Ui.Entities
{
    public class Hub : Product
    {
        public new static string Label = "Hub:" + Product.Label;
        public Hub(string name, Brand brand , double price) : base(name, brand, price) { }
    }
}