using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;

namespace WebApplication3.modulos
{
    public partial class ListarRutas : System.Web.UI.Page
    {
        RutaDAO dao = new RutaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idTrainer"] == null)
                {
                    Response.Redirect("../auth/login.aspx");
                    return;
                }

                CargarRutas();
            }
        }

        private void CargarRutas()
        {
            int idTrainer = Convert.ToInt32(Session["idTrainer"]);
            gvRutas.DataSource = dao.ObtenerRutasPorTrainer(idTrainer);
            gvRutas.DataBind();
        }

        protected void gvRutas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idRuta = Convert.ToInt32(e.CommandArgument);
            int idTrainer = Convert.ToInt32(Session["idTrainer"]);

            if (e.CommandName == "Editar")
            {
                Response.Redirect($"EditarRuta.aspx?id={idRuta}");
            }
            else if (e.CommandName == "Eliminar")
            {
                bool exito = dao.EliminarRuta(idRuta, idTrainer);
                lblMensaje.Text = exito ? "✅ Ruta eliminada correctamente." : "❌ Error al eliminar la ruta.";
                CargarRutas();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../user/trainer.aspx");
        }
    }
}