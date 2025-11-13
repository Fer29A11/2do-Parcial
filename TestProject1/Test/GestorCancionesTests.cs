using SistemaMusica.Gestores;
using SistemaMusica.Modelos;
using SistemaMusica.Servicios;

namespace SistemaMusica.Test
{
    public class GestorCancionesTests
    {
        [Fact]
        public void AgregarCancion_DebeAgregarCancionCorrectamente()
        {
            // Arrange
            GestorCanciones gestor = new GestorCanciones();
            Cancion cancion = new Cancion("No Mercy", "The Living Tombstone", 200);
            // Act
            gestor.AgregarCancion(cancion);
            // Assert
            Assert.Contains(cancion, gestor.CancionesDisponibles);
        }

        [Fact]
        public void BuscarPorNombre_DebeRetornarCancionesCorrectas()
        {
            // Arrange
            GestorCanciones gestor = new GestorCanciones();
            Cancion cancion1 = new Cancion("No Mercy", "The Living Tombstone", 200);
            Cancion cancion2 = new Cancion("Mercy", "Shawn Mendes", 210);
            gestor.AgregarCancion(cancion1);
            gestor.AgregarCancion(cancion2);
            // Act
            var resultados = gestor.BuscarPorNombre("Mercy");
            // Assert
            Assert.Equal(2, resultados.Count);
            Assert.Contains(cancion1, resultados);
            Assert.Contains(cancion2, resultados);
        }

        [Fact]
        public void QuickSort_DebeOrdenarCancionesPorDuracion()
        {
            // Arrange
            GestorCanciones gestor = new GestorCanciones();
            Cancion cancion1 = new Cancion("Corta", "Carne y Res", 120);
            Cancion cancion2 = new Cancion("Media", "Joanga", 156);
            Cancion cancion3 = new Cancion("Larga", "Toby Fox", 200);
            gestor.AgregarCancion(cancion1);
            gestor.AgregarCancion(cancion2);
            gestor.AgregarCancion(cancion3);
            // Act
            gestor.QuickSortPorDuracion(gestor.CancionesDisponibles);
            // Assert
            Assert.Equal(cancion1, gestor.CancionesDisponibles[0]);
            Assert.Equal(cancion2, gestor.CancionesDisponibles[1]);
            Assert.Equal(cancion3, gestor.CancionesDisponibles[2]); // Si es verdadero tendran ese orden
        }
    }
}
