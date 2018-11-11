using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Models;
using ElectronicsStore.Repository;
using Microsoft.AspNetCore.Http;
using ElectronicsStore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ElectronicsStore
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connection = @"Server=localhost;Database=Electronics;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<ElectronicsContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IProductRepository<Product>, ProductRepository>();
            services.AddTransient<IProductCategoryRepository<ProductCategory>, ProductCategoryRepository>();
            services.AddTransient<ISupplyRepository<Supply>, SupplyRepository>();
            services.AddScoped<ShoppingCartRepository>(sp => ShoppingCartSession.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMemoryCache();
            services.AddSession();

            services.AddSingleton<IMemoryContainer,MemoryContainer>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
