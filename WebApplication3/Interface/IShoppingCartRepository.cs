
using ElectronicsStore.Models;

namespace ElectronicsStore.Repository
{
    public interface IShoppingCartRepository<T> where T : class
    {
        T GetAll();
        void AddItem(Product product, int quantity);
        void RemoveItem(int cartlineid);
    }
}

