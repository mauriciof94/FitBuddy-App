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
                // 🔹 Validar sesión activa
                if (Session["idTrainer"] == null)
                {
                    Response.Redirect("../auth/login.aspx");
                    return;
                }

                // 🔹 Cargar datos de la ruta si llega el ID por querystring
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
                txtPuntos.Text = ruta.Puntos;
                chkCompartida.Checked = ruta.Compartida;
            }
            else
            {
                lblMensaje.Text = "❌ No se encontró la ruta.";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idTrainer = Convert.ToInt32(Session["idTrainer"]);
            int idRuta = Convert.ToInt32(Request.QueryString["id"]);

            Ruta r = new Ruta
            {
                Id = idRuta,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Puntos = txtPuntos.Text,
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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../user/trainer.aspx");
        }
    }
}