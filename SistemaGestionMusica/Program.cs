using SistemaMusica.Gestores;
using SistemaMusica.Modelos;
using SistemaMusica.Servicios;

ServicioMusica servicioMusica = new ServicioMusica();
int k = 0;
Console.WriteLine("Bienvenido al Sistema de Música\n");
Console.WriteLine("-----Registo de Usuario------");
Console.WriteLine("Ingresa tu nombre:");
string nombreUsuario = Console.ReadLine() ?? "";
if (string.IsNullOrWhiteSpace(nombreUsuario))
    nombreUsuario = "Usuario";
servicioMusica.RegistrarUsuario(nombreUsuario);

Console.WriteLine($"\n---¡Bienvenido {nombreUsuario}!---");

Console.WriteLine("---Creación de Lista de Reproducción---");
Console.WriteLine("Ingresa el nombre de la lista de reproducción:");
string nombreLista = Console.ReadLine() ?? "";
if (string.IsNullOrWhiteSpace(nombreLista)) 
    nombreLista = "Mi Lista";
Usuario usuario = servicioMusica.BuscarUsuario(nombreUsuario);
usuario.CrearListaReproduccion(nombreLista);

while (k == 0)
{
    Console.WriteLine("\n---Menú Principal---");
    Console.WriteLine($"Usuario: {nombreUsuario}");
    Console.WriteLine($"Lista de Reproducción: {nombreLista}");
    Console.WriteLine("1. Buscar canciones para agregar a mi lista");
    Console.WriteLine("2. Ver mi lista de reproducción (ordenada por duración)");
    Console.WriteLine("3. Ver todas las canciones disponibles");
    Console.WriteLine("4. Crear nueva lista de reproducción");
    Console.WriteLine("5. Cambiar de lista actual");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");
    int opcion = int.Parse(Console.ReadLine() ?? "");
    GestorCanciones gestor = new GestorCanciones();
    // Agregar algunas canciones de ejemplo al gestor
    gestor.AgregarCancion(new Cancion("Feel It", "d4vd", 157));
    gestor.AgregarCancion(new Cancion("Blinding Lights", "The Weeknd", 200));
    gestor.AgregarCancion(new Cancion("I Really Want to Stay at Your House", "Rosa Walton", 246));
    gestor.AgregarCancion(new Cancion("Let It Happen", "Tame Impala", 469));
    gestor.AgregarCancion(new Cancion("Beauty and a Beat", "Justin Bieber", 228));
    gestor.AgregarCancion(new Cancion("No Surprises", "Radiohead", 229));
    gestor.AgregarCancion(new Cancion("Everlong", "Foo Fighters", 250));
    gestor.AgregarCancion(new Cancion("Mr. Brightside", "The Killers", 223));
    gestor.AgregarCancion(new Cancion("I Feel it Coming", "The Weeknd", 270));

    switch (opcion)
    {
        case 1:
            Console.WriteLine("Ingresa el nombre de la canción a buscar:");
            string nombreCancion = Console.ReadLine() ?? "";
            List<Cancion> cancionesEncontradas = gestor.BuscarPorNombre(nombreCancion);
            if (cancionesEncontradas.Count == 0)
            {
                Console.WriteLine("No se encontraron canciones con ese nombre.");
            }
            else
            {
                Console.WriteLine("Canciones encontradas:");
                for (int i = 0; i < cancionesEncontradas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {cancionesEncontradas[i].ToString()}");
                }
                Console.WriteLine("Ingresa el número de la canción que deseas agregar a tu lista de reproducción:");
                int numeroCancion = int.Parse(Console.ReadLine() ?? "");
                if (numeroCancion < 1 || numeroCancion > cancionesEncontradas.Count)
                {
                    throw new ArgumentOutOfRangeException("Número de canción inválido.");
                }
                else
                {
                    Cancion cancionSeleccionada = cancionesEncontradas[numeroCancion - 1];
                    usuario.AgregarCancionALista(nombreLista, cancionSeleccionada);
                    Console.WriteLine($"La canción '{cancionSeleccionada.Nombre}' ha sido agregada a tu lista de reproducción '{nombreLista}'.");
                }
            }
            break;
        case 2:
            if (usuario.ListasReproduccion.ContainsKey(nombreLista))
            {
                List<Cancion> listaActual = usuario.ListasReproduccion[nombreLista];
                if (listaActual.Count == 0)
                {
                    Console.WriteLine($"Tu lista de reproducción '{nombreLista}' está vacía.");
                    break;
                }
                else
                {
                    gestor.QuickSortPorDuracion(listaActual);
                    Console.WriteLine($"Lista de reproducción '{nombreLista}' ordenada por duración:");
                    foreach (Cancion cancion in listaActual)
                    {
                        Console.WriteLine(cancion.ToString());
                    }
                }
            }
            break;
        case 3:
            Console.WriteLine("Canciones disponibles:");
            gestor.MostrarCanciones();
            break;
        case 4:
            Console.WriteLine("Ingresa el nombre de la nueva lista de reproducción:");
            string nuevoNombreLista = Console.ReadLine() ?? "";
            usuario.CrearListaReproduccion(nuevoNombreLista);
            Console.WriteLine($"La lista de reproducción {nuevoNombreLista} fue creada con exito");
            break;
        case 5:
            Console.WriteLine("Ingresa el nombre de la lista de reproducción a cambiar:");
            string cambiarNombreLista = Console.ReadLine() ?? "";
            if (usuario.ListasReproduccion.ContainsKey(cambiarNombreLista))
            {
                nombreLista = cambiarNombreLista;
                Console.WriteLine($"Lista de reproducción actual cambiada a: {nombreLista}");
            }
            else
            {
                Console.WriteLine($"La lista de reproducción '{cambiarNombreLista}' no existe.");
            }
            break;
        case 6:
            k = 1;
            Console.WriteLine("Saliendo del sistema. ¡Hasta luego!");
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
}

