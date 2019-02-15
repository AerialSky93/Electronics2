namespace ElectronicsStore.Models
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public float TotalDollar { get => Quantity * Product.getUnitPrice();}
    }
}
