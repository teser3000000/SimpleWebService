using Microsoft.EntityFrameworkCore;
using ProductStore.Application.Services;
using ProductStore.Core.Abstractions;
using ProductStore.DataAccess;
using ProductStore.DataAccess.Repositories;
using ProductStore.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductStoreDbContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString(nameof(ProductStoreDbContext)),
        b => b.MigrationsAssembly("ProductStore.DataAccess") 
    );
});


builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

builder.Services.AddScoped<IProductsCategoryService, ProductsCategoryService>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
