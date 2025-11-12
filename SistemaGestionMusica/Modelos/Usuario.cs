namespace SistemaMusica.Modelos;
// Clase para usuarios
public class Usuario
{
    // Atributos de la clase Usuario
    public string Nombre { get; set; }
    public Dictionary<string, List<Cancion>> ListasReproduccion { get; set; } // Diccionario para listas de reproducción, clave: nombre de la lista, valor: lista de canciones

    //Constructor de la clase Usuario
    public Usuario(string nombre)
    {
        Nombre = nombre;
        ListasReproduccion = new Dictionary<string, List<Cancion>>();
    }

    // Métodos
    public void CrearListaReproduccion(string nombre)
    {
        if (!ListasReproduccion.ContainsKey(nombre))
        {
            ListasReproduccion[nombre] = new List<Cancion>();
            Console.WriteLine($"La Lista de Reproducción: {nombre} ha sido creada con éxito");
        }
        else
        {
            Console.WriteLine($"La Lista de Reproducción: {nombre} ya existe");
        }
    }

    public void AgregarCancionALista(string nombreLista, Cancion cancion)
    {
        if (ListasReproduccion.ContainsKey(nombreLista))
        {
            ListasReproduccion[nombreLista].Add(cancion);
            Console.WriteLine($"La canción: {cancion.Nombre} ha sido agregada a la lista: {nombreLista}");
        }
        else
        {
            Console.WriteLine($"La Lista de Reproducción: {nombreLista} no existe");
        }
    }

    public void MostrarListasReproduccion()
    {
        foreach (KeyValuePair<string, List<Cancion>> lista in ListasReproduccion)
        {
            Console.WriteLine($"Lista: {lista.Key}");
            foreach (Cancion cancion in lista.Value)
            {
                Console.WriteLine(cancion.ToString());
            }
        }
    }
}