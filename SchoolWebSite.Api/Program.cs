using Microsoft.EntityFrameworkCore;
using SchoolWebSite.Core;
using SchoolWebSite.Core.MiddleWare;
using SchoolWebSite.Infrastructure;
using SchoolWebSite.Infrastructure.Data;
using SchoolWebSite.Services;

namespace SchoolWebSite.Api
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
            builder.Services.AddSwaggerGen();

            #region Add Connection String

            builder.Services.AddDbContext<ApplictionDBContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DBcontext"));
            });

            #endregion

            #region Dependency Injection
            builder.Services.AddInfrastructureDependencies();
            builder.Services.AddServiceDependencies();
            builder.Services.AddCoreDependencies();
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #region UseMiddleware
            app.UseMiddleware<ErrorHandlerMiddleware>();
            #endregion

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
