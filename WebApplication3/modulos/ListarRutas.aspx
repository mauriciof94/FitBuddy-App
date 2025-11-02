<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarRutas.aspx.cs" Inherits="WebApplication3.modulos.ListarRutas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FitBuddy | Mis Rutas</title>
    <link rel="stylesheet" href="../CSS/estilo.css" />
    <style>
        body { font-family: Arial; background: #f7f9fc; padding: 20px; }
        form { background: white; padding: 20px; border-radius: 8px; max-width: 900px; margin: auto; box-shadow: 0 4px 10px rgba(0,0,0,0.1); }
        table { width: 100%; border-collapse: collapse; margin-top: 20px; }
        th, td { padding: 10px; text-align: left; border-bottom: 1px solid #ddd; }
        th { background-color: #0078D7; color: white; }
        tr:hover { background-color: #f1f1f1; }
        .btn { padding: 7px 12px; border: none; border-radius: 5px; cursor: pointer; color: #fff; }
        .btn-edit { background-color: #28a745; }
        .btn-delete { background-color: #dc3545; }
        .btn-back { background-color: #555; margin-top: 15px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Mis Rutas Creadas</h2>

        <asp:GridView ID="gvRutas" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
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
                        <asp:Button runat="server" CommandName="Editar" CommandArgument='<%# Eval("Id") %>' Text="Editar" CssClass="btn btn-edit" />
                        <asp:Button runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' Text="Eliminar" CssClass="btn btn-delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnVolver" runat="server" Text="Volver al Panel" CssClass="btn btn-back" OnClick="btnVolver_Click" />

        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
    </form>
</body>
</html>