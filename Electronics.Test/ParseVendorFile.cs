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

    public class ParseVendorFileNunit
    {

        ParseVendorSupplyFile parseVendorSupplyFiletest = new ParseVendorSupplyFile();
        string csvLineTest = "5,8,3";

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ProcessFiles_ParseCorrectly()
        {

            List<VendorSupply> VendorSupplyList = new List<VendorSupply>();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"TestData\ParseFiletest.txt");

            var result = parseVendorSupplyFiletest.ProcessFiles(path);

            Assert.AreEqual(4, result[1].ProductId);

        }
    }
}