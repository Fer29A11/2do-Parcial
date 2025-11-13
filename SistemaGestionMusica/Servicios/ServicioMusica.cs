using SistemaMusica.Gestores;
using SistemaMusica.Modelos;
namespace SistemaMusica.Servicios;
public class ServicioMusica
{
    //Atributos
    public GestorCanciones Gestor {  get; set; }
    public List<Usuario> Usuarios { get; set; }

    //Constructor
    public ServicioMusica()
    {
        Gestor = new GestorCanciones();
        Usuarios = new List<Usuario>();
    }

    //Métodos
    public void RegistrarUsuario(string nombre)
    {
        Usuario usuario = new Usuario(nombre);
        Usuarios.Add (usuario);
        Console.WriteLine($"Se ha añadido a {nombre} a la lista de usuarios.");
    }

    public Usuario BuscarUsuario(string nombre)
    {
        Usuario usuario = Usuarios.FirstOrDefault(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (usuario == null)
        {
            Console.WriteLine($"El usuario: {nombre} no existe.");
            return null;
        }
        else
            return usuario;
    }

}
