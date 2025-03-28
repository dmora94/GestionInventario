using GestionTransacciones.Modelos;

using System.Linq.Expressions;

namespace GestionTransacciones.Dalc;

public static class TransaccionDalcExtensiones
{
    public static IQueryable<Transaccion> ConsultaPorIdProducto(
        this IQueryable<Transaccion> @this,
        int idProducto,
        int idTransaccion,
        bool ascendente) =>
          ascendente
          ? @this.Where(x => x.IdProducto  == idProducto && x.Id >= idTransaccion)
          : @this.Where(x => x.IdProducto == idProducto && x.Id <= idTransaccion);

    public static IQueryable<Transaccion> ConsultaPorFiltros(
        this IQueryable<Transaccion> @this,
        int idProducto,
        DateTime fecha,
        string tipoTransaccion,
        int idTransaccion,
        bool ascendente)
    {
        var consultaTransacciones =
            @this.Where(x => x.IdProducto  == idProducto &&
                             x.Fecha == fecha &&
                             x.TipoTransaccion  == tipoTransaccion);

        return
            ascendente
            ? consultaTransacciones.Where(x => x.Id >= idTransaccion)
            : consultaTransacciones.Where(x => x.Id <= idTransaccion);
    }

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
