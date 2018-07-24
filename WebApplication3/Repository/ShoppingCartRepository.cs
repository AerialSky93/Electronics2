using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Models
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {

        private ShoppingCart ShoppingCart = new ShoppingCart();


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

    }
}
