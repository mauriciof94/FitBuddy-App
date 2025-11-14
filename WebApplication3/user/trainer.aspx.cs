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
                CargarTraineesChat();
            }
        }

        private void CargarPanel()
        {
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

            int idTrainer = Convert.ToInt32(Session["idTrainer"]);

            // === RUTINAS REALES ===
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
            }
            else
            {
                rptRutinas.DataSource = new[] {
                    new { Iniciales = "--", Nombre = "Sin rutinas", Detalle = "Cree su primera rutina", Estado = "" }
                };
            }
            rptRutinas.DataBind();

            // === RUTAS REALES ===
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
            }
            else
            {
                rptRutas.DataSource = new[] {
                    new { Iniciales = "--", Nombre = "Sin rutas", Descripcion = "Cree su primera ruta", Estado = "" }
                };
            }
            rptRutas.DataBind();
        }

        private void CargarTraineesChat()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            var trainees = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id_trainee, nombre_usuario, email FROM TRAINEE";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    trainees.Add(new
                    {
                        IdTrainee = Convert.ToInt32(dr["id_trainee"]),
                        Nombre = dr["nombre_usuario"].ToString(),
                        Email = dr["email"].ToString(),
                        Iniciales = dr["nombre_usuario"].ToString().Length >= 2
                            ? dr["nombre_usuario"].ToString().Substring(0, 2).ToUpper()
                            : "TR"
                    });
                }
            }

            rptTraineesChat.DataSource = trainees;
            rptTraineesChat.DataBind();
        }

        protected void AbrirChatTrainee_Command(object sender, CommandEventArgs e)
        {
            int idTrainee = Convert.ToInt32(e.CommandArgument);
            Response.Redirect($"../modulos/Chat.aspx?idDestino={idTrainee}&tipoDestino=Trainee");
        }

        // === BOTONES ===
        protected void btnCrearRutina_Click(object sender, EventArgs e) => Response.Redirect("../modulos/CrearRutina.aspx");
        protected void btnEditarRutinas_Click(object sender, EventArgs e) => Response.Redirect("../modulos/Rutinas.aspx");
        protected void btnCrearRuta_Click(object sender, EventArgs e) => Response.Redirect("../modulos/CrearRuta.aspx");
        protected void btnGestionarRutas_Click(object sender, EventArgs e) => Response.Redirect("../modulos/ListarRutas.aspx");
    }
}