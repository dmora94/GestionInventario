using GestionProductos.Modelos;

using System.Linq.Expressions;

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


    public static IOrderedQueryable<T> OrderBy<T, TKey>(this IQueryable<T> @this,
                                                   Expression<Func<T, TKey>> propiedad,
                                                   bool esAscendente = true)
    {
        if (esAscendente)
        {
            return @this.OrderBy(propiedad);
        }

        return @this.OrderByDescending(propiedad);
    }

    public static IEnumerable<T> Take<T>(this IEnumerable<T> @this,
                                         int numeroRegistros)
    {
        if (numeroRegistros == 0)
        {
            return @this;
        }

        return @this.Take(numeroRegistros);
    }

    public static IList<T> Reverse<T>(this IEnumerable<T> @this,
                                      bool ascendente = true)
    {
        if (!ascendente)
        {
            return @this.Reverse().ToList();
        }

        return @this.ToList();
    }
    
}
