using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public interface ISupplyRepository<T> where T : class
    {
        IQueryable<Supply> Supply { get; }

        IEnumerable<Supply> GetAllSupply();
        Product GetById(int SupplyId);
        void ProcessFiles(string filePath);
    }
}