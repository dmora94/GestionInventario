using GestionTransacciones.Dalc;
using GestionTransacciones.Modelos;

using System.Globalization;

namespace GestionTransacciones.Endpoints;

public static class TransaccionEndpointsConsulta
{
    public static void MapTransaccionEndpointsConsulta(this WebApplication @this)
    {
        var app = @this.MapGroup("/consultas");

        app.MapGet("/obtenerTransaccionesPorIdProducto", (ObtenerTransaccionesPorIdProducto obtenerTransaccionesPorIdProducto, TransaccionDalc transaccionDalc) =>
        {
            var transacciones = 
                transaccionDalc
                .ObtenerTransaccionesPorIdProductoAsync(obtenerTransaccionesPorIdProducto.IdProducto,
                                                        obtenerTransaccionesPorIdProducto.IdTransaccion,
                                                        obtenerTransaccionesPorIdProducto.Ascendente,
                                                        obtenerTransaccionesPorIdProducto.NumeroRegistros)
                .GetAwaiter()
                .GetResult();

            return Results.Ok(transacciones.ObtenerTransaccionDtos());
        })
        .WithName("ObtenerTransaccionesPorIdProducto")
        .WithOpenApi();

        app.MapGet("/obtenerTransaccionesPorFiltros", (ObtenerTransaccionesPorFiltros obtenerTransaccionesPorFiltros,  TransaccionDalc transaccionDalc) =>
        {
            var transacciones =
                transaccionDalc
                .ObtenerTransaccionesPorFiltrosAsync(obtenerTransaccionesPorFiltros.IdProducto,
                                                     obtenerTransaccionesPorFiltros.Fecha,
                                                     obtenerTransaccionesPorFiltros.TipoTransaccion,
                                                     obtenerTransaccionesPorFiltros.IdTransaccion,
                                                     obtenerTransaccionesPorFiltros.Ascendente,
                                                     obtenerTransaccionesPorFiltros.NumeroRegistros)
                .GetAwaiter()
                .GetResult();

            return Results.Ok(transacciones.ObtenerTransaccionDtos());
        })
       .WithName("ObtenerTransaccionesPorFiltros")
       .WithOpenApi();

        app.MapGet("/obtenerTransaccion/{Id:int}", (int id, TransaccionDalc transaccionDalc) =>
        {
            var transaccion = transaccionDalc.ObtenerTransaccionAsync(id).GetAwaiter().GetResult();

            return transaccion is not null
                   ? Results.Ok(transaccion.ObtenerTransaccionDto())
                   : Results.NotFound(default);
        })
       .WithName("ObtenerTransaccion")
       .WithOpenApi();
    }

}
