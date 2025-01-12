using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Javier_Inventario.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<dbProyecto_InventarioContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));



builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

});

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
