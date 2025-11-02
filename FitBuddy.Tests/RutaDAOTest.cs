using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Clases;

namespace FitBuddy.Tests
{
    [TestClass]
    public class RutaDAOTest
    {
        private RutaDAO rutaDAO;

        [TestInitialize]
        public void Inicializar()
        {
            // Inicializa el DAO antes de cada test
            rutaDAO = new RutaDAO();
        }

        [TestMethod]
        public void CrearRuta_DeberiaGuardarRutaCorrectamente()
        {
            // Arrange
            var nuevaRuta = new Ruta
            {
                Nombre = "Ruta Test",
                Descripcion = "Ruta de prueba unitaria",
                Puntos = "[-34.6037, -58.3816];[-34.6090, -58.3830]", // Ejemplo de coordenadas
                IdTrainer = 1, // Debe existir un Trainer con este ID
                Compartida = true
            };

            // Act
            bool resultado = rutaDAO.CrearRuta(nuevaRuta);

            // Assert
            Assert.IsTrue(resultado, "La ruta no se pudo crear correctamente en la base de datos.");
        }

        [TestMethod]
        public void EditarRuta_DeberiaActualizarRutaCorrectamente()
        {
            // Arrange
            var rutaExistente = new Ruta
            {
                Id = 1, 
                Nombre = "Ruta Editada",
                Descripcion = "Descripción modificada por prueba unitaria",
                Puntos = "[-34.6037, -58.3816];[-34.6090, -58.3830]",
                IdTrainer = 1,
                Compartida = false
            };

            // Act
            bool resultado = rutaDAO.EditarRuta(rutaExistente);

            // Assert
            Assert.IsTrue(resultado, "La ruta no se actualizó correctamente en la base de datos.");
        }

        [TestMethod]
        public void EliminarRuta_DeberiaEliminarRutaCorrectamente()
        {
            // Arrange
            int idRutaAEliminar = 2; 
            int idTrainer = 1;

            // Act
            bool resultado = rutaDAO.EliminarRuta(idRutaAEliminar, idTrainer);

            // Assert
            Assert.IsTrue(resultado, "La ruta no se eliminó correctamente de la base de datos.");
        }
    }
}