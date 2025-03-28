namespace GestionTransacciones;

public static class TransaccionUtilidades
{
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
