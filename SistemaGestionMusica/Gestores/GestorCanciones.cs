using SistemaMusica.Modelos;
namespace SistemaMusica.Gestores;
public class GestorCanciones
{
    //Atributos
    List<Cancion> CancionesDisponibles { get; set; }

    public GestorCanciones()
    {
        CancionesDisponibles = new List<Cancion>();
    }

    //Métodos
    public void AgregarCancion(Cancion cancion)
    {
        CancionesDisponibles.Add(cancion);
    }

    public List<Cancion> BuscarPorNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre de la canción no puede estar vacío.");
        }
        
        List<Cancion> CancionesEncontradas = new List<Cancion>();
        foreach (var cancion in CancionesDisponibles)
        {
            if (cancion.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
            {
                CancionesEncontradas.Add(cancion);
            }
        }
        return CancionesEncontradas;
    }

    //Ordenar las canciones por duración usando QuickSort
    public void QuickSortPorDuracion(List<Cancion> canciones)
    {
        if (canciones.Count <= 1)
            return;

        //1.- Seleccionar pivote (último elemento)
        Cancion pivote = canciones[canciones.Count - 1];

        //2.- Reorganizar lista con elementos menores a la izquierda y mayores a la derecha
        var menores = new List<Cancion>();
        var mayores = new List<Cancion>();
        for (int i = 0; i < canciones.Count - 1; i++)
        {
            if (canciones[i].Duracion < pivote.Duracion)
            {
                menores.Add(canciones[i]);
            }
            else
            {
                mayores.Add(canciones[i]);
            }
        }

        //3.- Recursivamente aplica el algoritmo en las sublistas formadas
        QuickSortPorDuracion(menores);
        QuickSortPorDuracion(mayores);

        // 4.- Combinar sublistas y pivote en la lista ordenada
        canciones.Clear();
        canciones.AddRange(menores);
        canciones.Add(pivote);
        canciones.AddRange(mayores);
    }

    //Mostrar todas las canciones
    public void MostrarCanciones()
    {
        foreach (Cancion cancion in CancionesDisponibles)
        {
            Console.WriteLine(cancion.ToString());
        }
    }
}

