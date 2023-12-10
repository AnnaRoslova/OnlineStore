using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using OnlineShop.Db;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Http;
using OnlineShop.Db.Models;

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

            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(connection));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.LoginPath = "/User/Account/Login";
                options.LogoutPath = "/User/Account/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });
            services.AddTransient<IWishListRepository, WishListDbRepository>();
            services.AddTransient<ICompareRepository, CompareDbRepository>();
            services.AddTransient<IOrdersRepository, OrdersDbRepository>();
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