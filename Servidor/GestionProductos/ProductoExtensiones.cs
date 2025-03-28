using System.Linq.Expressions;

namespace GestionProductos;

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

    public static IQueryable<Producto> ConsultaPorId(this IQueryable<Producto> @this,
                                                     int id,
                                                     bool ascendente) =>
       ascendente
       ? @this.Where(x => x.Id >= id)
       : @this.Where(x => x.Id <= id);
    public static IQueryable<Producto> ConsultaPorNombre(this IQueryable<Producto> @this,
                                                         string nombre,
                                                         int id, 
                                                         bool ascendente) =>
        ascendente
        ? @this.Where(x => x.Nombre.StartsWith(nombre) && x.Id >= id)
        : @this.Where(x => x.Nombre.StartsWith(nombre) && x.Id <= id);


    
}
