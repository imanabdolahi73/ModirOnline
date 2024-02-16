using Microsoft.EntityFrameworkCore;
using ModirOnline.ProductManagement.Application.Interfaces;
using ModirOnline.ProductManagement.Application.Service;
using ModirOnline.ProductManagement.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var environment = builder.Environment;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = environment.IsDevelopment() ?
    configuration.GetConnectionString("DebugConnection") :
    configuration.GetConnectionString("ProductConnection");

builder.Services.AddDbContext<DbContextProductManagment>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IDbContextProductManagement, DbContextProductManagment>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
