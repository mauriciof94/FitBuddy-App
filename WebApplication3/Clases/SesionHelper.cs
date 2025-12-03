using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Utils
{
    public static class SesionHelper
    {
        // Método encargado de crear la sesión para un usuario que inicia sesión.
        // Recibe el nombre de usuario, el rol y el ID correspondiente (trainee o entrenador).
        public static void CrearSesion(string usuario, string rol, int? id)
        {
            // Guarda el nombre de usuario en la sesión.
            HttpContext.Current.Session["Usuario"] = usuario;

            // Guarda el rol del usuario (Trainee, Entrenador o Administrador).
            HttpContext.Current.Session["Rol"] = rol;

            // Dependiendo del rol, guarda en la sesión el ID correspondiente.
            // Separamos los IDs para evitar confusiones y mantener claridad.
            if (rol == "Trainee")
                HttpContext.Current.Session["idTrainee"] = id;

            else if (rol == "Entrenador")
                HttpContext.Current.Session["idTrainer"] = id;

            // Nota: Los administradores no necesitan ID en esta estructura.
        }

        // Método para cerrar sesión: limpia todas las variables de sesión y la abandona.
        public static void CerrarSesion()
        {
            // Elimina todas las variables almacenadas en la sesión.
            HttpContext.Current.Session.Clear();

            // Termina la sesión actual por completo.
            HttpContext.Current.Session.Abandon();
        }
    }
}