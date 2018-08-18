using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Models;
using X.PagedList;
using ElectronicsStore.Repository;
using ElectronicsStore.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace ElectronicsStore.Repository
{
    public interface IProductRepository<T> where T:class
    {
        IEnumerable<T> GetAllProduct();
        T GetById(int productid);
    }
}
