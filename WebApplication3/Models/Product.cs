﻿namespace ElectronicsStore.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImageLocation { get; set; }

        public int? ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
