<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarRutina.aspx.cs" Inherits="WebApplication3.modulos.EditarRutina" %>

<!DOCTYPE html>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <title>FitBuddy | Editar Rutina</title>

    <!-- Hojas de estilo -->
    <link rel="stylesheet" href="../CSS/estilo.css" />
    <link rel="stylesheet" href="../CSS/users.css" />

    <!-- Iconos -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />
</head>

<body>
    <form id="form1" runat="server">
        <section class="user-section">
            <div class="user-container">
                <div class="user-header">
                    <h1>Editar Rutina</h1>
                    <p>Modificá los detalles de tu rutina de entrenamiento.</p>
                </div>

                <div class="user-info">
                    <div class="form-group">
                        <label for="txtNombre">Nombre:</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                    </div>

                    <div class="form-group">
                        <label for="txtDescripcion">Descripción:</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" />
                    </div>

                    <div class="form-group">
                        <label for="txtDuracion">Duración (min):</label>
                        <asp:TextBox ID="txtDuracion" runat="server" CssClass="form-control" />
                    </div>

                    <div class="form-group">
                        <label for="ddlNivel">Nivel:</label>
                        <asp:DropDownList ID="ddlNivel" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Principiante" />
                            <asp:ListItem Text="Intermedio" />
                            <asp:ListItem Text="Avanzado" />
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:CheckBox ID="chkCompartida" runat="server" Text="Compartir con trainees" />
                    </div>

                    <div class="action-buttons">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn-primary" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn-secondary" OnClick="btnVolver_Click" />
                    </div>

                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
                </div>
            </div>
        </section>
    </form>
</body>
</html>