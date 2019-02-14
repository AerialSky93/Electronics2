namespace ElectronicsStore.Models
{
    public class VendorRepository 
    {
        private readonly ElectronicsContext _context;

        public VendorRepository(ElectronicsContext context)
        {
            _context = context;
        }

        public Vendor GetById(int vendorId)
        {
            return _context.Vendor.Find(vendorId);

        }

    }
}
