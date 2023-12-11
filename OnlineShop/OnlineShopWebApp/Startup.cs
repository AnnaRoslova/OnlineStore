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

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 5;   // минимальная длина
                opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                opts.Password.RequireDigit = false; // требуются ли цифры
            })
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
            services.AddAuthentication();
            services.AddAuthorization();
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

            app.UseAuthentication();
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