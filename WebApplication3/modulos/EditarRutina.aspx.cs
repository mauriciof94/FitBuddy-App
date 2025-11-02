using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Clases;

namespace WebApplication3.modulos
{
    public partial class EditarRutina : Page
    {
        RutinaDAO dao = new RutinaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validar sesión
                if (Session["idTrainer"] == null)
                {
                    Response.Redirect("../auth/login.aspx");
                    return;
                }

                // Verificar ID por QueryString
                string idParam = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idParam))
                {
                    int idRutina;
                    if (int.TryParse(idParam, out idRutina))
                    {
                        int idTrainer = Convert.ToInt32(Session["idTrainer"]);
                        CargarRutina(idRutina, idTrainer);
                    }
                    else
                    {
                        lblMensaje.Text = "⚠️ ID de rutina no válido.";
                    }
                }
                else
                {
                    lblMensaje.Text = "⚠️ No se especificó la rutina a editar.";
                }
            }
        }

        private void CargarRutina(int idRutina, int idTrainer)
        {
            try
            {
                var lista = dao.ObtenerRutinasPorTrainer(idTrainer);
                var rutina = lista.FirstOrDefault(r => r.IdRutina == idRutina);

                if (rutina != null)
                {
                    txtNombre.Text = rutina.Nombre;
                    txtDescripcion.Text = rutina.Descripcion;
                    txtDuracion.Text = rutina.DuracionMinutos.ToString();
                    ddlNivel.SelectedValue = ddlNivel.Items.FindByText(rutina.Nivel) != null ? rutina.Nivel : "Principiante";
                    chkCompartida.Checked = rutina.Compartida;
                }
                else
                {
                    lblMensaje.Text = "❌ No se encontró la rutina o no pertenece a este entrenador.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "⚠️ Error al cargar la rutina: " + ex.Message;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idTrainer = Convert.ToInt32(Session["idTrainer"]);
                int idRutina = Convert.ToInt32(Request.QueryString["id"]);

                Rutina r = new Rutina
                {
                    IdRutina = idRutina,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    DuracionMinutos = int.Parse(txtDuracion.Text),
                    Nivel = ddlNivel.SelectedValue,
                    Compartida = chkCompartida.Checked,
                    IdTrainer = idTrainer
                };

                if (dao.EditarRutina(r))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('✅ Rutina actualizada correctamente.'); window.location='../user/trainer.aspx';", true);
                }
                else
                {
                    lblMensaje.Text = "❌ No se pudo actualizar la rutina.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "⚠️ Error al guardar: " + ex.Message;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../user/trainer.aspx");
        }
    }
}