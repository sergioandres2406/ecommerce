
namespace ecommerce.Web
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ecommerce.Web.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;



    public class Startup
    {

        //Aqui se define toda la configuración del proyecto
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //dentro de esta función se configuran todos los parámetros del proyecto
        public void ConfigureServices(IServiceCollection services)
        {

            //aqui se define la conexión,  se crea un objeto  para manipular sql server, y se extrae el nombre de la bd y el usuario 
            //de DefaultConnection, el cual es el parámetro que está en json en appsettings.json
            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
            });

            //este es el servicio de cookies
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
