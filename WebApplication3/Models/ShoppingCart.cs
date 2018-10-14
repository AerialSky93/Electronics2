using System.Collections.Generic;

namespace ElectronicsStore.Models
{
    public class ShoppingCart : List<CartLine>
    {
        public ShoppingCart() { }

        public ShoppingCart(IEnumerable<CartLine> collection) : base(collection) { }

        public ShoppingCart(int capacity) : base(capacity) { }

    }
}
