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

        app.MapGet("/obtenerProducobtenerProductosPorNombretosPorId", (HttpContext httpContext, ProductoDalc productoDalc) =>
        {
            var formCollection = httpContext.Request.ReadFormAsync().GetAwaiter().GetResult();
            var productos = productoDalc
                            .ObtenerProductosPorIdAsync(int.Parse(formCollection["Id"]!),
                                                        bool.Parse(formCollection["Ascendente"]!),
                                                        int.Parse(formCollection["NumeroRegistros"]!))
                            .GetAwaiter()
                            .GetResult();

            return Results.Ok(productos.ObtenerProductoDtos());
        })
        .WithName("ObtenerProductosPorId")
        .WithOpenApi();

        app.MapGet("/obtenerProductosPorNombre", (HttpContext httpContext, ProductoDalc productoDalc) =>
        {
            var formCollection = httpContext.Request.ReadFormAsync().GetAwaiter().GetResult();
            var productos = productoDalc
                            .ObtenerProductosPorNombreAsync(formCollection["Nombre"]!,
                                                            bool.Parse(formCollection["Ascendente"]!),
                                                            int.Parse(formCollection["NumeroRegistros"]!))
                            .GetAwaiter()
                            .GetResult();

            return Results.Ok(productos.ObtenerProductoDtos());
        })
        .WithName("ObtenerProductosPorNombre")
        .WithOpenApi();

        app.MapGet("/validarInventario", (HttpContext httpContext, ProductoDalc productoDalc) =>
        {
            var formCollection = httpContext.Request.ReadFormAsync().GetAwaiter().GetResult();
            var resultado = productoDalc
                            .ValidarInventarioAsync(int.Parse(formCollection["IdProducto"]!),
                                                    int.Parse(formCollection["StockDisminuir"]!))
                            .GetAwaiter()
                            .GetResult();

            return Results.Ok(resultado);
        })
       .WithName("ValidarInventario")
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
    }
}
