<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trainee.aspx.cs" Inherits="WebApplication3.user.trainee" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>FitBuddy | Panel Trainee</title>

    <link href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../CSS/estilo.css" />
    <link rel="stylesheet" href="../CSS/users.css" />
</head>

<body>
    <form id="form1" runat="server">
        <header class="header">
            <a href="../main/index.html" class="logo"><span>FitBuddy</span></a>
            <nav class="navbar">
                <a href="#dashboard" class="active">Inicio</a>
                <a href="#entrenadores">Entrenadores</a>
                <a href="#rutinas">Rutinas</a>
                <a href="#rutas">Rutas</a>
                <a href="#historial">Historial</a>
            </nav>
        </header>

        <section class="users-section" id="dashboard">
            <div class="user-container">
                <div class="user-header">
                    <h1>Panel de Trainee</h1>
                    <p>Explora rutas y rutinas compartidas por entrenadores o revisa tus entrenamientos activos</p>
                </div>

                <!-- Información del Usuario -->
                <div class="user-info">
                    <div class="user-profile">
                        <div class="user-avatar">TU</div>
                        <div class="user-details">
                            <h2><asp:Label ID="lblNombreTrainee" runat="server" Text="Cargando..."></asp:Label></h2>
                            <span class="user-role">TRAINEE</span>
                        </div>
                    </div>

                    <div class="user-stats">
                        <div class="stat-card">
                            <span class="stat-number"><asp:Label ID="lblEntrenamientos" runat="server" Text="0"></asp:Label></span>
                            <span class="stat-label">Entrenamientos Completados</span>
                        </div>
                        <div class="stat-card">
                            <span class="stat-number"><asp:Label ID="lblCompaneros" runat="server" Text="0"></asp:Label></span>
                            <span class="stat-label">Compañeros Conectados</span>
                        </div>
                        <div class="stat-card">
                            <span class="stat-number"><asp:Label ID="lblRutinasActivas" runat="server" Text="0"></asp:Label></span>
                            <span class="stat-label">Rutinas Activas</span>
                        </div>
                        <div class="stat-card">
                            <span class="stat-number"><asp:Label ID="lblDiasRacha" runat="server" Text="0"></asp:Label></span>
                            <span class="stat-label">Días de Racha</span>
                        </div>
                    </div>
                </div>

                <!-- Dashboard Grid -->
                <div class="dashboard-grid">

                    <!-- EXPLORAR CONTENIDO COMPARTIDO -->
                    <div class="dashboard-card">
                        <div class="card-header">
                            <i class='bx bx-share-alt'></i>
                            <h3>Explorar Contenido de Entrenadores</h3>
                        </div>
                        <div class="user-list">
                            <p>Accede a rutas y rutinas creadas y compartidas por los entrenadores.</p>
                        </div>
                        <div class="action-buttons">
                            <asp:Button ID="btnVerRutasCompartidas" runat="server" CssClass="btn-primary" Text="Ver Rutas Compartidas" OnClick="btnVerRutasCompartidas_Click" />
                            <asp:Button ID="btnVerRutinasCompartidas" runat="server" CssClass="btn-secondary" Text="Ver Rutinas Compartidas" OnClick="btnVerRutinasCompartidas_Click" />
                        </div>
                    </div>

                    <!-- MIS RUTINAS ACTIVAS -->
                    <div class="dashboard-card">
                        <div class="card-header">
                            <i class='bx bx-task'></i>
                            <h3>Mis Rutinas Activas</h3>
                        </div>
                        <asp:Repeater ID="rptRutinas" runat="server">
                            <ItemTemplate>
                                <div class="user-item">
                                    <div class="user-avatar-small" style="background: var(--gradient);"><%# Eval("Iniciales") %></div>
                                    <div class="user-item-info">
                                        <h4><%# Eval("Nombre") %></h4>
                                        <p><%# Eval("Progreso") %></p>
                                    </div>
                                    <span class="user-status status-online"><%# Eval("Estado") %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <!-- MIS RUTAS ACTIVAS -->
                    <div class="dashboard-card">
                        <div class="card-header">
                            <i class='bx bx-map'></i>
                            <h3>Mis Rutas Activas</h3>
                        </div>
                        <asp:Repeater ID="rptRutas" runat="server">
                            <ItemTemplate>
                                <div class="user-item">
                                    <div class="user-avatar-small" style="background: var(--gradient);">Rt</div>
                                    <div class="user-item-info">
                                        <h4><%# Eval("Nombre") %></h4>
                                        <p><%# Eval("Descripcion") %></p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <!-- HISTORIAL -->
                    <div class="dashboard-card">
                        <div class="card-header">
                            <i class='bx bx-history'></i>
                            <h3>Historial de Entrenamientos</h3>
                        </div>
                        <asp:Repeater ID="rptHistorial" runat="server">
                            <ItemTemplate>
                                <div class="user-item">
                                    <div class="user-avatar-small" style="background: var(--gradient);">H</div>
                                    <div class="user-item-info">
                                        <h4><%# Eval("Rutina") %></h4>
                                        <p><%# Eval("Fecha") %> - Duración: <%# Eval("Duracion") %> min</p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                </div>
            </div>
        </section>

        <a href="../main/index.html" class="logout-btn">
            <i class='bx bx-log-out'></i>
        </a>
    </form>
</body>
</html>