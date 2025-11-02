using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Clases
{
    public class Ruta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Puntos { get; set; } // Coordenadas o puntos de mapa en formato JSON
        public int IdTrainer { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Compartida { get; set; }
    }
}