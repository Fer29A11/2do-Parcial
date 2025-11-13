using SistemaMusica.Gestores;
using SistemaMusica.Modelos;
using SistemaMusica.Servicios;
namespace SistemaMusica.Test
{
    public class PruebaCancionTests
    {
        [Fact]
        public void AsignarValoresAlConstructor()
        {
            // Arrange
            string Nombre = "What I've Done";
            string Artista = "Linkin Park";
            int Duracion = 216;
            // Act
            Cancion cancion = new Cancion(Nombre, Artista, Duracion);
            // Assert
            Assert.Equal(Nombre, cancion.Nombre);
            Assert.Equal(Artista, cancion.Artista);
            Assert.Equal(Duracion, cancion.Duracion);
        }

        [Fact]
        public void VerificarToString()
        {
            // Arrange
            string Nombre = "What I've Done";
            string Artista = "Linkin Park";
            int Duracion = 216;
            Cancion cancion = new Cancion(Nombre, Artista, Duracion);
            string resultadoEsperado = "What I've Done - Linkin Park (3:36)";
            // Act
            string resultadoActual = cancion.ToString();
            // Assert
            Assert.Equal(resultadoEsperado, resultadoActual);
        }
    }
}