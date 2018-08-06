using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Web;
using System.Linq;
using WebApplication3.Models;
using WebApplication3.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication3.Models
{

    public class ShoppingCartSession : ShoppingCartRepository
    {

        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            ShoppingCartSession shoppingcartsession = session?.GetJson<ShoppingCartSession>("Cart") ?? new ShoppingCartSession();
            shoppingcartsession.Session = session;
            return shoppingcartsession;
        }

        [JsonIgnore]
        public ISession Session { get; set; }


        public override void AddItem(int productid, int quantity)
        {
            base.AddItem(productid, quantity);
            Session.SetJson("ShoppingCartRepository", this);
        }


        public override void RemoveItem(int cartlineid)
        {
            base.RemoveItem(cartlineid);
            Session.SetJson("ShoppingCartRepository", this);
        }
    }
}