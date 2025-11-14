<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="WebApplication3.modulos.Chat" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <title>FitBuddy | Chat</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../CSS/estilo.css" />
    <link rel="stylesheet" href="../CSS/users.css" />
    <style>
        .chat-container {
            max-width: 700px;
            margin: 0 auto;
            background-color: #1a1f2b;
            padding: 20px;
            border-radius: 12px;
            box-shadow: 0 0 12px rgba(0,0,0,0.3);
        }

        .chat-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 1rem;
        }

        .chat-header h1 {
            color: white;
            font-size: 1.6rem;
        }

        .btn-volver {
            background-color: #374151;
            color: white;
            border: none;
            padding: 8px 14px;
            border-radius: 8px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            text-decoration: none;
        }

        .btn-volver:hover {
            background-color: #4b5563;
        }

        .mensajes {
            max-height: 400px;
            overflow-y: auto;
            margin-bottom: 1rem;
            background-color: #232a38;
            border-radius: 8px;
            padding: 10px;
        }

        .action-buttons {
            display: flex;
            gap: 8px;
            align-items: center;
        }

        .form-control {
            padding: 8px;
            border-radius: 8px;
            border: none;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

        <section class="users-section">
            <div class="chat-container">
                <div class="chat-header">
                    <h1>Chat entre Trainer y Trainee</h1>
                    <asp:Button ID="btnVolver" runat="server" Text="Volver al Panel" CssClass="btn-volver" OnClick="btnVolver_Click" />
                </div>

                <!-- 🔹 Panel del chat -->
                <div id="contenedorMensajes" class="mensajes">
                    <asp:Repeater ID="rptMensajes" runat="server">
                        <ItemTemplate>
                            <div style='margin-bottom:10px; padding:8px; border-radius:8px;
                                        background-color:<%# (Convert.ToBoolean(Eval("EsPropio")) ? "#1d2634" : "#232a38") %>;
                                        text-align:<%# (Convert.ToBoolean(Eval("EsPropio")) ? "right" : "left") %>;
                                        color:white;'>
                                <small><strong><%# Eval("Emisor") %></strong> | <%# Eval("Fecha") %></small><br />
                                <%# Eval("Contenido") %>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <!-- 🔹 Enviar nuevo mensaje -->
                <div class="action-buttons">
                    <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" placeholder="Escribe un mensaje..." Width="80%" />
                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn-primary" OnClick="btnEnviar_Click" />
                </div>
            </div>
        </section>

        <!-- 🔁 Actualización automática con AJAX cada 3 segundos -->
        <script>
            function actualizarMensajes() {
                PageMethods.ObtenerMensajes(function (data) {
                    document.getElementById("contenedorMensajes").innerHTML = data;
                });
            }

            // Ejecuta cada 3 segundos
            setInterval(actualizarMensajes, 3000);
        </script>
    </form>
</body>
</html>