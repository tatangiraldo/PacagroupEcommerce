using FinalPackagroup.Ecommerce.Application.Interface;
using FinalPackagroup.Ecommerce.Application.Main;
using FinalPackagroup.Ecommerce.Domain.Core;
using FinalPackagroup.Ecommerce.Domain.Interface;
using FinalPackagroup.Ecommerce.Infastructure.Data;
using FinalPackagroup.Ecommerce.Infrastructure.Interface;
using FinalPackagroup.Ecommerce.Infrastructure.Repository;
using FinalPackagroup.Ecommerce.Transversal.Common;
using FinalPackagroup.Ecommerce.Transversal.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using WebApplication2.Helpers;

namespace WebApplication2
{
    public class Startup
    {
        readonly string corsPolicy = "EcommerceCorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //CORS
            services.AddCors(options => options.AddPolicy(corsPolicy, builder => builder.WithOrigins(Configuration["Config:CorsOrigin"]) //from appsettings
                                                                                        .AllowAnyHeader()
                                                                                        .AllowAnyMethod()));
            services.AddControllers();

            // Configuración de Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mi API",
                    Description = "Documentación de mi API con Swagger",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Tu Nombre",
                        Email = "tu@correo.com",
                        Url = new Uri("https://example.com/contact"),
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "Licencia MIT",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                // Ruta al archivo XML generado
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            
            //Authentication 
            var appSettingsSecion = Configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSecion);

            //Instance of app settings to have access to secret, issuer and audience   
            //var appSettings = appSettingsSecion.Get<AppSettings>();


            services.AddSingleton<IConfiguration>(Configuration);

            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            services.AddScoped<IcustomerApplication, CustomerApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            //var Issuer = appSettings.Issuer;
            //var Audience = appSettings.Audience;

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = 
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();    
            }

            // Enable swagger
            app.UseSwagger();
            // Enable swagger Ui
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
                c.RoutePrefix = string.Empty; // Ui in Root
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(corsPolicy);

            //Authentication 
            app.UseAuthentication();
        }
    }
}
