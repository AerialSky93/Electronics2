
using System.Collections.Generic;


namespace ElectronicsStore.Models
{
    public class ShoppingCartRepository : IShoppingCartRepository<ShoppingCart>
    {

        private ShoppingCart shoppingCart = new ShoppingCart();
        //private List<CartLine> lineCollection = new List<CartLine>();

        public ShoppingCart GetShoppingCart()
        {
            return shoppingCart;
        }

        public virtual void AddItem(Product product, int quantity)
        {
            shoppingCart.Add(new CartLine { Product = product, Quantity = quantity });
        }

        public virtual void RemoveItem(int cartlineid)
        {
            shoppingCart.RemoveAll(l => l.CartLineId == cartlineid);
        }

        public virtual IEnumerable<CartLine> Lines => shoppingCart;


    }
}
