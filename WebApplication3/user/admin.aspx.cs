using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;

namespace WebApplication3.user
{
    public partial class admin : System.Web.UI.Page
    {
        private readonly TrainerDAO trainerDAO = new TrainerDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNombreAdmin.Text = Session["Usuario"]?.ToString() ?? "Administrador";
                CargarDatosDashboard();
                CargarEntrenadoresPendientes();
            }
        }

        // 🔹 Cargar métricas simuladas
        private void CargarDatosDashboard()
        {
            lblUsuariosTotales.Text = "1,247";
            lblEntrenadoresActivos.Text = "89";
            lblRatingPromedio.Text = "4.7";
            lblUptime.Text = "98.2%";

            lblUsuariosNuevos.Text = "+147 usuarios";
            lblSesionesActivas.Text = "892 sesiones hoy";
            lblIngresos.Text = "$12,458.00 USD";

            // Usuarios simulados
            var usuarios = new List<dynamic>
            {
                new { Iniciales = "AB", Nombre = "Ana Benítez", Email = "ana@fit.com", Estado = "Activo" },
                new { Iniciales = "JP", Nombre = "Juan Pérez", Email = "juan@fit.com", Estado = "Activo" }
            };
            rptUsuarios.DataSource = usuarios;
            rptUsuarios.DataBind();
        }

        // 🔹 Cargar lista de entrenadores pendientes desde la BD
        private void CargarEntrenadoresPendientes()
        {
            var pendientes = trainerDAO.ObtenerPendientes();

            var listaFormateada = new List<dynamic>();
            foreach (var t in pendientes)
            {
                listaFormateada.Add(new
                {
                    IdTrainer = t.IdTrainer,
                    Iniciales = t.NombreUsuario.Length >= 2 ? t.NombreUsuario.Substring(0, 2).ToUpper() : "TR",
                    Nombre = t.NombreUsuario,
                    Email = t.Email,
                    Fecha = t.FechaRegistro.ToString("dd/MM/yyyy"),
                    Estado = t.Estado
                });
            }

            rptEntrenadoresPendientes.DataSource = listaFormateada;
            rptEntrenadoresPendientes.DataBind();
        }

        // 🔹 Evento del Repeater (Aceptar / Rechazar)
        protected void rptEntrenadoresPendientes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int idTrainer = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Aprobar")
            {
                if (trainerDAO.AceptarTrainer(idTrainer))
                    MostrarMensaje($"✅ Entrenador #{idTrainer} aprobado correctamente.");
                else
                    MostrarMensaje($"❌ Error al aprobar al entrenador #{idTrainer}.");
            }
            else if (e.CommandName == "Rechazar")
            {
                if (trainerDAO.RechazarTrainer(idTrainer))
                    MostrarMensaje($"🚫 Entrenador #{idTrainer} rechazado correctamente.");
                else
                    MostrarMensaje($"❌ Error al rechazar al entrenador #{idTrainer}.");
            }

            // Recargar lista actualizada
            CargarEntrenadoresPendientes();
        }

        private void MostrarMensaje(string mensaje)
        {
            string script = $"alert('{mensaje}');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }
    }
}