using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using OnlineShop.Db;

namespace OnlineShopWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("online_shop");
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connection));
            services.AddTransient<IWishListRepository, WishListDbRepository>();
            services.AddSingleton<ICompareRepository, CompareInMemoryRepository>();
            services.AddSingleton<IOrdersRepository, OrdersInMemoryRepository>();
            services.AddTransient<ICartsRepository, CartsDbRepository>();
            services.AddTransient<User>();
            services.AddTransient<IProductsStorage, ProductsDbStorage>();
            services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
            services.AddTransient<IUserManeger, UsersManeger>();
            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=user}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}