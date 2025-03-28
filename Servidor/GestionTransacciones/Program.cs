using GestionTransacciones;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TransaccionDbContext>(options => options.UseSqlServer(connectionString));
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

app.MapPost("/consultas/obtenerTransaccionesPorIdProducto", async ([FromBody] ObtenerTransaccionesPorIdProducto obtenerTransaccionesPorIdProducto,
                                                         TransaccionDbContext context) =>
{
    await Task.CompletedTask;

    var transacciones =
        context
        .Transacciones
        .AsQueryable()
        .ConsultaPorIdProducto(obtenerTransaccionesPorIdProducto.IdProducto,
                               obtenerTransaccionesPorIdProducto.IdTransaccion,
                               obtenerTransaccionesPorIdProducto.Ascendente)
        .AsEnumerable();

    var transaccionesOrdenadas =
        obtenerTransaccionesPorIdProducto.Ascendente
        ? transacciones.OrderBy(x => x.Id)
        : transacciones.OrderByDescending(x => x.Id);

    var transaccionesAMostrar = 
        transaccionesOrdenadas
        .Take(obtenerTransaccionesPorIdProducto.NumeroRegistros)
        .ReversePorAscendente(obtenerTransaccionesPorIdProducto.Ascendente)
        .ToList();

    return Results.Ok(transaccionesAMostrar.ObtenerTransaccionDtos());
})
.WithName("ObtenerTransaccionesPorIdProducto")
.WithOpenApi();

app.MapPost("/consultas/obtenerTransaccionesPorFiltros", async ([FromBody] ObtenerTransaccionesPorFiltros obtenerTransaccionesPorFiltros,
                                                       TransaccionDbContext context) =>
{
    await Task.CompletedTask;

    var transacciones =
        context
        .Transacciones
        .AsQueryable()
        .ConsultaPorFiltros(obtenerTransaccionesPorFiltros.IdProducto,
                            obtenerTransaccionesPorFiltros.Fecha,
                            obtenerTransaccionesPorFiltros.TipoTransaccion,
                            obtenerTransaccionesPorFiltros.IdTransaccion,
                            obtenerTransaccionesPorFiltros.Ascendente);

    var transaccionesOrdenadas =
        obtenerTransaccionesPorFiltros.Ascendente
        ? transacciones.OrderBy(x => x.Id)
        : transacciones.OrderByDescending(x => x.Id);

    var transaccionesAMostrar =
        transaccionesOrdenadas
        .Take(obtenerTransaccionesPorFiltros.NumeroRegistros)
        .ReversePorAscendente(obtenerTransaccionesPorFiltros.Ascendente)
        .ToList();

    return Results.Ok(transaccionesAMostrar.ObtenerTransaccionDtos());
})
.WithName("ObtenerTransaccionesPorFiltros")
.WithOpenApi();

app.MapPost("/consultas/obtenerTransaccion", async ([FromBody] ObtenerTransaccion obtenerTransaccion,
                                          TransaccionDbContext context) =>
{
    var transaccion = await context.Transacciones.FindAsync(obtenerTransaccion.IdTransaccion);

    return transaccion is not null
           ? Results.Ok(transaccion.ObtenerTransaccionDto())
           : Results.NotFound(default);
})
.WithName("ObtenerTransaccion")
.WithOpenApi();

#endregion consultas

#region comandos

app.MapPost("/comandos/agregarTransaccion", async ([FromBody] AgregarTransaccion agregarTransaccion,
                                                   TransaccionDbContext context) =>
{
    var transaccion = new Transaccion(agregarTransaccion.IdProducto,
                                      agregarTransaccion.Fecha,
                                      agregarTransaccion.TipoTransaccion,
                                      agregarTransaccion.Cantidad,
                                      agregarTransaccion.PrecioUnitario,
                                      agregarTransaccion.PrecioTotal,
                                      agregarTransaccion.Detalle);

    context.Transacciones.Add(transaccion);
    await context.SaveChangesAsync();
    
    return Results.Ok(transaccion.Id);
})
.WithName("AgregarTransaccion")
.WithOpenApi();

app.MapPost("/comandos/actualizarTransaccion", async ([FromBody] ActualizarTransaccion actualizarTransaccion,
                                                      TransaccionDbContext context) =>
{
    var transaccion = await context.Transacciones.FindAsync(actualizarTransaccion.IdTransaccion);

    if (transaccion == null)
        return Results.NotFound();

    transaccion.Cantidad = actualizarTransaccion.Cantidad;
    transaccion.PrecioUnitario = actualizarTransaccion.PrecioUnitario;
    transaccion.PrecioTotal = actualizarTransaccion.PrecioTotal;
    transaccion.Detalle = actualizarTransaccion.Detalle;

    context.Transacciones.Update(transaccion);
    await context.SaveChangesAsync();
    
    return Results.NoContent();
})
.WithName("ActualizarTransaccion")
.WithOpenApi();

app.MapPost("/comandos/eliminarTransaccion", async ([FromBody] EliminarTransaccion eliminarTransaccion,
                                                    TransaccionDbContext context)=>
{
    var transaccion = await context.Transacciones.FindAsync(eliminarTransaccion.IdTransaccion);
    if (transaccion == null)
        return Results.NotFound();

    context.Transacciones.Remove(transaccion);
    await context.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("EliminarTransaccion")
.WithOpenApi();

#endregion comandos


app.Run();

