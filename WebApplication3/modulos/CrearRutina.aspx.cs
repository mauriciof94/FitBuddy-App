using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;

namespace WebApplication3.modulos
{
    public partial class CrearRutina : Page
    {
        RutinaDAO dao = new RutinaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            // 🔸 Validación de sesión de entrenador
            if (Session["idTrainer"] == null)
            {
                Response.Redirect("../auth/login.aspx");
                return;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtDuracion.Text))
                {
                    lblMensaje.Text = "⚠️ Todos los campos son obligatorios.";
                    return;
                }

                Rutina nueva = new Rutina
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    DuracionMinutos = int.Parse(txtDuracion.Text),
                    Nivel = ddlNivel.SelectedValue,
                    IdTrainer = Convert.ToInt32(Session["idTrainer"]),
                    Compartida = chkCompartida.Checked
                };

                if (dao.CrearRutina(nueva))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('✅ Rutina creada correctamente.'); window.location='../user/trainer.aspx';", true);
                }
                else
                {
                    lblMensaje.Text = "❌ Error al crear la rutina.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error: " + ex.Message;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../user/trainer.aspx");
        }
    }
}