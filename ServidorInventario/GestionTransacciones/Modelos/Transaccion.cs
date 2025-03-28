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
        IdProducto = idProducto;
        Fecha = fecha;
        TipoTransaccion = tipoTransaccion;
        Cantidad = cantidad;
        PrecioUnitario = precioUnitario;
        PrecioTotal = precioTotal;
        Detalle = detalle;
    }

    [Key]
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public string TipoTransaccion { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal PrecioTotal { get; set; }

    public string Detalle { get; set; }

}
