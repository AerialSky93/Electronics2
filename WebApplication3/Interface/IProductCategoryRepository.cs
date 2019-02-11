using System.Collections.Generic;

namespace ElectronicsStore.Repository
{
    public interface IProductCategoryRepository<T> where T :class
    {
        IEnumerable<T> GetAll();
        //T GetById(int productid);
    }
}
