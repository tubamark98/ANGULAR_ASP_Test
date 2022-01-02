using ApiEndpoint.Helpers;
using Logic.Classes;
using Logic.Helpers;
using Logic.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
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

            services.AddDbContext<Data.DbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseCors(x => x
              .AllowCredentials()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .WithOrigins("http://localhost:4200"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
