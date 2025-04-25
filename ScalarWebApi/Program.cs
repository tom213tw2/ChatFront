
using Microsoft.OpenApi.Models;

using System.Reflection;
using Scalar.AspNetCore;
using Swashbuckle.AspNetCore.Filters;

namespace ScalarWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Scare API",
                    Version = "v1"
                });
                
                options.ExampleFilters();
               
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                
                options.IncludeXmlComments(xmlPath,true);
               
            });

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Scare API V1");
                    options.RoutePrefix = "swagger";
                });

                // ✅ ReDoc
                app.UseReDoc(options =>
                {
                    options.RoutePrefix = "docs";
                    options.DocumentTitle = "Scare API 文件";
                    options.SpecUrl = "/swagger/v1/swagger.json";
                });

                
                app.MapScalarApiReference("/scalar", options =>
                {
                    options.OpenApiRoutePattern = "/swagger/v1/swagger.json";
                    options.Theme = ScalarTheme.BluePlanet;
                    options.DarkMode = false;
                    options.DotNetFlag = true;
                    options.HideDownloadButton = true;
                    options.HideModels = true;
                });
               
            }

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
