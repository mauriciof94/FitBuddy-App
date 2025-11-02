using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3.modulos
{
    public partial class RutinasCompartidas : Page
    {
        private readonly RutinaDAO rutinaDAO = new RutinaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarRutinas();
        }

        private void CargarRutinas()
        {
            var rutinas = rutinaDAO.ObtenerRutinasCompartidas()
                .Select(r => new
                {
                    r.Nombre,
                    r.Descripcion,
                    r.Nivel,
                    r.DuracionMinutos,
                    r.IdTrainer
                })
                .ToList();

            gvRutinasCompartidas.DataSource = rutinas;
            gvRutinasCompartidas.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../user/trainee.aspx");
        }
    }
}