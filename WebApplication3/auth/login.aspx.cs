using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;
using WebApplication3.Utils;

namespace WebApplication3.auth
{
    public partial class login : System.Web.UI.Page
    {
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();

        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            string rol = ddlRol.SelectedValue;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(rol))
            {
                MostrarError("⚠️ Por favor completa todos los campos.");
                return;
            }

            try
            {
                ResultadoLogin resultado = ValidarCredenciales(usuario, contrasena, rol);

                if (resultado.Exitoso)
                {
                    SesionHelper.CrearSesion(usuario, rol, resultado.IdUsuario);
                    RedirigirSegunRol(rol);
                }
                else
                {
                    MostrarError(resultado.Mensaje);
                }
            }
            catch (Exception ex)
            {
                MostrarError("⚠️ Error de conexión: " + ex.Message);
            }
        }

        private ResultadoLogin ValidarCredenciales(string usuario, string contrasena, string rol)
        {
            var resultado = new ResultadoLogin();

            switch (rol)
            {
                case "Trainee":
                    var idTrainee = usuarioDAO.ValidarTrainee(usuario, contrasena);
                    if (idTrainee != null)
                    {
                        resultado.Exitoso = true;
                        resultado.IdUsuario = idTrainee;
                    }
                    else
                        resultado.Mensaje = "❌ Usuario o contraseña incorrectos.";
                    break;

                case "Entrenador":
                    var idTrainer = usuarioDAO.ValidarTrainer(usuario, contrasena);
                    if (idTrainer != null)
                    {
                        resultado.Exitoso = true;
                        resultado.IdUsuario = idTrainer;
                    }
                    else
                        resultado.Mensaje = "🚫 Tu cuenta aún no fue aprobada o las credenciales son incorrectas.";
                    break;

                case "Administrador":
                    bool valido = usuarioDAO.ValidarAdmin(usuario, contrasena);
                    resultado.Exitoso = valido;
                    resultado.Mensaje = valido ? "" : "❌ Usuario o contraseña incorrectos.";
                    break;
            }

            resultado.Rol = rol;
            return resultado;
        }

        private void RedirigirSegunRol(string rol)
        {
            switch (rol)
            {
                case "Trainee": Response.Redirect("../user/trainee.aspx"); break;
                case "Entrenador": Response.Redirect("../user/trainer.aspx"); break;
                case "Administrador": Response.Redirect("../user/admin.aspx"); break;
            }
        }

        private void MostrarError(string mensaje)
        {
            lblMensaje.ForeColor = System.Drawing.Color.Red;
            lblMensaje.Text = mensaje;
        }
    }
}