<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebApplication3.user.admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>FitBuddy | Panel Administrador</title>

    <link href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../CSS/estilo.css" />
    <link rel="stylesheet" href="../CSS/users.css" />
</head>

<body>
    <form id="form1" runat="server">
        <header class="header">
            <a href="../main/index.html" class="logo"><span>FitBuddy</span></a>
            <nav class="navbar">
                <a href="#dashboard" class="active">Dashboard</a>
                <a href="#usuarios">Usuarios</a>
                <a href="#entrenadores">Entrenadores</a>
                <a href="#reportes">Reportes</a>
                <a href="#configuracion">Configuración</a>
            </nav>
        </header>

        <section class="users-section" id="dashboard">
            <div class="user-container">
                <div class="user-header" data-aos="fade-down">
                    <h1>Panel de Administración</h1>
                    <p>Gestiona la plataforma FitBuddy y supervisa la comunidad</p>
                </div>

                <!-- Información del Administrador -->
                <div class="user-info" data-aos="fade-up">
                    <div class="user-profile">
                        <div class="user-avatar">AD</div>
                        <div class="user-details">
                            <h2><asp:Label ID="lblNombreAdmin" runat="server" Text="Cargando..."></asp:Label></h2>
                            <span class="user-role">ADMINISTRADOR</span>
                        </div>
                    </div>
                    
                    <div class="user-stats">
                        <div class="stat-card">
                            <span class="stat-number"><asp:Label ID="lblUsuariosTotales" runat="server" Text="0"></asp:Label></span>
                            <span class="stat-label">Usuarios Totales</span>
                        </div>
                        <div class="stat-card">
                            <span class="stat-number"><asp:Label ID="lblEntrenadoresActivos" runat="server" Text="0"></asp:Label></span>
                            <span class="stat-label">Entrenadores Activos</span>
                        </div>
                        <div class="stat-card">
                            <span class="stat-number"><asp:Label ID="lblRatingPromedio" runat="server" Text="0.0"></asp:Label></span>
                            <span class="stat-label">Rating Promedio</span>
                        </div>
                        <div class="stat-card">
                            <span class="stat-number"><asp:Label ID="lblUptime" runat="server" Text="0%"></asp:Label></span>
                            <span class="stat-label">Uptime Plataforma</span>
                        </div>
                    </div>
                </div>

                <!-- Dashboard Grid -->
                <div class="dashboard-grid">
                    <!-- Gestión de Usuarios -->
                    <div class="dashboard-card" data-aos="fade-right">
                        <div class="card-header">
                            <i class='bx bx-user'></i>
                            <h3>Gestión de Usuarios</h3>
                        </div>
                        <div class="user-list">
                            <asp:Repeater ID="rptUsuarios" runat="server">
                                <ItemTemplate>
                                    <div class="user-item">
                                        <div class="user-avatar-small" style="background: var(--gradient);"><%# Eval("Iniciales") %></div>
                                        <div class="user-item-info">
                                            <h4><%# Eval("Nombre") %></h4>
                                            <p><%# Eval("Email") %></p>
                                        </div>
                                        <span class="user-status status-online"><%# Eval("Estado") %></span>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="action-buttons">
                            <asp:Button ID="btnGestionarUsuarios" runat="server" CssClass="btn-primary" Text="Gestionar Todos" />
                            <asp:Button ID="btnBuscarUsuario" runat="server" CssClass="btn-secondary" Text="Buscar Usuario" />
                        </div>
                    </div>

                    <!-- Entrenadores Pendientes -->
                    <!-- Entrenadores Pendientes -->
                    <div class="dashboard-card" data-aos="fade-left">
                        <div class="card-header">
                            <i class='bx bx-dumbbell'></i>
                            <h3>Entrenadores por Verificar</h3>
                        </div>

                        <asp:Repeater ID="rptEntrenadoresPendientes" runat="server" OnItemCommand="rptEntrenadoresPendientes_ItemCommand">
                            <ItemTemplate>
                                <div class="user-item">
                                    <div class="user-avatar-small" style="background: var(--gradient);"><%# Eval("Iniciales") %></div>
                                    <div class="user-item-info">
                                        <h4><%# Eval("Nombre") %></h4>
                                        <p>Email: <%# Eval("Email") %> | Fecha: <%# Eval("Fecha") %></p>
                                    </div>
                                    <div class="action-buttons">
                                        <asp:Button ID="btnAprobar" runat="server" Text="Aprobar"
                                            CssClass="btn-primary btn-small"
                                            CommandName="Aprobar"
                                            CommandArgument='<%# Eval("IdTrainer") %>' />
                                        <asp:Button ID="btnRechazar" runat="server" Text="Rechazar"
                                            CssClass="btn-danger btn-small"
                                            CommandName="Rechazar"
                                            CommandArgument='<%# Eval("IdTrainer") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>



                    <!-- Reportes Recientes -->
                    <div class="dashboard-card" data-aos="fade-right">
                        <div class="card-header">
                            <i class='bx bx-flag'></i>
                            <h3>Reportes Recientes</h3>
                        </div>
                        <asp:Repeater ID="rptReportes" runat="server">
                            <ItemTemplate>
                                <div class="user-item">
                                    <div class="user-avatar-small" style="background: var(--danger-color);">!</div>
                                    <div class="user-item-info">
                                        <h4><%# Eval("Titulo") %></h4>
                                        <p><%# Eval("Descripcion") %></p>
                                    </div>
                                    <span class="user-status status-busy"><%# Eval("Estado") %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="action-buttons">
                            <asp:Button ID="btnVerReportes" runat="server" CssClass="btn-primary" Text="Ver Todos" />
                        </div>
                    </div>

                    <!-- Métricas de la Plataforma -->
                    <div class="dashboard-card" data-aos="fade-left">
                        <div class="card-header">
                            <i class='bx bx-stats'></i>
                            <h3>Métricas de la Plataforma</h3>
                        </div>
                        <div class="user-list">
                            <div class="user-item">
                                <div class="user-item-info">
                                    <h4>Usuarios Nuevos (30d)</h4>
                                    <p><asp:Label ID="lblUsuariosNuevos" runat="server" Text="+0 usuarios"></asp:Label></p>
                                </div>
                            </div>
                            <div class="user-item">
                                <div class="user-item-info">
                                    <h4>Sesiones Activas</h4>
                                    <p><asp:Label ID="lblSesionesActivas" runat="server" Text="0 sesiones hoy"></asp:Label></p>
                                </div>
                            </div>
                            <div class="user-item">
                                <div class="user-item-info">
                                    <h4>Ingresos Mensuales</h4>
                                    <p><asp:Label ID="lblIngresos" runat="server" Text="$0 USD"></asp:Label></p>
                                </div>
                            </div>
                        </div>
                        <div class="action-buttons">
                            <asp:Button ID="btnExportar" runat="server" CssClass="btn-primary" Text="Exportar Reporte" />
                        </div>
                    </div>
                </div>

                <!-- Herramientas de Administración -->
                <div class="dashboard-card" data-aos="fade-up">
                    <div class="card-header">
                        <i class='bx bx-cog'></i>
                        <h3>Herramientas de Administración</h3>
                    </div>
                    <div class="action-buttons">
                        <asp:Button ID="btnCrearUsuario" runat="server" CssClass="btn-primary" Text="Crear Usuario" />
                        <asp:Button ID="btnAnuncios" runat="server" CssClass="btn-secondary" Text="Anuncios Globales" />
                        <asp:Button ID="btnBackup" runat="server" CssClass="btn-secondary" Text="Backup de Datos" />
                        <asp:Button ID="btnMantenimiento" runat="server" CssClass="btn-danger" Text="Mantenimiento" />
                    </div>
                </div>
            </div>
        </section>

        <!-- Botón de Logout -->
        <a href="../main/index.html" class="logout-btn">
            <i class='bx bx-log-out'></i>
        </a>
    </form>

    <script src="https://unpkg.com/aos@next/dist/aos.js"></script>
    <script>
        AOS.init({
            offset: 100,
            duration: 800
        });
    </script>
</body>
</html>