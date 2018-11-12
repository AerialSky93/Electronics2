using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ElectronicsStore.Models;
using Microsoft.Extensions.Logging;

namespace ElectronicsStore.Service
{
    public class ParseVendorSupplyFile
    {
        ILogger logger;
        public List<VendorSupply> ProcessFiles(string filePath)
        {
            ParseVendorSupply parseVendorSupply = new ParseVendorSupply(logger);

            StreamReader reader = File.OpenText(filePath);

            List<VendorSupply> values = File.ReadAllLines(filePath)
                                            .Select(v => parseVendorSupply.FromCsv(v))
                                            .ToList();
            return values;
        }
    }
}