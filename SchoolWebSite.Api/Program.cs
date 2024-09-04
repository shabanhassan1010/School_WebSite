using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolWebSite.Core;
using SchoolWebSite.Core.MiddleWare;
using SchoolWebSite.Infrastructure;
using SchoolWebSite.Infrastructure.Data;
using SchoolWebSite.Services;
using System.Globalization;

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

            #region Localization

            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });
            builder.Services.Configure<RequestLocalizationOptions>(opt =>
            {
                List<CultureInfo> SupportCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("de-DE"),
                    new CultureInfo("ar-EG")
                };
                opt.DefaultRequestCulture = new RequestCulture("en-GB"); // default Language
                opt.SupportedCultures = SupportCultures;
                opt.SupportedUICultures = SupportCultures;
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #region Localization MiddleWare
            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            #endregion

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
