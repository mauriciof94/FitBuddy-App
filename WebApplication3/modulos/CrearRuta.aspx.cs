using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;

namespace WebApplication3.modulos
{
    public partial class CrearRuta : System.Web.UI.Page
    {
        RutaDAO dao = new RutaDAO();

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Ruta nueva = new Ruta
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Puntos = hfPuntos.Value,
                IdTrainer = Convert.ToInt32(Session["idTrainer"]),
                Compartida = chkCompartida.Checked
            };

            if (dao.CrearRuta(nueva))
            {
                string script = "alert('✅ Ruta creada correctamente.'); window.location='../user/trainer.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
                lblMensaje.Text = "❌ Error al crear la ruta.";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../user/trainer.aspx");
        }
    }
}