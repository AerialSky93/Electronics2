using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using X.PagedList;
using WebApplication3.Repository;

namespace WebApplication3.Repository
{
    public interface IProductRepository<T> where T:class
    {
        IEnumerable<T> GetAllProduct();
        T GetById(int productid);
    }
}
