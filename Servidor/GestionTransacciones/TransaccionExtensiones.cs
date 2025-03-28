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
}
