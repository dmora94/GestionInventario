using GestionProductos.Modelos;

namespace GestionProductos.Dalc;

public static class ProductoDalcExtensiones
{

    public static IQueryable<Producto> ConsultaPorId(this IQueryable<Producto> @this,
                                                     int id,
                                                     bool ascendente) =>
       ascendente
       ? @this.Where(x => x.Id >= id)
       : @this.Where(x => x.Id <= id);
    public static IQueryable<Producto> ConsultaPorNombre(this IQueryable<Producto> @this,
                                                         string nombre,
                                                         bool ascendente) =>
        ascendente
        ? @this.Where(x => x.Nombre.CompareTo(nombre) >= 0)
        : @this.Where(x => x.Nombre.CompareTo(nombre) <= 0);



}
