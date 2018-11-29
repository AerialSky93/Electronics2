using SportsStore.Models;
using System.Collections.Generic;

namespace ElectronicsStore.Repository
{
    public interface IOrderRepository
    {
        Order GetOrder(int OrderID);
        IEnumerable<Order> GetAllOrder();
    }
}