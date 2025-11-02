<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication3.auth.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>FitBuddy | Iniciar Sesión</title>

    <!-- Estilos externos -->
    <link rel="stylesheet" href="https://unpkg.com/aos@next/dist/aos.css" />
    <link href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" rel="stylesheet" />
    <link rel="stylesheet"  href="../CSS/estilo.css" />
    <link rel="stylesheet" href="../CSS/auth.css" />
</head>

<body>
    <form id="form1" runat="server">
        <header class="header">
            <a href="../main/index.html" class="logo"><span>FitBuddy</span></a>
            <div class="top-btn">
                <a href="../main/index.html" class="nav-btn">VOLVER AL INICIO</a>
            </div>
        </header>

        <section class="auth-section">
            <div class="container">
                <div class="auth-box" data-aos="zoom-in">
                    <div class="auth-header">
                        <h2>Bienvenido a <span>FitBuddy</span></h2>
                        <p>Ingresa tus credenciales para continuar</p>
                    </div>

                    <!-- Formulario de Login -->
                    <div class="auth-form">

                        <!-- Usuario -->
                        <div class="input-box">
                            <i class="bx bx-user"></i>
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="input-field" placeholder="Usuario"></asp:TextBox>
                        </div>

                        <!-- Contraseña -->
                        <div class="input-box">
                            <i class="bx bx-lock-alt"></i>
                            <asp:TextBox ID="txtContrasena" runat="server" CssClass="input-field" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                        </div>

                        <!-- Selección de rol -->
                        <div class="input-box">
                            <i class="bx bx-user-circle"></i>
                            <asp:DropDownList ID="ddlRol" runat="server" CssClass="select-field">
                                <asp:ListItem Text="Selecciona tu perfil" Value=""></asp:ListItem>
                                <asp:ListItem Text="Trainee" Value="Trainee"></asp:ListItem>
                                <asp:ListItem Text="Entrenador" Value="Entrenador"></asp:ListItem>
                                <asp:ListItem Text="Administrador" Value="Administrador"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <!-- Botón -->
                        <asp:Button ID="btnIngresar" runat="server" CssClass="btn auth-btn" Text="Ingresar" OnClick="btnIngresar_Click" />
                    </div>

                    <!-- Mensaje de error -->
                    <asp:Label ID="lblMensaje" runat="server" CssClass="error-text" ForeColor="Red"></asp:Label>

                    <div class="auth-footer">
                        <p class="register-text">
                            ¿No tienes una cuenta?
                            <a href="Register.aspx"><span>Regístrate aquí</span></a>
                        </p>
                    </div>
                </div>
            </div>
        </section>
    </form>

    <!-- Animaciones -->
    <script src="https://unpkg.com/aos@next/dist/aos.js"></script>
    <script>
        AOS.init({
            offset: 100,
            duration: 800
        });
    </script>
</body>
</html>