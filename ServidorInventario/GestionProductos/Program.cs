using GestionProductos.Dalc;
using GestionProductos.Dbcontexts;
using GestionProductos.Endpoints;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ProductoDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ProductoDalc>();
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

app.MapProductoEndpointsConsulta();
app.MapProductoEndpointsComando();

app.Run();
