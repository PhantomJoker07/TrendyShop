using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TrendyShop.Models;
using TrendyShop.Data;
using Microsoft.AspNetCore.Identity;

namespace TrendyShop
{
    public class Startup
    {
        IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment _env)
        {
            this._env = _env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFDbContext>(options => options.UseSqlServer(Configuration["ConnectionString:IdentityConnection"].Replace("%CONTENTROOTPATH%", _env.ContentRootPath)));
            services.AddControllersWithViews();

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<EFDbContext>();
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddScoped<IUserRepository, SQLUserRepository>();
            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/User/Login");
                opt.AccessDeniedPath = new PathString("/User/Login");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           // if (env.IsDevelopment())
           // {
                app.UseDeveloperExceptionPage();
           // }
           // else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
