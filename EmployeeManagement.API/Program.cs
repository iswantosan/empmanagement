using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Repository.Repositories.EmployeeManagement.Data;
using EmployeeManagement.Repository.Repositories;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeDbContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("EmployeeDbConnection")));

// Register the repository
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
