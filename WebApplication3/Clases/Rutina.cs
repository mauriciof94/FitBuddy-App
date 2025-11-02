using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Clases
{
    public class Rutina
    {
        public int IdRutina { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int DuracionMinutos { get; set; }
        public string Nivel { get; set; }
        public int IdTrainer { get; set; }
        public bool Compartida { get; set; } // ✅ nuevo campo
        public DateTime FechaCreacion { get; set; }
    }
}
