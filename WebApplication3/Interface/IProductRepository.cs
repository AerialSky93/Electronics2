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
using WebApplication3.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace WebApplication3.Repository
{
    public interface IProductRepository<T> where T:class
    {
        IEnumerable<T> GetAllProduct();
        T GetById(int productid);
    }
}
