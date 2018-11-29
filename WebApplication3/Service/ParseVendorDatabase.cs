using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ElectronicsStore.Models;
using ElectronicsStore.Repository;
using Microsoft.Extensions.Logging;

namespace ElectronicsStore.Service
{
    public class ParseVendorDatabase
    {
        ILogger logger;
        private readonly ElectronicsContext _context;
        public ProductRepository productrepository;
        public VendorRepository vendorrepository;

        public ParseVendorDatabase(ElectronicsContext context)
        {
            _context = context;
        }

        public void CopytoDatabase(List<VendorSupply> values)
        {
            foreach (VendorSupply i in values)
            {
                //var product = productrepository.GetById(i.ProductId);
                //var vendor = vendorrepository.GetById(i.VendorId);
                //_context.Supply.Add(new Supply { Vendor = vendor, Product = product, SupplyQuantity = i.Quantity });
                _context.VendorSupply.Add(new VendorSupply { VendorId = i.VendorId, ProductId = i.ProductId, Quantity = i.Quantity });

                _context.SaveChangesAsync();
            }
        }
    }
}



//public async void ProcessFiles(string filePath)
//{
//    //StreamReader reader = File.OpenText("filename.txt");

//    //List<VendorSupply> values = File.ReadAllLines(@"C:\Users\Ritwik\Desktop\filenametest.txt")
//    //                                .Select(v => VendorSupply.FromCsv(v))
//    //                                .ToList();


//    List<VendorSupply> values = File.ReadAllLines(filePath)
//                                    .Select(v => ParseVendorSupply.FromCsv(v))
//                                    .ToList();

//    foreach (VendorSupply i in values)
//    {
//        var product = productrepository.GetById(i.ProductId);
//        var vendor = vendorrepository.GetById(i.VendorId);
//        _context.Supply.Add(new Supply { Vendor = vendor, Product = product, SupplyQuantity = i.Quantity });
//        await _context.SaveChangesAsync();
//    }

