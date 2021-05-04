using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OLSoftware.Transversal.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using OLSoftware.Transversal.Common;
using OLSoftware.Transversal.Logging;
using OLSoftware.Application.Interface;
using OLSoftware.Application.Main;
using OLSoftware.Domain.Interface;
using OLSoftware.Domain.Core;
using OLSoftware.InfraStructure.Interface;
using OLSoftware.InfraStructure.Repository;
using OLSoftware.InfraStructure.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OLSoftware.InfraStructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace OLSoftware.Services.WebAPIRest
{
    public class Startup
    {
        readonly string MiCors = "MiCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ALPHADataContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("MyStringConnection"))
            //.EnableSensitiveDataLogging(true)
            //.UseLoggerFactory(MyLoggerFactory)
            //);

            services.AddDbContext<OLSoftwareDataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"),
                    assembly => assembly.MigrationsAssembly(typeof(OLSoftwareDataContext).Assembly.FullName));
            });

            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
            
            services.AddMvc(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy(name: this.MiCors, builder =>
                {
                    builder.WithHeaders("*");
                    builder.WithOrigins("*");
                    builder.WithMethods("*");
                });
            });

            //Devolver el JSON tal cual como est� el modelo
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            #region Inyectando Capas

            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICustomerDomain, CustomerDomain>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IProjectApplication, ProjectApplication>();
            services.AddScoped<IProjectDomain, ProjectDomain>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            #endregion
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddControllers();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //jwt
            var appSettings = appSettingsSection.Get<AppSettings>();
            var llave = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(d =>
            {
                d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(d =>
            {
                d.RequireHttpsMetadata = false;
                d.SaveToken = true;
                d.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(llave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            
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

            app.UseCors(this.MiCors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
               .AddFilter((category, level) =>
                   category == DbLoggerCategory.Database.Command.Name
                   && level == LogLevel.Information)
               .AddConsole();
        });
    }
}
