using GestionProductos;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Linq;
using System.Linq.Expressions;

using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ProductoDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region consultas
app.MapPost("/consultas/obtenerProductos", async (ProductoDbContext context) =>
{
    var productos = await context.Productos.ToListAsync();
    return Results.Ok(productos.ObtenerProductoDtos());
})
.WithName("ObtenerProductos")
.WithOpenApi();

app.MapPost("/consultas/obtenerProductosPorId", async ([FromBody] ObtenerProductosPorId obtenerProductosPorId, 
                                                      ProductoDbContext context) =>
{
    await Task.CompletedTask;

    var productos = 
        context
        .Productos
        .AsQueryable()
        .ConsultaPorId(obtenerProductosPorId.Id, obtenerProductosPorId.Ascendente)
        .AsEnumerable();

    var productosOrdenados = 
        obtenerProductosPorId.Ascendente
        ? productos.OrderBy(x => x.Id)
        : productos.OrderByDescending(x=> x.Id);

    var productosAMostrar =
        productosOrdenados
        .Take(obtenerProductosPorId.NumeroRegistros)
        .ReversePorAscendente(obtenerProductosPorId.Ascendente)
        .ToList();

    return Results.Ok(productosAMostrar.ObtenerProductoDtos());
})
.WithName("ObtenerProductosPorId")
.WithOpenApi();

app.MapPost("/consultas/obtenerProductosPorNombre", async ([FromBody] ObtenerProductosPorNombre obtenerProductosPorNombre, 
                                                          ProductoDbContext context) =>
{
    await Task.CompletedTask;

    var productos = 
        context
        .Productos
        .AsQueryable()
        .ConsultaPorNombre(obtenerProductosPorNombre.Nombre,
                            obtenerProductosPorNombre.Id,
                            obtenerProductosPorNombre.Ascendente)
        .AsEnumerable();

    var productosOrdenados =
       obtenerProductosPorNombre.Ascendente
       ? productos.OrderBy(x => x.Id)
       : productos.OrderByDescending(x => x.Id);

    var productosAMostrar =
        productosOrdenados
        .Take(obtenerProductosPorNombre.NumeroRegistros)
        .ReversePorAscendente(obtenerProductosPorNombre.Ascendente)
        .ToList();

    return Results.Ok(productosAMostrar.ObtenerProductoDtos());
})
.WithName("ObtenerProductosPorNombre")
.WithOpenApi();

app.MapPost("/consultas/obtenerProducto", async ([FromBody] ObtenerProducto obtenerProducto, ProductoDbContext context) =>
{
    var producto = await context.Productos.FindAsync(obtenerProducto.Id);

    return producto is not null
           ? Results.Ok(producto.ObtenerProductoDto())
           : Results.NotFound(default);
})
.WithName("ObtenerProducto")
.WithOpenApi();

app.MapPost("/consultas/validarInventario", async ([FromBody] ValidarInventario validarInventario, ProductoDbContext context) =>
{
    var producto = await context.Productos.FindAsync(validarInventario.IdProducto);

    if (producto == null)
        return Results.Ok(false);

    if (producto.Stock <= validarInventario.StockDisminuir)
        return Results.Ok(false);

    return Results.Ok(true);
})
.WithName("ValidarInventario")
.WithOpenApi();

#endregion consultas

#region comandos

app.MapPost("/comandos/agregarProducto", async ([FromBody] AgregarProducto agregarProducto, ProductoDbContext context) =>
{
    byte[]? imagen = ProductoUtilidades.ConvertirImagen(agregarProducto.Imagen);

    var producto = new Producto(agregarProducto.Nombre,
                                agregarProducto.Descripcion,
                                agregarProducto.Categoria,
                                agregarProducto.Precio,
                                agregarProducto.Stock,
                                imagen);
    context.Productos.Add(producto);
    await context.SaveChangesAsync();

    return Results.Ok(producto.Id);
})
.WithName("AgregarProducto")
.WithOpenApi();

app.MapPost("/comandos/actualizarProducto", async ([FromBody] ActualizarProducto actualizacionProducto, ProductoDbContext context) =>
{
    var producto = await context.Productos.FindAsync(actualizacionProducto.Id);

    if (producto == null)
        return Results.NotFound();

    byte[]? imagen = ProductoUtilidades.ConvertirImagen(actualizacionProducto.Imagen);
    producto.Nombre = actualizacionProducto.Nombre;
    producto.Descripcion = actualizacionProducto.Descripcion;
    producto.Categoria = actualizacionProducto.Categoria;
    producto.Precio = actualizacionProducto.Precio;
    producto.Stock = actualizacionProducto.Stock;
    producto.Imagen = imagen;

    context.Productos.Update(producto);
    await context.SaveChangesAsync();

    return Results.NoContent();
})
.WithName("ActualizarProducto")
.WithOpenApi();

app.MapPost("/comandos/eliminarProducto", async ([FromBody] EliminarProducto eliminarProducto, ProductoDbContext context) =>
{
    var producto = await context.Productos.FindAsync(eliminarProducto.IdProducto);
    if (producto == null)
        return Results.NotFound();

    context.Productos.Remove(producto);
    await context.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("EliminarProducto")
.WithOpenApi();

#endregion comandos



app.Run();



