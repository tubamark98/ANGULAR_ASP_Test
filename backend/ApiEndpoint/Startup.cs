using ApiEndpoint.Helpers;
using Logic.Classes;
using Logic.Helpers;
using Logic.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repository.Classes;
using Repository.Interfaces;
using System;
using System.IO;
using System.Reflection;

namespace ApiEndpoint
{
    public class Startup
    {
        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(x => x.Filters.Add(new ApiExceptionFilter()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiEndpoint", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddTransient<IWorkerLogic, WorkerLogic>();
            services.AddTransient<IWorkerRepo, WorkerRepo>();
            services.AddTransient<IDepartmentLogic, DepartmentLogic>();
            services.AddTransient<IDepartmentRepo, DepartmentRepo>();
            services.AddTransient<DBSeed, DBSeed>();

            string appsettingsConnectionString = Configuration.GetConnectionString("workerdb");
            services.AddDbContext<Data.workerDbContext>(options =>options
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .UseSqlServer(appsettingsConnectionString, b => b.MigrationsAssembly("ApiEndpoint")));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                  });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiEndpoint v1");
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
