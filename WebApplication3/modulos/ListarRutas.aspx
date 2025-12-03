<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarRutas.aspx.cs" Inherits="WebApplication3.modulos.ListarRutas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FitBuddy | Mis Rutas</title>
    <link rel="stylesheet" href="../CSS/estilo.css" />

    <style>
        /* ============================
           ESTILO FITBUDDY – DARK MODE
           ============================ */

        :root {
            --bg-color: #000;
            --card-bg: #111;
            --line-color: #222;
            --text-color: #fff;
            --main-color: #45ffca;
        }

        body {
            font-family: Arial, Helvetica, sans-serif;
            background: var(--bg-color);
            padding: 40px;
            color: var(--text-color);
        }

        h2 {
            text-align: center;
            color: var(--main-color);
            letter-spacing: 1px;
            font-size: 32px;
            margin-bottom: 25px;
        }

        form {
            background: var(--card-bg);
            padding: 25px;
            border-radius: 12px;
            max-width: 1000px;
            margin: auto;
            box-shadow: 0 0 12px rgba(69, 255, 202, 0.15);
        }

        /* ============================
               TABLA FITBUDDY
           ============================ */

        table {
            width: 100%;
            border-collapse: collapse;
            color: var(--text-color);
        }

        th {
            background: var(--main-color);
            color: #000;
            padding: 12px;
            font-size: 16px;
            text-transform: uppercase;
        }

        td {
            padding: 12px;
            border-bottom: 1px solid var(--line-color);
        }

        tr:hover {
            background: rgba(69, 255, 202, 0.08);
            transition: 0.2s;
        }

        /* ============================
               BOTONES FITBUDDY
           ============================ */

        .btn {
            padding: 8px 14px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: bold;
            border: none;
            transition: 0.25s ease;
        }

        .btn-edit {
            background-color: #28a745;
            color: #fff;
        }

        .btn-edit:hover {
            background-color: #32c956;
        }

        .btn-delete {
            background-color: #dc3545;
            color: #fff;
        }

        .btn-delete:hover {
            background-color: #ff4657;
        }

        .btn-back {
            background-color: var(--main-color);
            color: #000;
            margin-top: 20px;
            width: 200px;
            font-size: 16px;
        }

        .btn-back:hover {
            box-shadow: 0 0 10px var(--main-color);
        }

        /* Mensajes */
        #lblMensaje {
            display: block;
            margin-top: 12px;
            font-size: 16px;
        }

    </style>
</head>

<body>
    <form id="form1" runat="server">
        <h2>Mis Rutas Creadas</h2>

        <asp:GridView ID="gvRutas" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            CssClass="grid-fitbuddy"
            OnRowCommand="gvRutas_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="FechaCreacion" HeaderText="Creación" DataFormatString="{0:dd/MM/yyyy}" />

                <asp:TemplateField HeaderText="Compartida">
                    <ItemTemplate>
                        <%# (bool)Eval("Compartida") ? "Sí" : "No" %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button runat="server" CommandName="Editar" CommandArgument='<%# Eval("Id") %>'
                            Text="Editar" CssClass="btn btn-edit" />

                        <asp:Button runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>'
                            Text="Eliminar" CssClass="btn btn-delete" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

        <asp:Button ID="btnVolver" runat="server" Text="Volver al Panel"
            CssClass="btn btn-back" OnClick="btnVolver_Click" />

        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
    </form>
</body>
</html>