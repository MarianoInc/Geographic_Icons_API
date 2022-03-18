using Geographic_Icons_API.Data;
using Geographic_Icons_API.Repositories;
using Geographic_Icons_API.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geographic_Icons_API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddEntityFrameworkSqlServer();

            //Añadiendo GeographicIconsContext a contenedor de dependencias de EFCore.
            services.AddDbContextPool<GeographicIconsContext>(optionsAction:(services, options)=>{
                options.UseInternalServiceProvider(services);
                options.UseSqlServer(Configuration.GetConnectionString("GeographicIconsConnectionString"));
            });
            //Agrego repositorio de continentes
            services.AddScoped<IContinentRepository, ContinentRepository>();
            //Agrego repositorio de Ciudades
            services.AddScoped<ICityRepository, CityRepository>();
            //Agrego repositorio de Iconos geográficos
            services.AddScoped<IIconsRepository, IconsRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Este método mapea las rutas de los controladores(mis EndPoints).
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
