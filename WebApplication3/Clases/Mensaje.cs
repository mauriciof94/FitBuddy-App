using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Clases
{
    public class Mensaje
    {
        public int IdMensaje { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaEnvio { get; set; }
        public int IdEmisor { get; set; }
        public string TipoEmisor { get; set; }
        public int IdReceptor { get; set; }
        public string TipoReceptor { get; set; }
        public bool Leido { get; set; }
    }
}