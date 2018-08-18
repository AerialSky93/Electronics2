using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicsStore.Models;
using ElectronicsStore.Repository;
using ElectronicsStore.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace ElectronicsStore.Models
{
    public class ShoppingCartRepository 
    {

        private ShoppingCart ShoppingCart = new ShoppingCart();
        //private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable GetShoppingCart()
        {
            return ShoppingCart.ToList();
        }

        public virtual void AddItem(Product product, int quantity)
        {
            ShoppingCart.Add(new CartLine { Product = product, Quantity = quantity });
        }

        public virtual void RemoveItem(int cartlineid)
        {
            ShoppingCart.RemoveAll(l => l.CartLineId == cartlineid);
        }

        public virtual IEnumerable<CartLine> Lines => ShoppingCart;


    }
}
