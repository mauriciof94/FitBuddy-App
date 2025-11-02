<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication3.auth.register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>FitBuddy | Registro</title>

    <!-- Estilos externos -->
    <link rel="stylesheet" href="https://unpkg.com/aos@next/dist/aos.css" />
    <link href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../CSS/estilo.css" />
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
                        <h2>Únete a <span>FitBuddy</span></h2>
                        <p>Crea tu cuenta y empieza a entrenar</p>
                    </div>

                    <!-- Formulario ASP.NET -->
                    <div class="auth-form">
                        <!-- Usuario -->
                        <div class="input-box">
                            <i class="bx bx-user"></i>
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="input-field" placeholder="Usuario"></asp:TextBox>
                        </div>

                        <!-- Email -->
                        <div class="input-box">
                            <i class="bx bx-envelope"></i>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="input-field" TextMode="Email" placeholder="Correo electrónico"></asp:TextBox>
                        </div>

                        <!-- Contraseña -->
                        <div class="input-box">
                            <i class="bx bx-lock-alt"></i>
                            <asp:TextBox ID="txtContrasena" runat="server" CssClass="input-field" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                        </div>

                        <!-- Perfil -->
                        <div class="input-box">
                            <i class="bx bx-user-circle"></i>
                            <asp:DropDownList ID="ddlRol" runat="server" CssClass="select-field">
                                <asp:ListItem Text="Selecciona tu perfil" Value=""></asp:ListItem>
                                <asp:ListItem Text="Trainee" Value="Trainee"></asp:ListItem>
                                <asp:ListItem Text="Entrenador" Value="Entrenador"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <!-- Botón -->
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn auth-btn" Text="Registrarme" OnClick="btnRegistrar_Click" />
                    </div>

                    <!-- Mensaje -->
                    <asp:Label ID="lblMensaje" runat="server" CssClass="error-text" ForeColor="Red"></asp:Label>

                    <div class="auth-footer">
                        <p class="register-text">
                            ¿Ya tienes una cuenta?
                            <a href="login.aspx"><span>Inicia sesión</span></a>
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