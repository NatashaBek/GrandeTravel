using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//...
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NatashaAgileProject.Services;
using NatashaAgileProject.Models;

namespace NatashaAgileProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Identity Services
            services.AddIdentity<User, IdentityRole>
            (
                config =>
                {
                    config.User.RequireUniqueEmail = true;
                    config.Password.RequiredLength = 6;
                    config.Password.RequireDigit = true;
                    config.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                }
            )
            .AddEntityFrameworkStores<ProjectDbContext>();

            //Mvc Services
            services.AddMvc();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            
            //Mvc DbContext
            services.AddDbContext<ProjectDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Static Files
            app.UseStaticFiles();

            //Identity
            app.UseIdentity();

            //Mvc
            app.UseMvcWithDefaultRoute();
        }
    }
}
