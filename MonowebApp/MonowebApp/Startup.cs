using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonowebApp.Models;
using MonowebApp.Repositorios;
using MonowebApp.Repositorios.Base;

namespace MonowebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            /*---------------------------------------------------------------
            / Verificacion de cual conexion usar.... produccion y desarrollo.
            -----------------------------------------------------------------*/
            string ConnStr = Configuration.GetConnectionString("prodConn");
            if (Configuration.GetSection("AppSettings")["EnProduccion"].Equals("No"))
            {
                ConnStr = Configuration.GetConnectionString("devConn");
            }
                


            //dependecy injection de la conexion del sql a los controllers
              services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnStr),
             ServiceLifetime.Scoped);

            //   dependencia temporal con el antiguo entityframeword
            //  services.AddDbContext<OldDbContext>(options => options.UseSqlServer(ConnStr),
            // ServiceLifetime.Scoped);

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Inyecta el repositorio generico CRUD a todos los controllers.                                   //
            services.AddScoped<IMarcaRepo, MarcaRepo>();                                                      //       INYECCION DE DEPENDENCIA DE LOS REPOSITORIOS.
            services.AddScoped<IModeloRepo, ModeloRepo>();                                                    //
                                                                                                              //
            //Inyectamos el repoWrapper                                                                       //
            services.AddScoped<IRepoWrapper, RepoWrapper>();                                                  //
                                                                                                              //  
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //inyectar dependiencia a un proyecto de 
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));// inyectar los datos constantes de la app.
            services.Configure<GlobalSetting>(Configuration);   //inyectar los datos constantes de la app.
           //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection?view=aspnetcore-3.1

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
