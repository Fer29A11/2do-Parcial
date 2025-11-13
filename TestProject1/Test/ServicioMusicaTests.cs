using SistemaMusica.Gestores;
using SistemaMusica.Modelos;
using SistemaMusica.Servicios;

namespace SistemaMusica.Test
{
    public class ServicioMusicaTests
    {
        [Fact]
        public void RegistrarUsuario_DebeRegistrarUsuarioCorrectamente()
        {
            // Arrange
            ServicioMusica servicio = new ServicioMusica();
            string nombreUsuario = "Ana";
            // Act
            servicio.RegistrarUsuario(nombreUsuario);
            // Assert
            Assert.Contains("Ana", servicio.Usuarios[0].Nombre);
        }

        [Fact]
        public void BuscarUsuario_DebeRetornarUsuarioCorrectamente()
        {
            // Arrange
            ServicioMusica servicio = new ServicioMusica();
            string nombreUsuario = "Luis";
            servicio.RegistrarUsuario(nombreUsuario);
            // Act
            Usuario usuarioEncontrado = servicio.BuscarUsuario(nombreUsuario);
            // Assert
            Assert.Equal("Luis", usuarioEncontrado.Nombre);
        }

        [Fact]
        public void BuscarUsuario_NoExisteDebeRetornarNull()
        {
            // Arrange
            ServicioMusica servicio = new ServicioMusica();
            string nombreUsuario = "Carlos";
            // Act
            servicio.BuscarUsuario(nombreUsuario);
            // Assert
            Assert.Null(nombreUsuario);
        }
    }
}
