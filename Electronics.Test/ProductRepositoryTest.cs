using NUnit.Framework;
using Moq;
using ElectronicsStore.Models;
using ElectronicsStore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using AutoFixture;

namespace Electronics.Test
{

    public class ProductRepositoryTest
    {
 //
        ElectronicsContext _context = new ElectronicsContext(new DbContextOptionsBuilder<ElectronicsContext>()
            .UseInMemoryDatabase(databaseName: "Products Test")
            .Options);

        [SetUp]
        public void SetUp()
        {

            _context.Product.Add(new Product { ProductId = 1, ProductName = "TV", ProductDescription = "TV testing", ImageLocation = "test", ProductCategoryId = 2 });
             _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void GetById_Data_Find()
        {
            ProductRepository productRepository = new ProductRepository(_context);
            Assert.AreEqual("TV", productRepository.GetById(1).ProductName);
            var test = new Product
            { ProductId = 1, ProductName = "TV", ProductDescription = "TV testing", ImageLocation = "test" };


            Assert.AreEqual(true,test.Equals(productRepository.GetById(1)));
        }
    }
}