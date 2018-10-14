
using ElectronicsStore.Models;

namespace ElectronicsStore.Repository
{
    public interface IShoppingCartRepository<T> where T : class
    {
        void AddItem(Product product, int quantity);
        T GetShoppingCart();
        void RemoveItem(int cartlineid);
    }
}

