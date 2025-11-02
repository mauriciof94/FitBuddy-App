using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3.Clases
{
    public class UsuarioDAO
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        public bool RegistrarTrainee(string nombreUsuario, string contrasena)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TRAINEE (nombre_usuario, contrasena) VALUES (@usuario, @pass)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@pass", contrasena);

                conn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }
    }
}