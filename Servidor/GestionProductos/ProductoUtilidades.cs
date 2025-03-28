namespace GestionProductos;

public static class ProductoUtilidades
{
    public static byte[]? ConvertirImagen(string imagenBase64) =>
        imagenBase64 is not null && string.IsNullOrEmpty(imagenBase64)
        ? Convert.FromBase64String(imagenBase64)
        : null;




    public static IList<T> ReversePorAscendente<T>(this IEnumerable<T> @this,
                                                   bool ascendente)
    {
        if (!ascendente)
        {
            return @this.Reverse().ToList();
        }

        return @this.ToList();
    }
}
