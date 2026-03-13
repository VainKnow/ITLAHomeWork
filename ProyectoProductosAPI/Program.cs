using Microsoft.EntityFrameworkCore;
using ProyectoProductosAPI.Infrastructure.Context;
using ProyectoProductosAPI.Infrastructure.Interfaces;
using ProyectoProductosAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();