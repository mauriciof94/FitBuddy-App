using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;

namespace WebApplication3.modulos
{
    public partial class Rutinas : Page
    {
        RutinaDAO dao = new RutinaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarRutinas();
        }

        private void CargarRutinas()
        {
            int idTrainer = Convert.ToInt32(Session["idTrainer"]);
            gvRutinas.DataSource = dao.ObtenerRutinasPorTrainer(idTrainer);
            gvRutinas.DataBind();
        }

        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearRutina.aspx");
        }

        protected void gvRutinas_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarRutina")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("EditarRutina.aspx?id=" + id);
            }
            else if (e.CommandName == "EliminarRutina")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                bool eliminado = dao.EliminarRutina(id);

                if (eliminado)
                    CargarRutinas();
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../user/trainer.aspx");
        }
    }
}