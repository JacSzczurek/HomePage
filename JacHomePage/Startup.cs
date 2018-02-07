using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JacHomePage.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using JacHomePage.Authorization;
using JacHomePage.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using NToastNotify;

namespace JacHomePage
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
            services.Configure<OfferSettings>(Configuration.GetSection("OfferSettings"));

            services.AddAutoMapper();

            services.AddDbContext<JackDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddNToastNotify(new ToastOption()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.TopRight,
                ShowDuration = 5
            });
            services.AddScoped<IJackRepository, JackRepository>();

            services.AddMvc();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
