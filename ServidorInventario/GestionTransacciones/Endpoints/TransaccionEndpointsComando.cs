using GestionTransacciones.Dalc;
using GestionTransacciones.Modelos;

using Microsoft.AspNetCore.Mvc;

namespace GestionTransacciones.Endpoints;

public static class TransaccionEndpointsComando
{
    public static void MapTransaccionEndpointsComando(this WebApplication @this)
    {
        var app = @this.MapGroup("/comandos");

        app.MapPost("/agregarTransaccion", ([FromBody] AgregarTransaccion agregarTransaccion, TransaccionDalc transaccionDalc) =>
        {
            var transaccion = CrearTransaccion(agregarTransaccion);

            transaccionDalc.AgregarTransaccionAsync(transaccion).GetAwaiter().GetResult();
            return Results.Created($"/agregarTransaccion/{transaccion.Id}", transaccion);
        })
        .WithName("AgregarTransaccion")
        .WithOpenApi();

        app.MapPost("/actualizarTransaccion", ([FromBody] ActualizarTransaccion actualizarTransaccion, TransaccionDalc transaccionDalc) =>
        {
            var transaccion = transaccionDalc.ObtenerTransaccionAsync(actualizarTransaccion.IdTransaccion).GetAwaiter().GetResult();

            if (transaccion == null)
                return Results.NotFound();

            ActualizarTransaccion(actualizarTransaccion, transaccion);

            transaccionDalc.ActualizarTransaccionAsync(transaccion).GetAwaiter().GetResult();
            return Results.NoContent();
        })
        .WithName("ActualizarTransaccion")
        .WithOpenApi();

        app.MapPost("/eliminarTransaccion", ([FromBody] EliminarTransaccion eliminarTransaccion, TransaccionDalc transaccionDalc) =>
            transaccionDalc.EliminarTransaccionAsync(eliminarTransaccion.IdTransaccion).GetAwaiter().GetResult()
                ? Results.NoContent()
                : Results.NotFound())
            .WithName("EliminarTransaccion")
            .WithOpenApi();
    }

    private static Transaccion CrearTransaccion(AgregarTransaccion agregarTransaccion)
    {
        var transaccion = new Transaccion(agregarTransaccion.IdProducto,
                                          agregarTransaccion.Fecha,
                                          agregarTransaccion.TipoTransaccion,
                                          agregarTransaccion.Cantidad,
                                          agregarTransaccion.PrecioUnitario,
                                          agregarTransaccion.PrecioTotal,
                                          agregarTransaccion.Detalle);
        return transaccion;
    }

    private static void ActualizarTransaccion(ActualizarTransaccion actualizar,
                                              Transaccion transaccion)
    {
        transaccion.Cantidad = actualizar.Cantidad;
        transaccion.PrecioUnitario = actualizar.PrecioUnitario;
        transaccion.PrecioTotal = actualizar.PrecioTotal;
        transaccion.Detalle = actualizar.Detalle;
    }

    
}
