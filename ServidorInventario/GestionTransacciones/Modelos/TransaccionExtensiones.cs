using GestionTransacciones.Dto;

using System.Runtime.CompilerServices;

namespace GestionTransacciones.Modelos;

public static class TransaccionExtensiones
{
    public static List<TransaccionDto> ObtenerTransaccionDtos(this List<Transaccion> @this) =>
        @this
        .Select(x => new TransaccionDto(x.ID,
                                        x.IDPRODUCTO,
                                        x.FECHA,
                                        x.TIPOTRANSACCION,
                                        x.CANTIDAD,
                                        x.PRECIOUNITARIO,
                                        x.PRECIOTOTAL,
                                        x.DETALLE))
        .ToList();

    public static TransaccionDto ObtenerTransaccionDto(this Transaccion @this) =>
        new(@this.ID,
            @this.IDPRODUCTO ,
            @this.FECHA,
            @this.TIPOTRANSACCION ,
            @this.CANTIDAD,
            @this.PRECIOUNITARIO,
            @this.PRECIOTOTAL,
            @this.DETALLE);
}
