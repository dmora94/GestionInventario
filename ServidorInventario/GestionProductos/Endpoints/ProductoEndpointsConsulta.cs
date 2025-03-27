using GestionProductos.Dalc;
using GestionProductos.Modelos;
namespace GestionProductos.Endpoints;

public static class ProductoEndpointsConsulta
{
    public static void MapProductoEndpointsConsulta(this WebApplication @this)
    {
        var app = @this.MapGroup("/consultas");

        app.MapGet("/obtenerProductos", (ProductoDalc productoDalc) =>
        {
            var productos = productoDalc.ObtenerProductosAsync().GetAwaiter().GetResult();
            return Results.Ok(productos.ObtenerProductoDtos());
        })
        .WithName("ObtenerProductos")
        .WithOpenApi();

        app.MapGet("/obtenerProductosPorId", (ObtenerProductosPorId obtenerProductosPorId, ProductoDalc productoDalc) =>
        {
            var productos = productoDalc
                            .ObtenerProductosPorIdAsync(obtenerProductosPorId.Id,
                                                        obtenerProductosPorId.Ascendente,
                                                        obtenerProductosPorId.NumeroRegistros)
                            .GetAwaiter()
                            .GetResult();

            return Results.Ok(productos.ObtenerProductoDtos());
        })
        .WithName("ObtenerProductosPorId")
        .WithOpenApi();

        app.MapGet("/obtenerProductosPorNombre", (ObtenerProductosPorNombre obtenerProductosPorNombre, ProductoDalc productoDalc) =>
        {
            var productos = productoDalc
                            .ObtenerProductosPorNombreAsync(obtenerProductosPorNombre.Nombre,
                                                            obtenerProductosPorNombre.Ascendente,
                                                            obtenerProductosPorNombre.NumeroRegistros)
                            .GetAwaiter()
                            .GetResult();

            return Results.Ok(productos.ObtenerProductoDtos());
        })
        .WithName("ObtenerProductosPorNombre")
        .WithOpenApi();

        app.MapGet("/obtenerProducto/{Id:int}", (int id, ProductoDalc productoDalc) =>
        {
            var producto = productoDalc.ObtenerProductoAsync(id).GetAwaiter().GetResult();

            return producto is not null
                   ? Results.Ok(producto.ObtenerProductoDto())
                   : Results.NotFound(default);
        })
       .WithName("ObtenerProducto")
       .WithOpenApi();

        app.MapGet("/validarInventario", (ValidarInventario validarInventario, ProductoDalc productoDalc) =>
        {
            var resultado = productoDalc
                            .ValidarInventarioAsync(validarInventario.IdProducto,
                                                    validarInventario.StockDisminuir)
                            .GetAwaiter()
                            .GetResult();

            return Results.Ok(resultado);
        })
       .WithName("ValidarInventario")
       .WithOpenApi();

        
    }
}
