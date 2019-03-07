using System.Collections.Generic;
using System.Linq;
using ElectronicsStore.Models;
using AutoMapper;
using System.Data.Entity.Infrastructure;

namespace ElectronicsStore.Repository
{
    public class CustomerRepository : ICustomerRepository<Customer>
    {
        private readonly ElectronicsContext _context;
        public CustomerRepository(ElectronicsContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customer.ToList();
        }

        public IQueryable<Customer> Customer => _context.Customer;

        public void Add(CustomerViewModel customerViewModel)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Customer, CustomerViewModel>(); });
            IMapper iMapper = config.CreateMapper();

            var source = new Customer();

            var destination = iMapper.Map<Customer, CustomerViewModel>(source);

            source.FirstName = customerViewModel.FirstName;
            source.LastName = customerViewModel.LastName;
            _context.Customer.Add(source);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
            }

        }

        public Customer GetById(int CustomerId)
        {
            return _context.Customer.Find(CustomerId);

        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }

        public void Edit(int customerid, CustomerViewModel customerViewModel)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Customer, CustomerViewModel>(); });
            Customer customer = _context.Customer.Find(customerid);
            IMapper iMapper = config.CreateMapper();

            var source = _context.Customer.Find(customerid); //new Product();

            var destination = iMapper.Map<Customer, CustomerViewModel>(source);

            _context.SaveChangesAsync();
        }
    }
}
