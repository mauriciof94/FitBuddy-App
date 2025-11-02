using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;

namespace WebApplication3.user
{
    public partial class trainer : System.Web.UI.Page
    {
        RutinaDAO rutinaDAO = new RutinaDAO();
        RutaDAO rutaDAO = new RutaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 🔒 Verificar sesión activa
                if (Session["Usuario"] == null || Session["Rol"]?.ToString() != "Entrenador" || Session["idTrainer"] == null)
                {
                    Response.Redirect("../auth/login.aspx");
                    return;
                }

                lblNombreTrainer.Text = Session["Usuario"].ToString();
                CargarPanel();
            }
        }

        private void CargarPanel()
        {
            // === CLIENTES SIMULADOS ===
            var clientes = new List<dynamic>
            {
                new { Iniciales = "LM", Nombre = "Laura Méndez", Progreso = "En progreso", Estado = "Activa" },
                new { Iniciales = "DR", Nombre = "Diego Ramírez", Progreso = "Avanzado", Estado = "Activa" },
                new { Iniciales = "AG", Nombre = "Ana Gómez", Progreso = "Principiante", Estado = "Activa" }
            };
            rptClientes.DataSource = clientes;
            rptClientes.DataBind();

            // === AGENDA SIMULADA ===
            var agenda = new List<dynamic>
            {
                new { Iniciales = "LM", Cliente = "Laura Méndez", Actividad = "09:00 - Entrenamiento Funcional", Estado = "Confirmada" },
                new { Iniciales = "DR", Cliente = "Diego Ramírez", Actividad = "11:00 - Sesión HIIT", Estado = "Confirmada" },
                new { Iniciales = "AG", Cliente = "Ana Gómez", Actividad = "15:30 - Cardio y Estiramientos", Estado = "Pendiente" }
            };
            rptAgenda.DataSource = agenda;
            rptAgenda.DataBind();

            // === MÉTRICAS SIMULADAS ===
            lblClientesActivos.Text = "24";
            lblSesionesImpartidas.Text = "156";
            lblRatingPromedio.Text = "4.8";
            lblRutinasCreadas.Text = "12";
            lblIngresos.Text = "$1,250.00 USD";
            lblNuevosClientes.Text = "5 este mes";
            lblSesionesCompletadas.Text = "42 sesiones";

            // === RUTINAS REALES DEL ENTRENADOR ===
            int idTrainer = Convert.ToInt32(Session["idTrainer"]);
            var rutinas = rutinaDAO.ObtenerRutinasPorTrainer(idTrainer);

            if (rutinas.Count > 0)
            {
                var data = rutinas.Select(r => new
                {
                    Iniciales = r.Nombre.Length >= 2 ? r.Nombre.Substring(0, 2).ToUpper() : "RT",
                    Nombre = r.Nombre,
                    Detalle = $"{r.Nivel} - {r.DuracionMinutos} min",
                    Estado = "Activa"
                }).ToList();

                rptRutinas.DataSource = data;
                rptRutinas.DataBind();
            }
            else
            {
                rptRutinas.DataSource = new[] {
                    new { Iniciales = "--", Nombre = "Sin rutinas", Detalle = "Cree su primera rutina", Estado = "" }
                };
                rptRutinas.DataBind();
            }

            // === RUTAS REALES DEL ENTRENADOR ===
            var rutas = rutaDAO.ObtenerRutasPorTrainer(idTrainer);
            if (rutas.Count > 0)
            {
                var dataRutas = rutas.Select(r => new
                {
                    Iniciales = r.Nombre.Length >= 2 ? r.Nombre.Substring(0, 2).ToUpper() : "RT",
                    Nombre = r.Nombre,
                    Descripcion = r.Descripcion,
                    Estado = r.Compartida ? "Compartida" : "Privada"
                }).ToList();

                rptRutas.DataSource = dataRutas;
                rptRutas.DataBind();
            }
            else
            {
                rptRutas.DataSource = new[] {
                    new { Iniciales = "--", Nombre = "Sin rutas", Descripcion = "Cree su primera ruta", Estado = "" }
                };
                rptRutas.DataBind();
            }
        }

        // === BOTONES DEL PANEL ===

        protected void btnCrearRutina_Click(object sender, EventArgs e)
        {
            Response.Redirect("../modulos/CrearRutina.aspx");
        }

        protected void btnEditarRutinas_Click(object sender, EventArgs e)
        {
            Response.Redirect("../modulos/Rutinas.aspx");
        }

        protected void btnCrearRuta_Click(object sender, EventArgs e)
        {
            Response.Redirect("../modulos/CrearRuta.aspx");
        }

        protected void btnGestionarRutas_Click(object sender, EventArgs e)
        {
            Response.Redirect("../modulos/ListarRutas.aspx");
        }
    }
}