namespace ElectronicsStore.Models
{
    public partial class VendorSupply
    {
        public int VendorId;
        public int ProductId;
        public int Quantity;

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
