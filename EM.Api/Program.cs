using EM.Data;
using EM.Domain.Interfaces;
using EM.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace EM.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EMContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IEmployeesService, EmployeeService>();
            builder.Services.AddScoped<IDepartmetsService, DepartmetsService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapGet("/", () => "Hello World!");

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<EMContext>();

                if (db.Database.GetPendingMigrations().Count() > 0)
                    db.Database.Migrate();
            }

            app.Run();
        }
    }
}