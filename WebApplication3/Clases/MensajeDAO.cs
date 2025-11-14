using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3.Clases
{
    public class MensajeDAO
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        // ✅ Enviar un mensaje
        public bool EnviarMensaje(Mensaje m)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO MENSAJE (contenido, id_emisor, tipo_emisor, id_receptor, tipo_receptor)
                                 VALUES (@contenido, @idEmisor, @tipoEmisor, @idReceptor, @tipoReceptor)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@contenido", m.Contenido);
                cmd.Parameters.AddWithValue("@idEmisor", m.IdEmisor);
                cmd.Parameters.AddWithValue("@tipoEmisor", m.TipoEmisor);
                cmd.Parameters.AddWithValue("@idReceptor", m.IdReceptor);
                cmd.Parameters.AddWithValue("@tipoReceptor", m.TipoReceptor);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ✅ Obtener mensajes entre dos usuarios
        public List<Mensaje> ObtenerConversacion(int id1, string tipo1, int id2, string tipo2)
        {
            var mensajes = new List<Mensaje>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT * FROM MENSAJE
                    WHERE (id_emisor=@id1 AND tipo_emisor=@tipo1 AND id_receptor=@id2 AND tipo_receptor=@tipo2)
                       OR (id_emisor=@id2 AND tipo_emisor=@tipo2 AND id_receptor=@id1 AND tipo_receptor=@tipo1)
                    ORDER BY fecha_envio ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id1", id1);
                cmd.Parameters.AddWithValue("@tipo1", tipo1);
                cmd.Parameters.AddWithValue("@id2", id2);
                cmd.Parameters.AddWithValue("@tipo2", tipo2);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mensajes.Add(new Mensaje
                    {
                        IdMensaje = Convert.ToInt32(dr["id_mensaje"]),
                        Contenido = dr["contenido"].ToString(),
                        FechaEnvio = Convert.ToDateTime(dr["fecha_envio"]),
                        IdEmisor = Convert.ToInt32(dr["id_emisor"]),
                        TipoEmisor = dr["tipo_emisor"].ToString(),
                        IdReceptor = Convert.ToInt32(dr["id_receptor"]),
                        TipoReceptor = dr["tipo_receptor"].ToString(),
                        Leido = Convert.ToBoolean(dr["leido"])
                    });
                }
            }

            return mensajes;
        }
    }
}