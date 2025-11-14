using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                CargarTrainersChat();
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
        protected void btnAbrirChatTrainer_Click(object sender, EventArgs e)
        {
            // Supongamos que el Trainee tiene asignado un entrenador con ID fijo por ahora
            int idEntrenador = 1; 
            Response.Redirect($"../modulos/Chat.aspx?idEntrenador={idEntrenador}");
        }
        private void CargarTrainersChat()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            var trainers = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id_trainer, nombre_usuario, email FROM TRAINER WHERE estado = 'Aprobado'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    trainers.Add(new
                    {
                        IdTrainer = Convert.ToInt32(dr["id_trainer"]),
                        Nombre = dr["nombre_usuario"].ToString(),
                        Email = dr["email"].ToString(),
                        Iniciales = dr["nombre_usuario"].ToString().Substring(0, 2).ToUpper()
                    });
                }
            }

            rptTrainersChat.DataSource = trainers;
            rptTrainersChat.DataBind();
        }

        protected void AbrirChatTrainer_Command(object sender, CommandEventArgs e)
        {
            int idTrainer = Convert.ToInt32(e.CommandArgument);
            Response.Redirect($"../modulos/Chat.aspx?idDestino={idTrainer}&tipoDestino=Trainer");
        }
    }
}