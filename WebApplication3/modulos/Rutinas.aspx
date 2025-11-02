<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rutinas.aspx.cs" Inherits="WebApplication3.modulos.Rutinas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <title>FitBuddy | Gestionar Rutinas</title>

    <!-- Hojas de estilo -->
    <link rel="stylesheet" href="../CSS/estilo.css" />
    <link rel="stylesheet" href="../CSS/users.css" />

    <!-- Íconos -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />

    <!-- Ajuste local para evitar que el header fijo tape el contenido -->
    <style>
        /* Ajusta este padding-top si el header cambia de alto.
           body padding evita que el header fijo se superponga al contenido. */
        body {
            padding-top: 8.5rem; /* valor pensado para tu header; reducelo/aumentalo si hace falta */
        }

        /* Pequeñas mejoras visuales para GridView (opcional) */
        .tabla {
            width: 100%;
            border-collapse: collapse;
        }
        .tabla th, .tabla td {
            padding: 1rem;
            text-align: left;
            font-size: 1.4rem;
            border-bottom: 1px solid rgba(255,255,255,0.06);
        }
        .tabla tr:hover {
            background: rgba(69,255,202,0.03);
        }

        /* Aseguramos que el GridView ocupe bien el contenedor */
        .user-list {
            width: 100%;
            overflow-x: auto;
        }
    </style>
</head>

<body>
    <!-- HEADER (usa los selectores que ya existen en estilo.css) -->
    <header>
        <a class="logo" href="../Home.aspx">Fit<span>Buddy</span></a>

        <div id="menu-icon"><i class="fa fa-bars"></i></div>

        <nav class="navbar">
            <a href="../user/trainer.aspx">Inicio</a>
            <a href="../modulos/CrearRutina.aspx">Crear Rutina</a>
            <a href="../modulos/Rutinas.aspx" class="active">Mis Rutinas</a>
            <a href="../modulos/Perfil.aspx">Perfil</a>
        </nav>
    </header>

    <!-- CONTENIDO PRINCIPAL -->
    <main>
        <form id="form1" runat="server">
            <section class="users-section">
                <div class="user-container">
                    <div class="user-header">
                        <h1>Gestión de Rutinas</h1>
                        <p>Visualizá, editá o eliminá tus rutinas de entrenamiento</p>
                    </div>

                    <div class="dashboard-card">
                        <div class="card-header">
                            <i class="fa-solid fa-dumbbell"></i>
                            <h3>Listado de Rutinas</h3>
                        </div>

                        <!-- TABLA DE RUTINAS -->
                        <div class="user-list">
                            <asp:GridView ID="gvRutinas" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="IdRutina" CssClass="tabla"
                                OnRowCommand="gvRutinas_RowCommand">

                                <Columns>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Nivel" HeaderText="Nivel" />
                                    <asp:BoundField DataField="DuracionMinutos" HeaderText="Duración (min)" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEditar" runat="server"
                                                CommandName="EditarRutina"
                                                CommandArgument='<%# Eval("IdRutina") %>'
                                                Text="Editar" CssClass="btn-secondary" />
                                            <asp:Button ID="btnEliminar" runat="server"
                                                CommandName="EliminarRutina"
                                                CommandArgument='<%# Eval("IdRutina") %>'
                                                Text="Eliminar" CssClass="btn-danger" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                        <!-- BOTONES DE ACCIÓN -->
                        <div class="action-buttons" style="margin-top:1.8rem;">
                            <asp:Button ID="btnNueva" runat="server" Text="Crear Nueva Rutina"
                                CssClass="btn-primary" OnClick="btnNueva_Click" />
                            <asp:Button ID="btnVolver" runat="server" Text="Volver"
                                CssClass="btn-secondary" OnClick="btnVolver_Click" />
                        </div>
                    </div>
                </div>
            </section>
        </form>
    </main>

    <!-- FOOTER -->
    <footer class="footer">
        <p class="copyright">&copy; 2025 FitBuddy — Todos los derechos reservados.</p>
        <div class="social">
            <a href="#"><i class="fa-brands fa-instagram"></i></a>
            <a href="#"><i class="fa-brands fa-facebook"></i></a>
            <a href="#"><i class="fa-brands fa-x-twitter"></i></a>
        </div>
    </footer>
</body>
</html>