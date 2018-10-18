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

    public class TestClass
    {

        //var ElectronicsContext = new Mock<ElectronicsContext>();


    // private DbContextOptionsBuilder<ElectronicsContext> context = new DbContextOptionsBuilder<ElectronicsContext>();

        [Test]
        public void TestProducts()
        {
            var options = new DbContextOptionsBuilder<ElectronicsContext>()
                .UseInMemoryDatabase(databaseName: "Products Test")
                .Options;

            using (var context = new ElectronicsContext(options))
            {
                //DbContextOptionsBuilder<ElectronicsContext> context = new DbContextOptionsBuilder<ElectronicsContext>()

                context.Product.Add(new Product { ProductId = 1, ProductName = "TV", ProductDescription = "TV testing", ImageLocation = "test" , ProductCategoryId = 2});
                context.SaveChanges();
                ProductRepository productRepository = new ProductRepository(context);
                var test = new Product
                    {ProductId = 1, ProductName = "TV", ProductDescription = "TV testing", ImageLocation = "test", ProductCategoryId = 2};
                Assert.AreEqual("TV", productRepository.GetById(1).ProductName);
                //Assert.AreEqual(test,productRepository.GetById(1));
                // Assert.AreEqual(Object.Equals(test, productRepository.GetById(1)), 1);

            }
        }

        [Test]
        public void TestResults()
        {

            Assert.AreEqual(1,1);
        }

    }


}
