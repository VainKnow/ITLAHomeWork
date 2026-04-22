using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using SenderismoClub.Persistence.Data;
using SenderismoClub.Application.Interfaces;
using SenderismoClub.Application.Services;
using SenderismoClub.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IExcursionService, ExcursionService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();