
using ElectronicsStore.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicsStore.Models
{
    public class ShoppingCartRepository : IShoppingCartRepository<ShoppingCart>
    {

        private ShoppingCart shoppingCart = new ShoppingCart();
        //private List<CartLine> lineCollection = new List<CartLine>();

        public ShoppingCart GetAll()
        {
            return shoppingCart;
        }

        public virtual void AddItem(Product product, int quantity)
        {
            shoppingCart.Find(p => p.Product == product);

            CartLine cartline = shoppingCart.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();

            if (cartline == null)
            {
                shoppingCart.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                cartline.Quantity += quantity;

            }

        }

        public virtual void RemoveItem(int cartlineid)
        {
            shoppingCart.RemoveAll(l => l.CartLineId == cartlineid);
        }

        public virtual IEnumerable<CartLine> Lines => shoppingCart;


    }
}
