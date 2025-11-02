<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RutasCompartidas.aspx.cs" Inherits="WebApplication3.modulos.RutasCompartidas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <title>FitBuddy | Rutas Compartidas</title>

    <link rel="stylesheet" href="../CSS/estilo.css" />
    <link rel="stylesheet" href="../CSS/users.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />

    <style>
        body { padding-top: 8.5rem; }
        .tabla { width: 100%; border-collapse: collapse; }
        .tabla th, .tabla td { padding: 1rem; text-align: left; font-size: 1.4rem; border-bottom: 1px solid rgba(255,255,255,0.06); }
        .tabla tr:hover { background: rgba(69,255,202,0.03); }
        .user-list { width: 100%; overflow-x: auto; }
    </style>
</head>

<body>
    <header>
        <a class="logo" href="../user/trainee.aspx">Fit<span>Buddy</span></a>
        <div id="menu-icon"><i class="fa fa-bars"></i></div>
        <nav class="navbar">
            <a href="../user/trainee.aspx">Inicio</a>
            <a href="RutasCompartidas.aspx" class="active">Rutas Compartidas</a>
            <a href="RutinasCompartidas.aspx">Rutinas Compartidas</a>
        </nav>
    </header>

    <main>
        <form id="form1" runat="server">
            <section class="users-section">
                <div class="user-container">
                    <div class="user-header">
                        <h1>Rutas Compartidas</h1>
                        <p>Explorá las rutas publicadas por los entrenadores de FitBuddy</p>
                    </div>

                    <div class="dashboard-card">
                        <div class="card-header">
                            <i class="fa-solid fa-map"></i>
                            <h3>Listado de Rutas Compartidas</h3>
                        </div>

                        <div class="user-list">
                            <asp:GridView ID="gvRutasCompartidas" runat="server" AutoGenerateColumns="False" CssClass="tabla">
                                <Columns>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                    <asp:BoundField DataField="Puntos" HeaderText="Puntos" />
                                    <asp:BoundField DataField="IdTrainer" HeaderText="ID Entrenador" />
                                </Columns>
                            </asp:GridView>
                        </div>

                        <div class="action-buttons" style="margin-top:1.8rem;">
                            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn-secondary" OnClick="btnVolver_Click" />
                        </div>
                    </div>
                </div>
            </section>
        </form>
    </main>

    <footer class="footer">
        <p>&copy; 2025 FitBuddy — Todos los derechos reservados.</p>
    </footer>
</body>
</html>