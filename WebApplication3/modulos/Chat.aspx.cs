using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;

namespace WebApplication3.modulos
{
    public partial class Chat : Page
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 🔒 Validar sesión
                if (Session["Usuario"] == null || (Session["Rol"].ToString() != "Entrenador" && Session["Rol"].ToString() != "Trainee"))
                {
                    Response.Redirect("../auth/login.aspx");
                    return;
                }

                // 🔹 Validar parámetros
                if (Request.QueryString["idDestino"] == null || Request.QueryString["tipoDestino"] == null)
                {
                    Response.Write("Faltan parámetros del chat.");
                    return;
                }

                // Guardar destino tanto en ViewState como en Session
                int idDestino = Convert.ToInt32(Request.QueryString["idDestino"]);
                string tipoDestino = Request.QueryString["tipoDestino"]; // "Trainer" o "Trainee"

                ViewState["idDestino"] = idDestino;
                ViewState["tipoDestino"] = tipoDestino;
                Session["idDestino"] = idDestino;
                Session["tipoDestino"] = tipoDestino;

                CargarMensajes();
            }
        }

        private void CargarMensajes()
        {
            // 🔹 Obtener datos del usuario logueado
            string rol = Session["Rol"].ToString(); // "Entrenador" o "Trainee"
            int idUsuario = (rol == "Entrenador")
                ? Convert.ToInt32(Session["idTrainer"])
                : Convert.ToInt32(Session["idTrainee"]);

            int idDestino = Convert.ToInt32(ViewState["idDestino"]);

            // 🔹 Convertir a nombres válidos en la BD
            string tipoUsuario = (rol == "Entrenador") ? "Trainer" : "Trainee";
            string tipoDestino = ViewState["tipoDestino"].ToString(); // Ya viene en inglés ("Trainer" o "Trainee")

            var mensajes = ObtenerMensajesDesdeDB(idUsuario, idDestino, tipoUsuario, tipoDestino);
            rptMensajes.DataSource = mensajes;
            rptMensajes.DataBind();
        }

        [WebMethod(EnableSession = true)]
        public static string ObtenerMensajes()
        {
            if (HttpContext.Current.Session["Usuario"] == null)
                return "";

            string rol = HttpContext.Current.Session["Rol"].ToString();
            int idUsuario = (rol == "Entrenador")
                ? Convert.ToInt32(HttpContext.Current.Session["idTrainer"])
                : Convert.ToInt32(HttpContext.Current.Session["idTrainee"]);

            int idDestino = Convert.ToInt32(HttpContext.Current.Session["idDestino"]);
            string tipoUsuario = (rol == "Entrenador") ? "Trainer" : "Trainee";
            string tipoDestino = HttpContext.Current.Session["tipoDestino"].ToString(); // "Trainer" o "Trainee"

            var mensajes = ObtenerMensajesDesdeDB(idUsuario, idDestino, tipoUsuario, tipoDestino);

            // 🔹 Generar HTML de los mensajes
            StringBuilder sb = new StringBuilder();
            foreach (var m in mensajes)
            {
                string align = m.EsPropio ? "right" : "left";
                string color = m.EsPropio ? "#1d2634" : "#232a38";
                sb.Append($@"
                    <div style='margin-bottom:10px; padding:8px; border-radius:8px;
                                background-color:{color}; text-align:{align}; color:white;'>
                        <small><strong>{m.Emisor}</strong> | {m.Fecha}</small><br />{m.Contenido}
                    </div>");
            }

            return sb.ToString();
        }

        private static List<dynamic> ObtenerMensajesDesdeDB(int idUsuario, int idDestino, string tipoUsuario, string tipoDestino)
        {
            var mensajes = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT contenido, fecha_envio, id_emisor, tipo_emisor
                    FROM MENSAJE
                    WHERE 
                        (id_emisor = @idUsuario AND id_receptor = @idDestino AND tipo_emisor = @tipoUsuario)
                        OR
                        (id_emisor = @idDestino AND id_receptor = @idUsuario AND tipo_emisor = @tipoDestino)
                    ORDER BY fecha_envio ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@idDestino", idDestino);
                cmd.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
                cmd.Parameters.AddWithValue("@tipoDestino", tipoDestino);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mensajes.Add(new
                    {
                        Contenido = dr["contenido"].ToString(),
                        Fecha = Convert.ToDateTime(dr["fecha_envio"]).ToString("HH:mm"),
                        Emisor = dr["tipo_emisor"].ToString(),
                        EsPropio = Convert.ToInt32(dr["id_emisor"]) == idUsuario
                    });
                }
            }

            return mensajes;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string mensaje = txtMensaje.Text.Trim();
            if (string.IsNullOrEmpty(mensaje)) return;

            string rol = Session["Rol"].ToString();
            int idEmisor = (rol == "Entrenador")
                ? Convert.ToInt32(Session["idTrainer"])
                : Convert.ToInt32(Session["idTrainee"]);

            string tipoEmisor = (rol == "Entrenador") ? "Trainer" : "Trainee";
            int idDestino = Convert.ToInt32(ViewState["idDestino"]);
            string tipoDestino = ViewState["tipoDestino"].ToString(); // "Trainer" o "Trainee"

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO MENSAJE (contenido, id_emisor, tipo_emisor, id_receptor, tipo_receptor, fecha_envio)
                                 VALUES (@contenido, @idEmisor, @tipoEmisor, @idDestino, @tipoDestino, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@contenido", mensaje);
                cmd.Parameters.AddWithValue("@idEmisor", idEmisor);
                cmd.Parameters.AddWithValue("@tipoEmisor", tipoEmisor);
                cmd.Parameters.AddWithValue("@idDestino", idDestino);
                cmd.Parameters.AddWithValue("@tipoDestino", tipoDestino);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            txtMensaje.Text = "";
            CargarMensajes();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            if (Session["Rol"] != null)
            {
                if (Session["Rol"].ToString() == "Entrenador")
                    Response.Redirect("../user/trainer.aspx");
                else
                    Response.Redirect("../user/trainee.aspx");
            }
            else
            {
                Response.Redirect("../auth/login.aspx");
            }
        }
    }
}