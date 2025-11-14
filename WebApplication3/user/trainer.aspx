<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trainer.aspx.cs" Inherits="WebApplication3.user.trainer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>FitBuddy | Panel Trainer</title>

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
                <a href="#clientes">Mis Clientes</a>
                <a href="#rutinas">Rutinas</a>
                <a href="#agenda">Agenda</a>
                <a href="#estadisticas">Estadísticas</a>
            </nav>
        </header>

        <section class="users-section" id="dashboard">
            <div class="user-container">
                <div class="user-header">
                    <h1>Panel de Entrenador</h1>
                    <p>Gestiona tu comunidad y ayuda a otros a alcanzar sus metas</p>
                </div>

                <!-- Información del Entrenador -->
                <div class="user-info">
                    <div class="user-profile">
                        <div class="user-avatar">EN</div>
                        <div class="user-details">
                            <h2><asp:Label ID="lblNombreTrainer" runat="server" Text="Cargando..."></asp:Label></h2>
                            <span class="user-role">ENTRENADOR</span>
                        </div>
                    </div>

                    <div class="user-stats">
                        <div class="stat-card">
                            <span class="stat-number"><asp:Label ID="lblClientesActivos" runat="server" Text="0"></asp:Label></span>
                            <span class="stat-label">Clientes Activos</span>
                        </div>
                        <div class="stat-card">
                            <span class="stat-number"><asp:Label ID="lblSesionesImpartidas" runat="server" Text="0"></asp:Label></span>
                            <span class="stat-label">Sesiones Impartidas</span>
                        </div>
                        <div class="stat-card">
                            <span class="stat-number"><asp:Label ID="lblRatingPromedio" runat="server" Text="0.0"></asp:Label></span>
                            <span class="stat-label">Rating Promedio</span>
                        </div>
                        <div class="stat-card">
                            <span class="stat-number"><asp:Label ID="lblRutinasCreadas" runat="server" Text="0"></asp:Label></span>
                            <span class="stat-label">Rutinas Creadas</span>
                        </div>
                    </div>
                </div>

                <!-- Dashboard Grid -->
                <div class="dashboard-grid">

                    <!-- 🔹 CHATS CON TRAINEES -->
                    <div class="dashboard-card">
                        <div class="card-header">
                            <i class='bx bx-chat'></i>
                            <h3>Chats con Trainees</h3>
                        </div>

                        <asp:Repeater ID="rptTraineesChat" runat="server">
                            <ItemTemplate>
                                <div class="user-item">
                                    <div class="user-avatar-small" style="background: var(--gradient);"><%# Eval("Iniciales") %></div>
                                    <div class="user-item-info">
                                        <h4><%# Eval("Nombre") %> (ID: <%# Eval("IdTrainee") %>)</h4>
                                        <p><%# Eval("Email") %></p>
                                    </div>
                                    <asp:Button ID="btnChatTrainee" runat="server" CssClass="btn-secondary" 
                                        Text="Abrir Chat"
                                        CommandArgument='<%# Eval("IdTrainee") %>'
                                        OnCommand="AbrirChatTrainee_Command" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <!-- Agenda -->
                    <div class="dashboard-card">
                        <div class="card-header">
                            <i class='bx bx-calendar'></i>
                            <h3>Agenda de Hoy</h3>
                        </div>
                        <asp:Repeater ID="rptAgenda" runat="server">
                            <ItemTemplate>
                                <div class="user-item">
                                    <div class="user-avatar-small" style="background: var(--gradient);"><%# Eval("Iniciales") %></div>
                                    <div class="user-item-info">
                                        <h4><%# Eval("Cliente") %></h4>
                                        <p><%# Eval("Actividad") %></p>
                                    </div>
                                    <span class="user-status status-online"><%# Eval("Estado") %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="action-buttons">
                            <asp:Button ID="btnNuevaCita" runat="server" CssClass="btn-primary" Text="Nueva Cita" />
                            <asp:Button ID="btnVerAgenda" runat="server" CssClass="btn-secondary" Text="Ver Agenda Completa" />
                        </div>
                    </div>

                    <!-- Rutinas Creadas -->
                    <div class="dashboard-card">
                        <div class="card-header">
                            <i class='bx bx-task'></i>
                            <h3>Mis Rutinas</h3>
                        </div>
                        <asp:Repeater ID="rptRutinas" runat="server">
                            <ItemTemplate>
                                <div class="user-item">
                                    <div class="user-avatar-small" style="background: var(--gradient);"><%# Eval("Iniciales") %></div>
                                    <div class="user-item-info">
                                        <h4><%# Eval("Nombre") %></h4>
                                        <p><%# Eval("Detalle") %></p>
                                    </div>
                                    <span class="user-status status-online"><%# Eval("Estado") %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="action-buttons">
                            <asp:Button ID="btnCrearRutina" runat="server" CssClass="btn-primary" Text="Crear Rutina" OnClick="btnCrearRutina_Click" />
                            <asp:Button ID="btnEditarRutinas" runat="server" CssClass="btn-secondary" Text="Editar/Eliminar Rutinas" OnClick="btnEditarRutinas_Click" />
                        </div>
                    </div>

                    <!-- Rutas Creadas -->
                    <div class="dashboard-card">
                        <div class="card-header">
                            <i class='bx bx-map'></i>
                            <h3>Mis Rutas</h3>
                        </div>
                        <asp:Repeater ID="rptRutas" runat="server">
                            <ItemTemplate>
                                <div class="user-item">
                                    <div class="user-avatar-small" style="background: var(--gradient);"><%# Eval("Iniciales") %></div>
                                    <div class="user-item-info">
                                        <h4><%# Eval("Nombre") %></h4>
                                        <p><%# Eval("Descripcion") %></p>
                                    </div>
                                    <span class="user-status status-online"><%# Eval("Estado") %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="action-buttons">
                            <asp:Button ID="btnCrearRuta" runat="server" CssClass="btn-primary" Text="Crear Ruta" OnClick="btnCrearRuta_Click" />
                            <asp:Button ID="btnGestionarRutas" runat="server" CssClass="btn-secondary" Text="Gestionar Rutas" OnClick="btnGestionarRutas_Click" />
                        </div>
                    </div>

                    <!-- Métricas -->
                    <div class="dashboard-card">
                        <div class="card-header">
                            <i class='bx bx-trending-up'></i>
                            <h3>Métricas del Mes</h3>
                        </div>
                        <div class="user-list">
                            <div class="user-item">
                                <div class="user-item-info">
                                    <h4>Ingresos Totales</h4>
                                    <p><asp:Label ID="lblIngresos" runat="server" Text="$0 USD"></asp:Label></p>
                                </div>
                                <span class="user-status status-online">+15%</span>
                            </div>
                            <div class="user-item">
                                <div class="user-item-info">
                                    <h4>Nuevos Clientes</h4>
                                    <p><asp:Label ID="lblNuevosClientes" runat="server" Text="0 este mes"></asp:Label></p>
                                </div>
                                <span class="user-status status-online">+25%</span>
                            </div>
                            <div class="user-item">
                                <div class="user-item-info">
                                    <h4>Sesiones Completadas</h4>
                                    <p><asp:Label ID="lblSesionesCompletadas" runat="server" Text="0 sesiones"></asp:Label></p>
                                </div>
                                <span class="user-status status-online">+10%</span>
                            </div>
                        </div>
                        <div class="action-buttons">
                            <asp:Button ID="btnVerDetalles" runat="server" CssClass="btn-primary" Text="Ver Detalles" />
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Logout -->
        <a href="../main/index.html" class="logout-btn">
            <i class='bx bx-log-out'></i>
        </a>
    </form>
</body>
</html>