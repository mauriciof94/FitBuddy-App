using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;
using System.Web.Script.Serialization;

namespace WebApplication3.modulos
{
    public partial class RutasCompartidas : Page
    {
        private readonly RutaDAO rutaDAO = new RutaDAO();
        private readonly JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarRutas();
        }

        private void CargarRutas()
        {
            try
            {
                var rutas = rutaDAO.ObtenerRutasCompartidas()
                    .Select(r => new
                    {
                        r.Id,
                        r.Nombre,
                        r.Descripcion,
                        r.Puntos,
                        r.IdTrainer
                    })
                    .ToList();

                if (rutas.Any())
                {
                    gvRutasCompartidas.DataSource = rutas;
                    gvRutasCompartidas.DataBind();
                }
                else
                {
                    // Mostrar mensaje si no hay datos
                    gvRutasCompartidas.DataSource = null;
                    gvRutasCompartidas.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Manejar error
                gvRutasCompartidas.DataSource = null;
                gvRutasCompartidas.DataBind();
            }
        }

        protected void gvRutasCompartidas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Encontrar el botón en la fila
                var btnVerMapa = e.Row.FindControl("btnVerMapa") as Button;
                if (btnVerMapa != null)
                {
                    // Obtener datos de la fila
                    var dataItem = e.Row.DataItem;

                    // Obtener valores usando DataBinder.Eval
                    var nombre = DataBinder.Eval(dataItem, "Nombre")?.ToString() ?? "";
                    var descripcion = DataBinder.Eval(dataItem, "Descripcion")?.ToString() ?? "";
                    var puntos = DataBinder.Eval(dataItem, "Puntos")?.ToString() ?? "[]";
                    var trainerId = DataBinder.Eval(dataItem, "IdTrainer")?.ToString() ?? "";

                    // Limpiar JSON para JavaScript
                    var puntosLimpios = puntos.Replace("\r\n", "").Replace("\n", "").Replace("\t", "");

                    // Escapar comillas simples y dobles
                    var puntosEscapados = puntosLimpios.Replace("'", "\\'").Replace("\"", "\\\"");
                    var nombreEscapado = nombre.Replace("'", "\\'").Replace("\"", "\\\"");
                    var descripcionEscapada = descripcion.Replace("'", "\\'").Replace("\"", "\\\"");

                    // Configurar el evento onclick del botón
                    btnVerMapa.OnClientClick = $"mostrarRuta('{puntosEscapados}', '{nombreEscapado}', '{descripcionEscapada}', '{trainerId}'); return false;";

                    // Agregar tooltip
                    btnVerMapa.ToolTip = "Ver ruta en el mapa";
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../user/trainee.aspx");
        }
    }
}