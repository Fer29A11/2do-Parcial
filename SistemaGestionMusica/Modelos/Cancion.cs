
namespace SsitemaMusica.Modelos;
// Clase para canciones
public class Cancion
{
    // Atributos de la clase Cancion
    public string Nombre { get; set; }
    public string Artista { get; set; }
    public int Duracion { get; set; } // En segundos   

    // Constructor
    public Cancion(string nombre, string artista, int duracion)
    {
        Nombre = nombre;
        Artista = artista;
        Duracion = duracion;
    }

    // Métodos
    public override string ToString()
    {
        int minutos = Duracion / 60;
        int segundos = Duracion % 60;
        return $"{Nombre} - {Artista} ({minutos}:{segundos})";
    }
}
