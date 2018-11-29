namespace ElectronicsStore.Models
{
    public partial class VendorSupply
    {
        public int VendorSupplyId { get; set; }
        public int VendorId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        //public static VendorSupply FromCsv(string csvLine)
        //{
        //    string[] values = csvLine.Split(',');
        //    VendorSupply vendorsupply = new VendorSupply();
        //    vendorsupply.VendorId = Convert.ToInt16(values[0]);
        //    vendorsupply.ProductId = Convert.ToInt16(values[1]);
        //    vendorsupply.Quantity = Convert.ToInt16(values[2]);
        //    return vendorsupply;
        //}
    }

}
