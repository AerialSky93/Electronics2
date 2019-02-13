using System.Collections.Generic;
using System.Linq;
using ElectronicsStore.Models;
using AutoMapper;
using SportsStore.Models;

namespace ElectronicsStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ElectronicsContext _context;

        public OrderRepository(ElectronicsContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Order.ToList();
        }

        public Order GetById(int OrderID)
        {
            return _context.Order.Find(OrderID);
        }
 
    }
}
