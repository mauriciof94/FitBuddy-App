using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Clases;
using System.Transactions;

namespace FitBuddy.Tests
{
    [TestClass]
    public class RutaDAOTest
    {
        private RutaDAO dao;

        [TestInitialize]
        public void Inicializar()
        {
            dao = new RutaDAO();
        }

        [TestMethod]
        public void CrearRuta_DeberiaGuardarRutaCorrectamente()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                Ruta nueva = new Ruta
                {
                    Nombre = "Ruta de Prueba",
                    Descripcion = "Ruta para test de creación",
                    Puntos = "[]",
                    IdTrainer = 1,
                    Compartida = false
                };

                // Act
                int idGenerado = dao.CrearRuta(nueva);

                // Assert
                Assert.IsTrue(idGenerado > 0, "La ruta no se creó correctamente en la base de datos.");
            }
        }

        [TestMethod]
        public void EditarRuta_DeberiaActualizarRutaCorrectamente()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                Ruta nueva = new Ruta
                {
                    Nombre = "Ruta Original",
                    Descripcion = "Antes de editar",
                    Puntos = "[]",
                    IdTrainer = 1,
                    Compartida = false
                };

                int idGenerado = dao.CrearRuta(nueva);
                nueva.Id = idGenerado;

                // Modificar datos
                nueva.Nombre = "Ruta Editada";
                nueva.Descripcion = "Descripción actualizada";

                // Act
                bool resultado = dao.EditarRuta(nueva);

                // Assert
                Assert.IsTrue(resultado, "La ruta no se actualizó correctamente en la base de datos.");
            }
        }

        [TestMethod]
        public void EliminarRuta_DeberiaEliminarRutaCorrectamente()
        {
            using (var scope = new TransactionScope())
            {
                // Arrange
                Ruta nueva = new Ruta
                {
                    Nombre = "Ruta Temporal",
                    Descripcion = "Ruta de prueba para eliminar",
                    Puntos = "[]",
                    IdTrainer = 1,
                    Compartida = false
                };

                int idGenerado = dao.CrearRuta(nueva);
                nueva.Id = idGenerado;

                // Act
                bool resultado = dao.EliminarRuta(nueva.Id, nueva.IdTrainer);

                // Assert
                Assert.IsTrue(resultado, "La ruta no se eliminó correctamente de la base de datos.");
            }
        }
    }
}