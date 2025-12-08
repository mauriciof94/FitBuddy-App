using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;

namespace WebApplication3.modulos
{
    public partial class EditarRuta : System.Web.UI.Page
    {
        RutaDAO dao = new RutaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 🔒 Validar sesión del entrenador
                if (Session["idTrainer"] == null)
                {
                    Response.Redirect("../auth/login.aspx");
                    return;
                }

                // 🔹 Verificar que venga el ID de la ruta
                if (Request.QueryString["id"] != null)
                {
                    int idRuta = Convert.ToInt32(Request.QueryString["id"]);
                    int idTrainer = Convert.ToInt32(Session["idTrainer"]);
                    CargarRuta(idRuta, idTrainer);
                }
                else
                {
                    lblMensaje.Text = "⚠️ No se especificó la ruta a editar.";
                }
            }
        }

        private void CargarRuta(int idRuta, int idTrainer)
        {
            var rutas = dao.ObtenerRutasPorTrainer(idTrainer);
            var ruta = rutas.Find(r => r.Id == idRuta);

            if (ruta != null)
            {
                txtNombre.Text = ruta.Nombre;
                txtDescripcion.Text = ruta.Descripcion;

                // ⬇️ AHORA cargamos el mapa desde el HiddenField
                hfPuntos.Value = ruta.Puntos;

                chkCompartida.Checked = ruta.Compartida;
            }
            else
            {
                lblMensaje.Text = "❌ No se encontró la ruta.";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idTrainer = Convert.ToInt32(Session["idTrainer"]);
                int idRuta = Convert.ToInt32(Request.QueryString["id"]);

                Ruta r = new Ruta
                {
                    Id = idRuta,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),

                    // ⬇️ Guardamos los puntos desde el JSON actualizado del mapa
                    Puntos = hfPuntos.Value,

                    Compartida = chkCompartida.Checked,
                    IdTrainer = idTrainer
                };

                if (dao.EditarRuta(r))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('✅ Ruta actualizada correctamente.'); window.location='../user/trainer.aspx';", true);
                }
                else
                {
                    lblMensaje.Text = "❌ Error al actualizar la ruta.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error inesperado: " + ex.Message;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../user/trainer.aspx");
        }
    }
}