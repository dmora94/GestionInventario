namespace GestionTransacciones;

public static class TransaccionExtensiones
{
    public static List<TransaccionDto> ObtenerTransaccionDtos(this List<Transaccion> @this) =>
        @this
        .Select(x => new TransaccionDto(x.Id,
                                        x.IdProducto,
                                        x.Fecha,
                                        x.TipoTransaccion,
                                        x.Cantidad,
                                        x.PrecioUnitario,
                                        x.PrecioTotal,
                                        x.Detalle))
        .ToList();

    public static TransaccionDto ObtenerTransaccionDto(this Transaccion @this) =>
        new(@this.Id,
            @this.IdProducto,
            @this.Fecha,
            @this.TipoTransaccion,
            @this.Cantidad,
            @this.PrecioUnitario,
            @this.PrecioTotal,
            @this.Detalle);

    public static IQueryable<Transaccion> ConsultaPorIdProducto(
        this IQueryable<Transaccion> @this,
        int idProducto,
        int idTransaccion,
        bool ascendente) =>
          ascendente
          ? @this.Where(x => x.IdProducto == idProducto && x.Id >= idTransaccion)
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
            @this.Where(x => x.IdProducto == idProducto &&
                             x.Fecha == fecha &&
                             x.TipoTransaccion == tipoTransaccion);

        return
            ascendente
            ? consultaTransacciones.Where(x => x.Id >= idTransaccion)
            : consultaTransacciones.Where(x => x.Id <= idTransaccion);
    }
}
