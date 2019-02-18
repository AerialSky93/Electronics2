using ElectronicsStore.Models;
using System.Collections.Generic;

namespace ElectronicsStore.Repository
{
    public interface ICustomerRepository<T> where T :class
    {
        IEnumerable<T> GetAll();
        T GetById(int customerid);
        void Add(CustomerViewModel customerViewModel);
        void Edit(int customerid, CustomerViewModel customerViewModel);
    }
}
