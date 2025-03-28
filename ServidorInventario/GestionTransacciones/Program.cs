using GestionTransacciones.Dalc;
using GestionTransacciones.Dbcontexts;
using GestionTransacciones.Endpoints;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
//using Microsoft.OpenApi.Models;
using GestionTransacciones.Modelos;
using System;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<TransaccionDbcontext>(options => options.UseSqlServer("name=DefaultConnection"));
builder.Services.AddScoped<TransaccionDalc>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gestión Transacciones API",
        Description = "CRUD transacciones",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/test",
                   async([FromBody] ObtenerTransaccionesPorIdProducto obtenerTransaccionesPorIdProducto, TransaccionDbcontext transaccionDbcontext) =>
                   {
                       var transacciones = await transaccionDbcontext.Transacciones.ToListAsync();

                       return Results.Ok(transacciones.ObtenerTransaccionDtos());
                   });

app.MapTransaccionEndpointsConsulta();
app.MapTransaccionEndpointsComando();

//app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());
app.Run();
