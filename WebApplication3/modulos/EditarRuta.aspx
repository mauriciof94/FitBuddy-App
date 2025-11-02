<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarRuta.aspx.cs" Inherits="WebApplication3.modulos.EditarRuta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FitBuddy | Editar Ruta</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Editar Ruta</h2>

        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" />
        <asp:TextBox ID="txtNombre" runat="server" /><br />

        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:" />
        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" /><br />

        <asp:Label ID="lblPuntos" runat="server" Text="Puntos (coordenadas o JSON):" />
        <asp:TextBox ID="txtPuntos" runat="server" TextMode="MultiLine" Rows="3" /><br />

        <asp:CheckBox ID="chkCompartida" runat="server" Text="Compartir con trainees" /><br /><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" /><br /><br />

        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
    </form>
</body>
</html>