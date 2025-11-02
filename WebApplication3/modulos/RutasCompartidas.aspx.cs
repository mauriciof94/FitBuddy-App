using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;

namespace WebApplication3.modulos
{
    public partial class RutasCompartidas : Page
    {
        private readonly RutaDAO rutaDAO = new RutaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarRutas();
        }

        private void CargarRutas()
        {
            var rutas = rutaDAO.ObtenerRutasCompartidas()
                .Select(r => new
                {
                    r.Nombre,
                    r.Descripcion,
                    r.Puntos,
                    r.IdTrainer
                })
                .ToList();

            gvRutasCompartidas.DataSource = rutas;
            gvRutasCompartidas.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../user/trainee.aspx");
        }
    }
}