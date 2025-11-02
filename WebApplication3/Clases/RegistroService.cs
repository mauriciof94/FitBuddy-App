using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3.Clases
{
    public class RegistroService
    {
        private readonly string connectionString;

        public RegistroService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        }

        public string RegistrarUsuario(string usuario, string email, string contrasena, string rol)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(contrasena) || string.IsNullOrWhiteSpace(rol))
            {
                return "⚠️ Por favor completa todos los campos.";
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = rol == "Trainee"
                        ? @"INSERT INTO TRAINEE (nombre_usuario, email, contrasena, fecha_registro)
                            VALUES (@nombre_usuario, @email, @contrasena, GETDATE())"
                        : @"INSERT INTO TRAINER (nombre_usuario, email, contrasena, fecha_registro, estado)
                            VALUES (@nombre_usuario, @email, @contrasena, GETDATE(), 'Pendiente')";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre_usuario", usuario);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@contrasena", contrasena);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return rol == "Entrenador"
                                ? "🕓 Tu registro fue enviado. Será revisado por Soporte."
                                : "✅ Registro exitoso. Ya puedes iniciar sesión.";
                        }
                        else
                        {
                            return "❌ Ocurrió un error al registrar el usuario.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "⚠️ Error de conexión: " + ex.Message;
            }
        }
    }
}
