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
using ChallengeAlternativo.API.Dal;
using ChallengeAlternativo.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            //Inyección de servicios

            //Servicio para el Login y Register
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();

            //Servicios para generar el Token
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "https://localhost:5001",
                    ValidIssuer = "https://localhost:5001",
                    IssuerSigningKey = 
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyDeAutorizacion"))
                };
            });                


            //En este caso no es necesario
            //services.AddEntityFrameworkSqlServer();

            services.AddDbContext<GeographicIconsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GeographicIconsConnectionString")));
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UsersConnectionString")));

            //No funcionaba el pooling??
            /*
            Añadiendo GeographicIconsContext a contenedor de dependencias de EFCore.
            services.AddDbContextPool<GeographicIconsContext>(optionsAction:(services, options)=>{
                options.UseInternalServiceProvider(services);
                options.UseSqlServer(Configuration.GetConnectionString("GeographicIconsConnectionString"));
            });
            */
            
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
