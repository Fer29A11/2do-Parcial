using SistemaMusica.Gestores;
using SistemaMusica.Modelos;
namespace SistemaGestionMusica.Servicios;
internal class ServicioMusica
{
    //Atributos
    GestorCanciones Gestor {  get; set; }
    List<Usuario> Usuarios { get; set; }

    //Métodos
    public void RegistrarUsuario(string nombre)
    {
        Usuario usuario = new Usuario(nombre);
        Usuarios.Add (usuario);
        Console.WriteLine($"Se ha añadido a {nombre} a la lista de usuarios.");
    }

    public void BuscarUsuario(string nombre)
    {
        var usuario = Usuarios.FirstOrDefault(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (usuario == null)
        {
            throw new Exception($"No se encontró al usuario {nombre}");
        }
    }

}
