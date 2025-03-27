using GestionTransacciones.Dalc;
using GestionTransacciones.Modelos;

using System.Globalization;

namespace GestionTransacciones.Endpoints;

public static class TransaccionEndpointsConsulta
{
    public static void MapTransaccionEndpointsConsulta(this WebApplication @this)
    {
        var app = @this.MapGroup("/consultas");

        app.MapGet("/obtenerTransaccionesPorIdProducto", (HttpContext httpContext, TransaccionDalc transaccionDalc) =>
        {
            var formCollection = httpContext.Request.ReadFormAsync().GetAwaiter().GetResult();
            var transacciones = 
                transaccionDalc
                .ObtenerTransaccionesPorIdProductoAsync(int.Parse(formCollection["IdProducto"]!),
                                                        int.Parse(formCollection["IdTransaccion"]!),
                                                        bool.Parse(formCollection["Ascendente"]!),
                                                        int.Parse(formCollection["NumeroRegistro"]!))
                .GetAwaiter()
                .GetResult();

            return Results.Ok(transacciones.ObtenerTransaccionDtos());
        })
        .WithName("ObtenerTransaccionesPorIdProducto")
        .WithOpenApi();

        app.MapGet("/obtenerTransaccionesPorFiltros", (HttpContext httpContext, TransaccionDalc transaccionDalc) =>
        {
            var formCollection = httpContext.Request.ReadFormAsync().GetAwaiter().GetResult();
            var transacciones =
                transaccionDalc
                .ObtenerTransaccionesPorFiltrosAsync(int.Parse(formCollection["IdProducto"]!),
                                                     DateTime.Parse(formCollection["Fecha"]!),
                                                     formCollection["TipoTransaccion"]!,
                                                     int.Parse(formCollection["IdTransaccion"]!),
                                                     bool.Parse(formCollection["Ascendente"]!),
                                                     int.Parse(formCollection["NumeroRegistro"]!))
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
