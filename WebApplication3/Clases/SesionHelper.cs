using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Utils
{
    public static class SesionHelper
    {
        public static void CrearSesion(string usuario, string rol, int? id)
        {
            HttpContext.Current.Session["Usuario"] = usuario;
            HttpContext.Current.Session["Rol"] = rol;

            if (rol == "Trainee")
                HttpContext.Current.Session["idTrainee"] = id;
            else if (rol == "Entrenador")
                HttpContext.Current.Session["idTrainer"] = id;
        }

        public static void CerrarSesion()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
    }
}