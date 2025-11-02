using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3.Clases
{
    public class RutaDAO
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        public bool CrearRuta(Ruta r)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Ruta (nombre, descripcion, puntos, id_trainer, compartida)
                                 VALUES (@nombre, @descripcion, @puntos, @idTrainer, @compartida)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", r.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", r.Descripcion);
                cmd.Parameters.AddWithValue("@puntos", r.Puntos);
                cmd.Parameters.AddWithValue("@idTrainer", r.IdTrainer);
                cmd.Parameters.AddWithValue("@compartida", r.Compartida);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EditarRuta(Ruta r)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Ruta SET nombre=@nombre, descripcion=@descripcion, puntos=@puntos, compartida=@compartida 
                                 WHERE id_ruta=@idRuta AND id_trainer=@idTrainer";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", r.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", r.Descripcion);
                cmd.Parameters.AddWithValue("@puntos", r.Puntos);
                cmd.Parameters.AddWithValue("@compartida", r.Compartida);
                cmd.Parameters.AddWithValue("@idRuta", r.Id);
                cmd.Parameters.AddWithValue("@idTrainer", r.IdTrainer);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarRuta(int idRuta, int idTrainer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Ruta WHERE id_ruta=@idRuta AND id_trainer=@idTrainer";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idRuta", idRuta);
                cmd.Parameters.AddWithValue("@idTrainer", idTrainer);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Ruta> ObtenerRutasPorTrainer(int idTrainer)
        {
            var lista = new List<Ruta>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Ruta WHERE id_trainer=@idTrainer";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTrainer", idTrainer);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Ruta
                    {
                        Id = Convert.ToInt32(dr["id_ruta"]),
                        Nombre = dr["nombre"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                        Puntos = dr["puntos"].ToString(),
                        IdTrainer = Convert.ToInt32(dr["id_trainer"]),
                        FechaCreacion = Convert.ToDateTime(dr["fecha_creacion"]),
                        Compartida = Convert.ToBoolean(dr["compartida"])
                    });
                }
            }
            return lista;
        }

        public List<Ruta> ObtenerRutasCompartidas()
        {
            var lista = new List<Ruta>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Ruta WHERE compartida = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Ruta
                    {
                        Id = Convert.ToInt32(dr["id_ruta"]),
                        Nombre = dr["nombre"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                        Puntos = dr["puntos"].ToString(),
                        IdTrainer = Convert.ToInt32(dr["id_trainer"]),
                        FechaCreacion = Convert.ToDateTime(dr["fecha_creacion"]),
                        Compartida = true
                    });
                }
            }
            return lista;
        }
    }
}