using ElectronicsStore.Models;
using System.Collections.Generic;

namespace ElectronicsStore.Repository
{
    public interface IProductRepository<T> where T :class
    {
        IEnumerable<T> GetAll();
        T GetById(int productid);
        void Edit(int productid, ProductViewModel productViewModel);
    }
}
