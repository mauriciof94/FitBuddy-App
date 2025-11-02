<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearRutina.aspx.cs" Inherits="WebApplication3.modulos.CrearRutina" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <title>FitBuddy | Crear Rutina</title>
    <link rel="stylesheet" href="../CSS/estilo.css" />
    <link rel="stylesheet" href="../CSS/users.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />
</head>

<body>
    <form id="form1" runat="server">
        <section class="user-section">
            <div class="user-container">
                <div class="user-header">
                    <h1>Crear Nueva Rutina</h1>
                    <p>Definí los detalles de tu nueva rutina de entrenamiento personalizada.</p>
                </div>

                <div class="user-info">
                    <!-- Nombre -->
                    <div class="form-group">
                        <label for="txtNombre">Nombre:</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                    </div>

                    <!-- Descripción -->
                    <div class="form-group">
                        <label for="txtDescripcion">Descripción:</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" />
                    </div>

                    <!-- Duración -->
                    <div class="form-group">
                        <label for="txtDuracion">Duración (min):</label>
                        <asp:TextBox ID="txtDuracion" runat="server" CssClass="form-control" />
                    </div>

                    <!-- Nivel -->
                    <div class="form-group">
                        <label for="ddlNivel">Nivel:</label>
                        <asp:DropDownList ID="ddlNivel" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Principiante" />
                            <asp:ListItem Text="Intermedio" />
                            <asp:ListItem Text="Avanzado" />
                        </asp:DropDownList>
                    </div>

                    <!-- Compartir -->
                    <div class="form-group">
                        <asp:CheckBox ID="chkCompartida" runat="server" Text="Compartir con trainees" CssClass="form-check" />
                    </div>

                    <!-- Botones -->
                    <div class="action-buttons">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Rutina" CssClass="btn-primary" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn-secondary" OnClick="btnVolver_Click" />
                    </div>

                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
                </div>
            </div>
        </section>
    </form>
</body>
</html>