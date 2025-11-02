using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WebApplication3.Clases;

public class RutinaDAO
{
    private string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

    // ✅ Crear Rutina
    public bool CrearRutina(Rutina r)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"INSERT INTO Rutina (nombre, descripcion, duracion_minutos, nivel, id_trainer, compartida)
                             VALUES (@nombre, @descripcion, @duracion, @nivel, @idTrainer, @compartida)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", r.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", r.Descripcion);
            cmd.Parameters.AddWithValue("@duracion", r.DuracionMinutos);
            cmd.Parameters.AddWithValue("@nivel", r.Nivel);
            cmd.Parameters.AddWithValue("@idTrainer", r.IdTrainer);
            cmd.Parameters.AddWithValue("@compartida", r.Compartida);

            conn.Open();
            int filas = cmd.ExecuteNonQuery();
            return filas > 0;
        }
    }

    // ✅ Editar Rutina
    public bool EditarRutina(Rutina r)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"UPDATE Rutina 
                             SET nombre = @nombre, descripcion = @descripcion, duracion_minutos = @duracion, 
                                 nivel = @nivel, compartida = @compartida
                             WHERE id_rutina = @idRutina AND id_trainer = @idTrainer";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", r.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", r.Descripcion);
            cmd.Parameters.AddWithValue("@duracion", r.DuracionMinutos);
            cmd.Parameters.AddWithValue("@nivel", r.Nivel);
            cmd.Parameters.AddWithValue("@compartida", r.Compartida);
            cmd.Parameters.AddWithValue("@idRutina", r.IdRutina);
            cmd.Parameters.AddWithValue("@idTrainer", r.IdTrainer);

            conn.Open();
            int filas = cmd.ExecuteNonQuery();
            return filas > 0;
        }
    }

    // ✅ Eliminar Rutina
    public bool EliminarRutina(int idRutina)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Rutina WHERE id_rutina = @idRutina";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idRutina", idRutina);

            conn.Open();
            int filas = cmd.ExecuteNonQuery();
            return filas > 0;
        }
    }

    // ✅ Obtener Rutinas por Trainer
    public List<Rutina> ObtenerRutinasPorTrainer(int idTrainer)
    {
        var lista = new List<Rutina>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Rutina WHERE id_trainer = @idTrainer";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idTrainer", idTrainer);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var rutina = new Rutina
                {
                    IdRutina = dr["id_rutina"] != DBNull.Value ? Convert.ToInt32(dr["id_rutina"]) : 0,
                    Nombre = dr["nombre"] != DBNull.Value ? dr["nombre"].ToString() : "(Sin nombre)",
                    Descripcion = dr["descripcion"] != DBNull.Value ? dr["descripcion"].ToString() : "(Sin descripción)",
                    DuracionMinutos = dr["duracion_minutos"] != DBNull.Value ? Convert.ToInt32(dr["duracion_minutos"]) : 0,
                    Nivel = dr["nivel"] != DBNull.Value ? dr["nivel"].ToString() : "(Sin nivel)",
                    IdTrainer = dr["id_trainer"] != DBNull.Value ? Convert.ToInt32(dr["id_trainer"]) : idTrainer
                };

                lista.Add(rutina);
            }
        }

        return lista;
    }

    // ✅ NUEVO: Obtener Rutinas Compartidas (visibles para trainees)
    public List<Rutina> ObtenerRutinasCompartidas()
    {
        var lista = new List<Rutina>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Rutina WHERE compartida = 1";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Rutina
                {
                    IdRutina = Convert.ToInt32(dr["id_rutina"]),
                    Nombre = dr["nombre"].ToString(),
                    Descripcion = dr["descripcion"].ToString(),
                    DuracionMinutos = Convert.ToInt32(dr["duracion_minutos"]),
                    Nivel = dr["nivel"].ToString(),
                    IdTrainer = Convert.ToInt32(dr["id_trainer"]),
                    Compartida = true
                });
            }
        }
        return lista;
    }
}