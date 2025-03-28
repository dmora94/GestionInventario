using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionProductos;

[Table("PRODUCTOS", Schema = "INVENTARIO")]
public class Producto
{
    public Producto()
    {
    }

    public Producto(string nombre,
                    string descripcion,
                    string categoria,
                    decimal precio,
                    int stock,
                    byte[]? imagen = null)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Categoria = categoria;
        Imagen = imagen;
        Precio = precio;
        Stock = stock;
    }

    [Key]
    [Column("ID")]
    public int Id { get; private set; }

    [Column("NOMBRE")]
    public string Nombre { get; set; }

    [Column("DESCRIPCION")]
    public string Descripcion { get; set; }

    [Column("CATEGORIA")]
    public string Categoria { get; set; }

    [Column("IMAGEN")]
    public byte[]? Imagen { get; set; }

    [Column("PRECIO")]
    public decimal Precio { get; set; }

    [Column("STOCK")]
    public int Stock { get; set; }





}
