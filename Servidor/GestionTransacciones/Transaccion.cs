using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTransacciones;

[Table("TRANSACCIONES", Schema = "INVENTARIO")]
public class Transaccion
{
    public Transaccion()
    {
    }

    public Transaccion(int idProducto,
                       DateTime fecha,
                       string tipoTransaccion,
                       int cantidad,
                       decimal precioUnitario,
                       decimal precioTotal,
                       string detalle)
    {
        IdProducto = idProducto;
        Fecha = fecha;
        TipoTransaccion = tipoTransaccion;
        Cantidad = cantidad;
        PrecioUnitario = precioUnitario;
        PrecioTotal = precioTotal;
        Detalle = detalle;
    }

    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("FECHA")]
    public DateTime Fecha { get; set; }

    [Column("TIPOTRANSACCION")]
    public string TipoTransaccion { get; set; }

    [Column("IDPRODUCTO")]
    public int IdProducto { get; set; }

    [Column("CANTIDAD")]
    public int Cantidad { get; set; }

    [Column("PRECIOUNITARIO")]
    public decimal PrecioUnitario { get; set; }

    [Column("PRECIOTOTAL")]
    public decimal PrecioTotal { get; set; }

    [Column("DETALLE")]
    public string Detalle { get; set; }
}
