<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearRuta.aspx.cs" Inherits="WebApplication3.modulos.CrearRuta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FitBuddy | Crear Ruta</title>
    <link rel="stylesheet" href="https://unpkg.com/leaflet/dist/leaflet.css" />
    <script src="https://unpkg.com/leaflet/dist/leaflet.js"></script>
    
   
    <style>
        :root {
            --bg-color: #000;
            --second-bg-color: #111;
            --text-color: #fff;
            --main-color: #45ffca;
            --gradient: linear-gradient(135deg, #45ffca 0%, #6effe0 100%);
        }
        
        body { 
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif; 
            background: var(--bg-color); 
            color: var(--text-color);
            padding: 20px; 
            margin: 0;
        }
        
        form { 
            background: var(--second-bg-color); 
            padding: 30px; 
            border-radius: 15px; 
            max-width: 800px; 
            margin: 40px auto; 
            border: 1px solid rgba(69, 255, 202, 0.2);
            box-shadow: 0 10px 30px rgba(69, 255, 202, 0.15);
        }
        
        h2 {
            color: var(--main-color);
            margin-bottom: 25px;
            font-size: 28px;
            text-align: center;
        }
        
        #map { 
            height: 400px; 
            border-radius: 10px; 
            margin-bottom: 20px; 
            border: 2px solid var(--main-color);
        }
        
        .btn { 
            padding: 12px 25px; 
            background: var(--gradient); 
            color: #000; 
            border: none; 
            border-radius: 8px; 
            cursor: pointer; 
            font-weight: bold;
            font-size: 16px;
            transition: all 0.3s ease;
        }
        
        .btn:hover { 
            transform: translateY(-2px);
            box-shadow: 0 5px 15px rgba(69, 255, 202, 0.4);
        }
        
        .btn-secondary { 
            background: transparent; 
            color: var(--main-color);
            border: 2px solid var(--main-color);
            margin-left: 10px; 
        }
        
        .btn-secondary:hover {
            background: var(--main-color);
            color: #000;
        }
        
        /* Estilos para labels y inputs */
        label {
            display: block;
            margin: 15px 0 8px;
            color: #ccc;
            font-size: 16px;
        }
        
        input[type="text"], textarea {
            width: 100%;
            padding: 12px;
            background: rgba(255,255,255,0.1);
            border: 2px solid transparent;
            border-radius: 8px;
            color: var(--text-color);
            font-size: 16px;
            margin-bottom: 15px;
            transition: all 0.3s ease;
        }
        
        input[type="text"]:focus, textarea:focus {
            border-color: var(--main-color);
            outline: none;
            box-shadow: 0 0 10px rgba(69, 255, 202, 0.3);
        }
        
        textarea {
            resize: vertical;
            min-height: 80px;
        }
        
        /* Checkbox estilo FitBuddy */
        input[type="checkbox"] {
            width: 20px;
            height: 20px;
            accent-color: var(--main-color);
            margin-right: 10px;
            vertical-align: middle;
        }
        
        /* Mensajes */
        #lblMensaje {
            display: block;
            margin-top: 15px;
            padding: 10px;
            border-radius: 8px;
            text-align: center;
        }
        
        /* Ajustes responsivos básicos */
        @media (max-width: 768px) {
            form {
                padding: 20px;
                margin: 20px;
            }
            
            .btn {
                width: 100%;
                margin-bottom: 10px;
            }
            
            .btn-secondary {
                margin-left: 0;
            }
        }
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
            polyline = L.polyline(puntos, { color: '#45ffca', weight: 3 }).addTo(map);
            document.getElementById('<%= hfPuntos.ClientID %>').value = JSON.stringify(puntos);
        });
    </script>
</body>
</html>