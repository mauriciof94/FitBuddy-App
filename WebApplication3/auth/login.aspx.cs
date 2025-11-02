using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3.auth
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            string rol = ddlRol.SelectedValue;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(rol))
            {
                lblMensaje.Text = "⚠️ Por favor completa todos los campos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "";

                    if (rol == "Trainee")
                    {
                        query = "SELECT id_trainee FROM TRAINEE WHERE nombre_usuario = @usuario AND contrasena = @contrasena";
                    }
                    else if (rol == "Entrenador")
                    {
                        query = "SELECT id_trainer FROM TRAINER WHERE nombre_usuario = @usuario AND contrasena = @contrasena AND estado = 'Aprobado'";
                    }
                    else if (rol == "Administrador")
                    {
                        query = "SELECT COUNT(*) FROM ADMIN WHERE Usuario = @usuario AND contrasena = @contrasena";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contrasena", contrasena);

                        // === LOGIN DE TRAINER ===
                        if (rol == "Entrenador")
                        {
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                int idTrainer = Convert.ToInt32(result);
                                Session["Usuario"] = usuario;
                                Session["Rol"] = rol;
                                Session["idTrainer"] = idTrainer;

                                Response.Redirect("../user/trainer.aspx");
                                return;
                            }
                            else
                            {
                                lblMensaje.ForeColor = System.Drawing.Color.Red;
                                lblMensaje.Text = "🚫 Tu cuenta aún no fue aprobada o las credenciales son incorrectas.";
                                return;
                            }
                        }

                        // === LOGIN DE TRAINEE ===
                        if (rol == "Trainee")
                        {
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                int idTrainee = Convert.ToInt32(result);
                                Session["Usuario"] = usuario;
                                Session["Rol"] = rol;
                                Session["idTrainee"] = idTrainee;

                                Response.Redirect("../user/trainee.aspx");
                                return;
                            }
                            else
                            {
                                lblMensaje.ForeColor = System.Drawing.Color.Red;
                                lblMensaje.Text = "❌ Usuario o contraseña incorrectos.";
                                return;
                            }
                        }

                        // === LOGIN DE ADMIN ===
                        if (rol == "Administrador")
                        {
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                Session["Usuario"] = usuario;
                                Session["Rol"] = rol;
                                Response.Redirect("../user/admin.aspx");
                                return;
                            }
                            else
                            {
                                lblMensaje.ForeColor = System.Drawing.Color.Red;
                                lblMensaje.Text = "❌ Usuario o contraseña incorrectos.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "⚠️ Error de conexión: " + ex.Message;
            }
        }
    }
}