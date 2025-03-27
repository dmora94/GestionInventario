using GestionTransacciones.Dalc;
using GestionTransacciones.Dbcontexts;
using GestionTransacciones.Endpoints;

using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TransaccionDbcontext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<TransaccionDalc>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapTransaccionEndpointsConsulta();
app.MapTransaccionEndpointsComando();

app.Run();
