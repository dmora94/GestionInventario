using GestionTransacciones.Dalc;
using GestionTransacciones.Modelos;

namespace GestionTransacciones.Endpoints;

public static class TransaccionEndpointsComando
{
    public static void MapTransaccionEndpointsComando(this WebApplication @this)
    {
        var app = @this.MapGroup("/comandos");

        app.MapPost("/agregarTransaccion", (HttpContext httpContext, TransaccionDalc transaccionDalc) =>
        {
            var producto = CrearTransaccion(httpContext);

            transaccionDalc.AgregarTransaccionAsync(producto).GetAwaiter().GetResult();
            return Results.Created($"/agregarTransaccion/{producto.Id}", producto);
        })
        .WithName("AgregarTransaccion")
        .WithOpenApi();

        app.MapPut("/actualizarTransaccion/{Id:int}", (int id, HttpContext httpContext, TransaccionDalc transaccionDalc) =>
        {
            var transaccion = transaccionDalc.ObtenerTransaccionAsync(id).GetAwaiter().GetResult();

            if (transaccion == null)
                return Results.NotFound();

            ActualizarTransaccion(httpContext, transaccion);

            transaccionDalc.ActualizarTransaccionAsync(transaccion).GetAwaiter().GetResult();
            return Results.NoContent();
        })
        .WithName("ActualizarTransaccion")
        .WithOpenApi();

        app.MapDelete("/eliminarTransaccion/{Id:int}", (int id, TransaccionDalc transaccionDalc) =>
            transaccionDalc.EliminarTransaccionAsync(id).GetAwaiter().GetResult()
                ? Results.NoContent()
                : Results.NotFound())
            .WithName("EliminarTransaccion")
            .WithOpenApi();
    }

    private static Transaccion CrearTransaccion(HttpContext httpContext)
    {
        var formCollection = httpContext.Request.ReadFormAsync().GetAwaiter().GetResult();
        var transaccion = new Transaccion(int.Parse(formCollection["IdProducto"]!),
                                          DateTime.Parse(formCollection["Fecha"]!),
                                          formCollection["TipoTransaccion"]!,
                                          int.Parse(formCollection["Cantidad"]!),
                                          decimal.Parse(formCollection["PrecioUnitario"]!),
                                          decimal.Parse(formCollection["PrecioTotal"]!),
                                          formCollection["Detalle"]!);
        return transaccion;
    }

    private static void ActualizarTransaccion(HttpContext httpContext,
                                              Transaccion transaccion)
    {
        var formCollection = httpContext.Request.ReadFormAsync().GetAwaiter().GetResult();
        transaccion.Cantidad = int.Parse(formCollection["Cantidad"]!);       
        transaccion.PrecioUnitario =decimal.Parse( formCollection["PrecioUnitario"]!);
        transaccion.PrecioTotal = decimal.Parse( formCollection["PrecioTotal"]!);
        transaccion.Detalle= formCollection["Detalle"]!;
    }

    
}
