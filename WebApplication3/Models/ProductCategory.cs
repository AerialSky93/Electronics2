using System;
using System.Collections.Generic;
using ElectronicsStore.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace ElectronicsStore.Models
{
    public partial class ProductCategory
    {

        public ProductCategory()
        {
            Product = new HashSet<Product>();
        }
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryDescription { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
