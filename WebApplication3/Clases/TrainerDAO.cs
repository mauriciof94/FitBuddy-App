using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3.Clases
{
    public class Trainer
    {
        public int IdTrainer { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class TrainerDAO
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        // 🔹 Obtener todos los entrenadores pendientes de verificación
        public List<Trainer> ObtenerPendientes()
        {
            var lista = new List<Trainer>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT id_trainer, nombre_usuario, email, fecha_registro, estado
                                 FROM TRAINER
                                 WHERE estado = 'Pendiente'";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Trainer
                    {
                        IdTrainer = Convert.ToInt32(dr["id_trainer"]),
                        NombreUsuario = dr["nombre_usuario"].ToString(),
                        Email = dr["email"].ToString(),
                        Estado = dr["estado"].ToString(),
                        FechaRegistro = Convert.ToDateTime(dr["fecha_registro"])
                    });
                }
            }

            return lista;
        }

        // 🔹 Aceptar entrenador (cambia el estado a 'Aprobado')
        public bool AceptarTrainer(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE TRAINER SET estado = 'Aprobado' WHERE id_trainer = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 🔹 Rechazar entrenador (cambia el estado a 'Rechazado')
        public bool RechazarTrainer(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE TRAINER SET estado = 'Rechazado' WHERE id_trainer = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 🔹 Obtener todos los entrenadores activos/aprobados (por si después lo necesitás)
        public List<Trainer> ObtenerAprobados()
        {
            var lista = new List<Trainer>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT id_trainer, nombre_usuario, email, fecha_registro, estado
                                 FROM TRAINER
                                 WHERE estado = 'Aprobado'";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Trainer
                    {
                        IdTrainer = Convert.ToInt32(dr["id_trainer"]),
                        NombreUsuario = dr["nombre_usuario"].ToString(),
                        Email = dr["email"].ToString(),
                        Estado = dr["estado"].ToString(),
                        FechaRegistro = Convert.ToDateTime(dr["fecha_registro"])
                    });
                }
            }

            return lista;
        }
    }
}