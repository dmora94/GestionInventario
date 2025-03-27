using GestionProductos.Dtos;

namespace GestionProductos.Modelos;

public static class ProductoExtensiones
{
    public static List<ProductoDto> ObtenerProductoDtos(this List<Producto> @this) =>
       @this
       .Select(x => new ProductoDto(x.Id,
                                    x.Nombre,
                                    x.Descripcion,
                                    x.Categoria,
                                    x.Imagen,
                                    x.Precio,
                                    x.Stock))
       .ToList();

    public static ProductoDto ObtenerProductoDto(this Producto @this) =>
        new(@this.Id,
             @this.Nombre,
             @this.Descripcion,
             @this.Categoria,
             @this.Imagen,
             @this.Precio,
             @this.Stock);
}
