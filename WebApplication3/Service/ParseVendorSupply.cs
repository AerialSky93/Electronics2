//using System;
//using System.Collections.Generic;
//using ElectronicsStore.Infrastructure;
//using Microsoft.AspNetCore.Http;
//using ElectronicsStore.Models;

//namespace ElectronicsStore.Service
//{
//    public class ParseVendorSupply
//    {

//        public VendorSupply FromCsv(string csvLine)
//        {

//            string[] values = csvLine.Split(',');
//            VendorSupply vendorsupply = new VendorSupply();
//            vendorsupply.VendorId = Convert.ToInt16(values[0]);
//            vendorsupply.ProductId = Convert.ToInt16(values[1]);
//            vendorsupply.Quantity = Convert.ToInt16(values[2]);
//            return vendorsupply;

//        }

//        List<VendorSupply> values = File.ReadAllLines(filePath)
//                                .Select(v => ParseVendorSupply.FromCsv(v))
//                                .ToList();



//    }
//}