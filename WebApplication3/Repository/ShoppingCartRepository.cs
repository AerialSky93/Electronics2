using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class ShoppingCartRepository
    {

        private List<CartLine> ShoppingCart = new List<CartLine>();

        public IEnumerable GetShoppingCart()
        {
            return ShoppingCart.ToList();
        }

        public void AddItem(int productid, int quantity)
        {
            ShoppingCart.Add(new CartLine { ProductId = productid, Quantity = quantity });
        }

        public void RemoveItem(int cartlineid)
        {
            ShoppingCart.RemoveAll(l=>l.CartLineId == cartlineid);
        }

    }
}
