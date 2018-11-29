using NUnit.Framework;
using Moq;
using ElectronicsStore.Models;
using ElectronicsStore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using AutoFixture;

using ElectronicsStore.Service;
using Microsoft.Extensions.Logging;

namespace Electronics.Test
{

    public class ParseVendorSupplyNunit
    {


        [SetUp]
        public void SetUp()
        {
   

        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void FromCsv_CorrectLine_ParseCorrectly()
        {
            var logger = new Mock<ILogger>();
            var parseVendorSupply = new ParseVendorSupply(logger.Object);
            string csvLineTest = "5,8,3";
            VendorSupply vendorsupply = parseVendorSupply.FromCsv(csvLineTest);
            Assert.AreEqual(5, vendorsupply.VendorId);
            Assert.AreEqual(8, vendorsupply.ProductId);
            Assert.AreEqual(3, vendorsupply.Quantity);
        }

        [Test]
        public void FromCsv_IncorrectLineExtradata_ExceptionThrown()
        {
            var logger = new Mock<ILogger>();
            var parseVendorSupply = new ParseVendorSupply(logger.Object);

            string csvLineTest = "5,8,3,9,5";

            //VendorSupply vendorsupply = parseVendorSupplytest.FromCsv(csvLineTest);
            Assert.That(() => parseVendorSupply.FromCsv(csvLineTest), Throws.ArgumentException);
        }


    }
}