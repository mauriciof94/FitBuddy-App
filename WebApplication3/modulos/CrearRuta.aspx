<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearRuta.aspx.cs" Inherits="WebApplication3.modulos.CrearRuta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <title>FitBuddy | Crear Ruta</title>

    <!-- CSS Global -->
    <link rel="stylesheet" href="../CSS/estilo.css" />
    <link rel="stylesheet" href="../CSS/users.css" />

    <!-- CSS del módulo (mismo archivo que EditarRuta) -->
    <link rel="stylesheet" href="../CSS/editar-ruta.css" />

    <!-- Leaflet -->
    <link rel="stylesheet" href="https://unpkg.com/leaflet/dist/leaflet.css" />
    <script src="https://unpkg.com/leaflet/dist/leaflet.js"></script>

    <!-- JS del módulo (mismo archivo que EditarRuta) -->
    <script src="../JS/editar-ruta.js"></script>
</head>

<body>
    <form id="form1" runat="server">

        <section class="users-section">
            <div class="user-container">

                <div class="user-header">
                    <h1>Crear Nueva Ruta</h1>
                    <p>Marcá puntos en el mapa para construir tu recorrido personalizado.</p>
                </div>

                <div class="user-info">

                    <div class="form-group">
                        <label>Nombre:</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                    </div>

                    <div class="form-group">
                        <label>Descripción:</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" />
                    </div>

                    <div class="form-group">
                        <asp:CheckBox ID="chkCompartida" runat="server" Text="Compartir con la comunidad" />
                    </div>

                    <!-- Mapa para agregar puntos -->
                    <div class="form-group">
                        <label>Puntos de la Ruta (Click para agregar):</label>
                        <div id="mapEditor" class="map-editor"></div>
                    </div>

                    <!-- Hidden donde se guarda el JSON -->
                    <asp:HiddenField ID="hfPuntos" runat="server" />

                    <div class="action-buttons">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Ruta" CssClass="btn-primary" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn-secondary" OnClick="btnVolver_Click" />
                    </div>

                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />

                </div>

            </div>
        </section>

    </form>
</body>
</html>
