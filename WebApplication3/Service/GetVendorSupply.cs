//using System;
//using System.Collections.Generic;
//using ElectronicsStore.Infrastructure;
//using Microsoft.AspNetCore.Http;
//using ElectronicsStore.Models;

//namespace ElectronicsStore.Service
//{
//    public class ImportVendorSupply
//    {

//        List<VendorSupply> values = File.ReadAllLines(filePath)
//                                        .Select(v => ParseVendorSupply.FromCsv(v))
//                                        .ToList();

//        foreach (VendorSupply i in values)
//        {
//            var product = productrepository.GetById(i.ProductId);
//            var vendor = vendorrepository.GetById(i.VendorId);
//            _context.Supply.Add(new Supply { Vendor = vendor, Product = product, SupplyQuantity = i.Quantity});
//            await _context.SaveChangesAsync();
//}

//    }
//}