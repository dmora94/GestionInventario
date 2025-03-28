using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTransacciones.Modelos;

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
        IDPRODUCTO = idProducto;
        FECHA = fecha;
        TIPOTRANSACCION = tipoTransaccion;
        CANTIDAD = cantidad;
        PRECIOUNITARIO = precioUnitario;
        PRECIOTOTAL = precioTotal;
        DETALLE = detalle;
    }

    [Key]
    public int ID { get; set; }

    public DateTime FECHA { get; set; }

    public string TIPOTRANSACCION { get; set; }

    public int IDPRODUCTO { get; set; }

    public int CANTIDAD { get; set; }

    public decimal PRECIOUNITARIO { get; set; }

    public decimal PRECIOTOTAL { get; set; }

    public string DETALLE { get; set; }

}
