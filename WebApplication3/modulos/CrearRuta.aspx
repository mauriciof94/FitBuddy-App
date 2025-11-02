<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearRuta.aspx.cs" Inherits="WebApplication3.modulos.CrearRuta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FitBuddy | Crear Ruta</title>
    <link rel="stylesheet" href="https://unpkg.com/leaflet/dist/leaflet.css" />
    <script src="https://unpkg.com/leaflet/dist/leaflet.js"></script>
    <style>
        body { font-family: Arial; background: #f7f9fc; padding: 20px; }
        form { background: white; padding: 20px; border-radius: 8px; max-width: 800px; margin: auto; box-shadow: 0 4px 10px rgba(0,0,0,0.1); }
        #map { height: 400px; border-radius: 10px; margin-bottom: 15px; }
        .btn { padding: 10px 15px; background: #0078D7; color: #fff; border: none; border-radius: 6px; cursor: pointer; }
        .btn:hover { background: #005fa3; }
        .btn-secondary { background: #888; margin-left: 5px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Crear Nueva Ruta</h2>

        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" />
        <asp:TextBox ID="txtNombre" runat="server" /><br />

        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:" />
        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" /><br />

        <asp:CheckBox ID="chkCompartida" runat="server" Text="Compartir con la comunidad" /><br /><br />

        <div id="map"></div>

        <asp:HiddenField ID="hfPuntos" runat="server" />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Ruta" CssClass="btn" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />

        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
    </form>

    <script>
        var map = L.map('map').setView([-34.6, -58.4], 13);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '© OpenStreetMap contributors'
        }).addTo(map);

        var puntos = [];
        var polyline;

        map.on('click', function (e) {
            puntos.push([e.latlng.lat, e.latlng.lng]);
            if (polyline) map.removeLayer(polyline);
            polyline = L.polyline(puntos, { color: 'blue' }).addTo(map);
            document.getElementById('<%= hfPuntos.ClientID %>').value = JSON.stringify(puntos);
        });
    </script>
</body>
</html>