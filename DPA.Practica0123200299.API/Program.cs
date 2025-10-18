using DPA.Practica0123200299.CORE.Core.Services;
using DPA.Practica0123200299.CORE.Infrastructure.Data;
using DPA.Practica0123200299.CORE.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _configuration = builder.Configuration;
var _connectionString = _configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UniversidadBdContext>(options =>
{
    options.UseSqlServer(_connectionString);
});

builder.Services.AddTransient<ICarreraRepository, CarreraRepository>();
builder.Services.AddTransient<ICarreraService, CarreraService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
