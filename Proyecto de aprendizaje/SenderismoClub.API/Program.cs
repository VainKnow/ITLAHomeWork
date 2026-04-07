using Microsoft.EntityFrameworkCore;
using SenderismoClub.Persistence.Data;
using SenderismoClub.Application.Interfaces;
using SenderismoClub.Application.Services;
using SenderismoClub.API.Middlewares;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IExcursionService, ExcursionService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();