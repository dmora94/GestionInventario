using GestionProductos.Dalc;
using GestionProductos.Modelos;

namespace GestionProductos.Endpoints;

public static class ProductoEndpointsComando
{
    public static void MapProductoEndpointsComando(this WebApplication @this)
    {
        var app = @this.MapGroup("/comandos");

        app.MapPost("/agregarProducto", (HttpContext httpContext, ProductoDalc productoDalc) =>
        {
            var producto = CrearProducto(httpContext);
            AsignarImagenAProducto(httpContext, producto);

            productoDalc.AgregarProductoAsync(producto).GetAwaiter().GetResult();
            return Results.Created($"/agregarProducto/{producto.Id}", producto);
        })
        .WithName("AgregarProducto")
        .WithOpenApi();

        app.MapPut("/actualizarProducto/{Id:int}", (int id, HttpContext httpContext, ProductoDalc productoDalc) =>
        {
            var producto = productoDalc.ObtenerProductoAsync(id).GetAwaiter().GetResult();

            if (producto == null)
                return Results.NotFound();

            ActualizarProducto(httpContext, producto);
            AsignarImagenAProducto(httpContext, producto);

            productoDalc.ActualizarProductoAsync(producto).GetAwaiter().GetResult();
            return Results.NoContent();
        })
        .WithName("ActualizarProducto")
        .WithOpenApi();

        app.MapDelete("/eliminarProducto/{Id:int}", (int id, ProductoDalc productoDalc) =>
            productoDalc.EliminarProductoAsync(id).GetAwaiter().GetResult()
                ? Results.NoContent()
                : Results.NotFound())
            .WithName("EliminarProducto")
            .WithOpenApi();
    }

    private static Producto CrearProducto(HttpContext httpContext)
    {
        var formCollection = httpContext.Request.ReadFormAsync().GetAwaiter().GetResult();
        var producto = new Producto(formCollection["Nombre"]!,
                                    formCollection["Descripcion"]!,
                                    formCollection["Categoria"]!,
                                    decimal.Parse(formCollection["Precio"]!),
                                    int.Parse(formCollection["Stock"]!));
        return producto;
    }

    private static void ActualizarProducto(HttpContext httpContext,
                                                  Producto producto)
    {
        var formCollection = httpContext.Request.ReadFormAsync().GetAwaiter().GetResult();
        producto.Nombre = formCollection["Nombre"]!;
        producto.Descripcion = formCollection["Descripcion"]!;
        producto.Categoria = formCollection["Categoria"]!;
        producto.Precio = decimal.Parse(formCollection["Precio"]!);
        producto.Stock = int.Parse(formCollection["Stock"]!);
    }

    private static void AsignarImagenAProducto(HttpContext httpContext,
                                               Producto producto)
    {
        if (httpContext.Request.Form.Files.Count == 0)
            return;

        using var ms = new MemoryStream();
        httpContext.Request.Form.Files[0].CopyToAsync(ms).GetAwaiter().GetResult();
        producto.Imagen = ms.ToArray();
    }
}
