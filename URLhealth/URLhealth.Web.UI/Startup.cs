using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLhealth.BLL.Concrete;
using URLhealth.BLL.Interfaces;
using URLhealth.DAL.Concrete;
using URLhealth.DAL.Interfaces;
using URLhealth.Web.UI.MyHubs;
using URLhealth.Web.UI.Services;

namespace URLhealth.Web.UI
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
            services.AddSingleton<ILogsDal, EfLogsDal>();
            services.AddSingleton<ILogsService, LogsManager>();

            services.AddScoped<IUsersDal, EfUsersDal>();
            services.AddScoped<IUsersService, UsersManager>();

            services.AddSingleton<IUrlDal, EfUrlDal>();
            services.AddSingleton<IUrlService, UrlManager>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddAutoMapper(typeof(Startup));

            services.AddDistributedMemoryCache();
            services.AddSession(option =>
            {

                option.IdleTimeout = TimeSpan.FromHours(12);

            });
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSignalR();
            services.AddMemoryCache();
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromHours(2);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapHub<UrlHubs>("/UrlHubs");
            });
        }
    }
}
