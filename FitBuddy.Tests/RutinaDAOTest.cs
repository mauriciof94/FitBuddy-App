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
    public class RutinaDAOTest
    {
        private RutinaDAO dao;

        [TestInitialize]
        public void Inicializar()
        {
            dao = new RutinaDAO();
        }

        
        [TestMethod]
        public void CrearRutina_DeberiaGuardarRutinaCorrectamente()
        {
            // Arrange
            Rutina nueva = new Rutina
            {
                Nombre = "Cardio Avanzado",
                Descripcion = "Sesión de alta intensidad enfocada en resistencia cardiovascular.",
                DuracionMinutos = 45,
                Nivel = "Avanzado",
                IdTrainer = 1 
            };

            // Act
            bool resultado = dao.CrearRutina(nueva);

            // Assert
            Assert.IsTrue(resultado, "La rutina no se guardó correctamente en la base de datos.");
        }
    }
}
