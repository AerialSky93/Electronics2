using NUnit.Framework;
using Moq;
using ElectronicsStore.Models;
using ElectronicsStore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using AutoFixture;

using ElectronicsStore.Service;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace Electronics.Test
{

    public class ParseVendorDatabaseNunit
    {

        ElectronicsContext _context = new ElectronicsContext(new DbContextOptionsBuilder<ElectronicsContext>()
        .UseInMemoryDatabase(databaseName: "Products Test")
        .Options);


        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void ParseVendorDatabase_ImportCorrectly()
        {


            ParseVendorDatabase parseVendorDatabase = new ParseVendorDatabase(_context);


            List<VendorSupply> vendorSupply = new List<VendorSupply>();

            vendorSupply.Add(new VendorSupply() { VendorSupplyId = 1, VendorId = 5, ProductId = 1, Quantity = 12 });
            vendorSupply.Add(new VendorSupply() { VendorSupplyId = 2, VendorId = 3, ProductId = 9, Quantity = 5 });
            _context.SaveChanges();

            parseVendorDatabase.CopytoDatabase(vendorSupply);

            Assert.AreEqual(12, _context.VendorSupply.Find(1).Quantity);

        }
    }
}