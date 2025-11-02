using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;

namespace WebApplication3.user
{
    public partial class trainee : Page
    {
        private readonly RutaDAO rutaDAO = new RutaDAO();
        private readonly RutinaDAO rutinaDAO = new RutinaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null || Session["Rol"]?.ToString() != "Trainee" || Session["idTrainee"] == null)
                {
                    Response.Redirect("../auth/login.aspx");
                    return;
                }

                lblNombreTrainee.Text = Session["Usuario"].ToString();
                CargarPanel();
            }
        }

        private void CargarPanel()
        {
            lblEntrenamientos.Text = "12";
            lblCompaneros.Text = "5";
            lblRutinasActivas.Text = "8";
            lblDiasRacha.Text = "15";

            // Datos simulados
            var rutinasActivas = new List<dynamic>
            {
                new { Iniciales = "FB", Nombre = "Full Body", Progreso = "45 min - Intermedio", Estado = "Activa" },
                new { Iniciales = "CR", Nombre = "Cardio Rápido", Progreso = "30 min - Básico", Estado = "Activa" }
            };
            rptRutinas.DataSource = rutinasActivas;
            rptRutinas.DataBind();

            var rutasActivas = new List<dynamic>
            {
                new { Id = 1, Nombre = "Circuito Central", Descripcion = "4 km - Parque" },
                new { Id = 2, Nombre = "Ruta Montaña", Descripcion = "6 km - Caminata" }
            };
            rptRutas.DataSource = rutasActivas;
            rptRutas.DataBind();

            var historial = new List<dynamic>
            {
                new { Rutina = "Full Body", Fecha = "2025-10-28", Duracion = 45 },
                new { Rutina = "Cardio Rápido", Fecha = "2025-10-26", Duracion = 30 }
            };
            rptHistorial.DataSource = historial;
            rptHistorial.DataBind();
        }

        // 🔹 BOTONES NUEVOS
        protected void btnVerRutasCompartidas_Click(object sender, EventArgs e)
        {
            Response.Redirect("../modulos/RutasCompartidas.aspx");
        }

        protected void btnVerRutinasCompartidas_Click(object sender, EventArgs e)
        {
            Response.Redirect("../modulos/RutinasCompartidas.aspx");
        }
    }
}