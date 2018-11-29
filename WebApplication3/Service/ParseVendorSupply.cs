using System;
using ElectronicsStore.Models;
using Microsoft.Extensions.Logging;

namespace ElectronicsStore.Service
{
    public class ParseVendorSupply
    {
        private readonly ILogger _logger;

        public ParseVendorSupply(ILogger logger)
        {
            _logger = logger;
        }

        //Split individual line in commas
        public VendorSupply FromCsv(string csvLine)
        {
            VendorSupply vendorsupply = new VendorSupply();

            try
            {
                string[] values = csvLine.Split(',');
                if (values.Length > 3)
                {
                    throw new System.ArgumentException("Too much data");
                }

                vendorsupply.VendorId = Convert.ToInt16(values[0]);
                vendorsupply.ProductId = Convert.ToInt16(values[1]);
                vendorsupply.Quantity = Convert.ToInt16(values[2]);
            }
            catch (Exception)
            {
                _logger.LogInformation("An exception was thrown attempting");
            }
            return vendorsupply;
        }       
    }
}