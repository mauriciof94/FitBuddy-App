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

        public int? ValidarTrainee(string usuario, string contrasena)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT id_trainee FROM TRAINEE WHERE nombre_usuario = @usuario AND contrasena = @contrasena";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                con.Open();
                var result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value ? (int?)Convert.ToInt32(result) : null;
            }
        }

        public int? ValidarTrainer(string usuario, string contrasena)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT id_trainer FROM TRAINER WHERE nombre_usuario = @usuario AND contrasena = @contrasena AND estado = 'Aprobado'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                con.Open();
                var result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value ? (int?)Convert.ToInt32(result) : null;
            }
        }

        public bool ValidarAdmin(string usuario, string contrasena)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM ADMIN WHERE Usuario = @usuario AND contrasena = @contrasena";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}