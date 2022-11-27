using Konzerthaus.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Konzerthaus.WebApplication;
using Konzerthaus.Application;


namespace Konzerthaus
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
            services.AddMvc();  
            services.AddEntityFrameworkSqlite().AddDbContext<Context>(); 
            services.AddTransient<TicketService>();  
            services.AddTransient<ConcertService>(); 
            //services.ConfigureSqlite("");
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context context)
        {
            context.Database.EnsureDeleted();  
            context.Database.EnsureCreated(); 
            context.Seed();  

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}"); 
               
            });
        }
    }
}

