namespace GestionTransacciones;

public class ObtenerTransaccionesPorIdProducto
{
    public int IdProducto { get; set; }
    public int IdTransaccion { get; set; }
    public bool Ascendente { get; set; }
    public int NumeroRegistros { get; set; }
}

public class ObtenerTransaccionesPorFiltros
{
    public int IdProducto { get; set; }
    public DateTime Fecha { get; set; }
    public string TipoTransaccion { get; set; }
    public int IdTransaccion { get; set; }
    public bool Ascendente { get; set; }
    public int NumeroRegistros { get; set; }
}

public class ObtenerTransaccion
{
    public int IdTransaccion { get; set; }
}
public class AgregarTransaccion
{
    public int IdProducto { get; set; }
    public DateTime Fecha { get; set; }
    public string TipoTransaccion { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal PrecioTotal { get; set; }
    public string Detalle { get; set; }

}


public class ActualizarTransaccion
{
    public int IdTransaccion { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal PrecioTotal { get; set; }
    public string Detalle { get; set; }
}

public class EliminarTransaccion
{
    public int IdTransaccion { get; set; }
}