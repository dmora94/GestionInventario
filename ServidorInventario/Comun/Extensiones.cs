using System.Linq.Expressions;

namespace Comun;

public static class Extensiones
{
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
