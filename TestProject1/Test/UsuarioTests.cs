using SistemaMusica.Gestores;
using SistemaMusica.Modelos;
using SistemaMusica.Servicios;

namespace SistemaMusica.Test
{
    public class PruebaUsuarioTests
    {
        [Fact]
        public void CrearLista_DebeCrearListaCorrectamente()
        {
            // Arrange
            string nombreLista = "Ting-Ling";
            Usuario usuario = new Usuario("Samuel");
            // Act
            usuario.CrearListaReproduccion(nombreLista);
            // Assert
            Assert.True(usuario.ListasReproduccion.ContainsKey("Ting-Ling"));
            Assert.Empty(usuario.ListasReproduccion["Ting-Ling"]);
        }

        [Fact]
        public void AgregarCancionALista_DebeAgregarCancionCorrectamente()
        {
            // Arrange
            string nombreLista = "Ting-Ling";
            Usuario usuario = new Usuario("Fernando");
            Cancion cancion = new Cancion("Feel It", "d4vd", 157);
            usuario.CrearListaReproduccion(nombreLista);
            // Act
            usuario.AgregarCancionALista(nombreLista, cancion);
            // Assert
            Assert.Single(usuario.ListasReproduccion["Ting-Ling"]); // Verifica si hay un elemento en el diccionario
            Assert.Equal(cancion, usuario.ListasReproduccion["Ting-Ling"][0]); // Verifica si la canción agregada es la correcta
        }
    }
}
