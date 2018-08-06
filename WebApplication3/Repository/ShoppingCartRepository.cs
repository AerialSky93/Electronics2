using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Repository;
using WebApplication3.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace WebApplication3.Models
{
    public class ShoppingCartRepository 
    {

        private ShoppingCart ShoppingCart = new ShoppingCart();
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable GetShoppingCart()
        {
            return ShoppingCart.ToList();
        }

        public virtual void AddItem(int productid, int quantity)
        {
            ShoppingCart.Add(new CartLine { ProductId = productid, Quantity = quantity });
        }

        public virtual void RemoveItem(int cartlineid)
        {
            ShoppingCart.RemoveAll(l => l.CartLineId == cartlineid);
        }

        public virtual IEnumerable<CartLine> Lines => ShoppingCart;

    }
}
