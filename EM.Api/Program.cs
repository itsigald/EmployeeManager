using EM.Data;
using EM.Domain.Interfaces;
using EM.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(_ => builder.Configuration);
builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<IDepartmetsService, DepartmetsService>();
builder.Services.AddScoped<ITasksSerevice, TasksSerevice>();
builder.Services.AddScoped<IReportsService, ReportsService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
