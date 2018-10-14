using System;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ElectronicsStore.Infrastructure;
using Microsoft.AspNetCore.Http;


namespace ElectronicsStore.Models
{
    public class ShoppingCartSession : ShoppingCartRepository
    {
        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            ShoppingCartSession shoppingcartsession = session?.GetJson<ShoppingCartSession>("ShoppingCartRepository") ?? new ShoppingCartSession();
            shoppingcartsession.Session = session;
            return shoppingcartsession;
        }

        [JsonIgnore]
        public ISession Session { get; set; }


        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("ShoppingCartRepository", this);
        }


        public override void RemoveItem(int cartlineid)
        {
            base.RemoveItem(cartlineid);
            Session.SetJson("ShoppingCartRepository", this);
        }
    }
}