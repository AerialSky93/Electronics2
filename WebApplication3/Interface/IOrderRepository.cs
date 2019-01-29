using SportsStore.Models;
using System.Collections.Generic;

namespace ElectronicsStore.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int OrderID);
    }
}