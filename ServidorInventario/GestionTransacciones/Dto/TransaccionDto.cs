namespace GestionTransacciones.Dto;

public record TransaccionDto(
    int Id,
    int IdProducto,
    DateTime Fecha,
    string TipoTransaccion,
    int Cantidad,
    decimal PrecioUnitario,
    decimal PrecioTotal,
    string Detalle);
