using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;

namespace WebApplication3.auth
{
    public partial class register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string email = txtEmail.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            string rol = ddlRol.SelectedValue;

            var servicio = new RegistroService();
            string mensaje = servicio.RegistrarUsuario(usuario, email, contrasena, rol);

            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = mensaje.StartsWith("✅") || mensaje.StartsWith("🕓")
                ? System.Drawing.Color.Green
                : System.Drawing.Color.Red;

            if (mensaje.StartsWith("✅") || mensaje.StartsWith("🕓"))
            {
                txtUsuario.Text = "";
                txtEmail.Text = "";
                txtContrasena.Text = "";
                ddlRol.SelectedIndex = 0;
            }
        }
    }
}
