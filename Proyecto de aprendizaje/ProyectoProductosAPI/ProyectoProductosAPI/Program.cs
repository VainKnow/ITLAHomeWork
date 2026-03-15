using Microsoft.EntityFrameworkCore;
using ProyectoProductosAPI.Application.Contract;
using ProyectoProductosAPI.Application.Service;
using ProyectoProductosAPI.Infrastructure.Interfaces;
using ProyectoProductosAPI.Infrastructure.Repositories;
using ProyectoProductosAPI.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();