<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RutasCompartidas.aspx.cs" Inherits="WebApplication3.modulos.RutasCompartidas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <title>FitBuddy | Rutas Compartidas</title>

    <!-- Leaflet para mapas -->
    <link rel="stylesheet" href="https://unpkg.com/leaflet/dist/leaflet.css" />
    <script src="https://unpkg.com/leaflet/dist/leaflet.js"></script>
    
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />
    
    <!-- Estilos FitBuddy -->
    <link rel="stylesheet" href="../CSS/estilo.css" />
    <link rel="stylesheet" href="../CSS/users.css" />

    <style>
        body { padding-top: 8.5rem; }
        
        /* Tabla */
        .tabla { 
            width: 100%; 
            border-collapse: collapse; 
            background: rgba(255, 255, 255, 0.05);
        }
        
        .tabla th { 
            padding: 1.5rem 1rem; 
            text-align: left; 
            font-size: 1.5rem; 
            border-bottom: 2px solid var(--main-color, #45ffca);
            color: var(--main-color, #45ffca);
            font-weight: 600;
            background: rgba(69, 255, 202, 0.1);
        }
        
        .tabla td { 
            padding: 1.5rem 1rem; 
            text-align: left; 
            font-size: 1.4rem; 
            border-bottom: 1px solid rgba(255,255,255,0.08);
            vertical-align: middle;
        }
        
        .tabla tr:hover { 
            background: rgba(69,255,202,0.05);
            transition: all 0.3s ease;
        }
        
        .user-list { 
            width: 100%; 
            overflow-x: auto;
            max-height: 600px;
            overflow-y: auto;
        }
        
        /* Botón ver mapa */
        .btn-map {
            background: linear-gradient(135deg, #45ffca 0%, #6effe0 100%);
            color: #000;
            border: none;
            padding: 0.8rem 1.5rem;
            border-radius: 0.8rem;
            font-weight: 600;
            font-size: 1.3rem;
            cursor: pointer;
            transition: all 0.3s ease;
            display: inline-flex;
            align-items: center;
            gap: 0.5rem;
        }
        
        .btn-map:hover {
            transform: translateY(-2px);
            box-shadow: 0 5px 15px rgba(69, 255, 202, 0.4);
        }
        
        /* Modal para mapa */
        .modal {
            display: none;
            position: fixed;
            z-index: 1000;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.8);
            backdrop-filter: blur(5px);
        }
        
        .modal-content {
            background: var(--second-bg-color, #111);
            margin: 5% auto;
            padding: 2rem;
            border-radius: 1.5rem;
            width: 90%;
            max-width: 800px;
            border: 2px solid rgba(69, 255, 202, 0.3);
            position: relative;
            animation: modalFade 0.3s ease;
        }
        
        @keyframes modalFade {
            from { opacity: 0; transform: translateY(-50px); }
            to { opacity: 1; transform: translateY(0); }
        }
        
        .close-modal {
            position: absolute;
            top: 1rem;
            right: 1.5rem;
            color: var(--main-color, #45ffca);
            font-size: 2.5rem;
            cursor: pointer;
            background: none;
            border: none;
            z-index: 1001;
        }
        
        .close-modal:hover {
            color: #fff;
        }
        
        #mapPreview {
            height: 400px;
            width: 100%;
            border-radius: 1rem;
            margin-top: 1rem;
            border: 2px solid rgba(69, 255, 202, 0.2);
        }
        
        .route-info {
            margin: 1.5rem 0;
            padding: 1.5rem;
            background: rgba(69, 255, 202, 0.1);
            border-radius: 1rem;
            border: 1px solid rgba(69, 255, 202, 0.2);
        }
        
        .route-info h4 {
            color: var(--main-color, #45ffca);
            margin-bottom: 0.8rem;
            font-size: 1.6rem;
        }
        
        .route-info p {
            color: #ccc;
            font-size: 1.4rem;
            margin: 0.3rem 0;
        }
        
        /* Responsive */
        @media (max-width: 768px) {
            .modal-content {
                width: 95%;
                margin: 10% auto;
                padding: 1.5rem;
            }
            
            #mapPreview {
                height: 300px;
            }
            
            .tabla th, .tabla td {
                padding: 1rem 0.5rem;
                font-size: 1.3rem;
            }
        }
        
        /* Scrollbar personalizado */
        .user-list::-webkit-scrollbar {
            width: 8px;
            height: 8px;
        }
        
        .user-list::-webkit-scrollbar-thumb {
            background: var(--main-color, #45ffca);
            border-radius: 10px;
        }
        
        .user-list::-webkit-scrollbar-track {
            background: rgba(255, 255, 255, 0.05);
            border-radius: 10px;
        }
        
        /* No Data Message */
        .no-data {
            text-align: center;
            padding: 3rem;
            color: #ccc;
            font-size: 1.6rem;
        }
        
        .no-data i {
            font-size: 4rem;
            color: var(--main-color, #45ffca);
            margin-bottom: 1rem;
            display: block;
        }
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
                            <!-- GridView con RowDataBound -->
                            <asp:GridView ID="gvRutasCompartidas" runat="server" 
                                AutoGenerateColumns="False" 
                                CssClass="tabla"
                                OnRowDataBound="gvRutasCompartidas_RowDataBound"
                                EmptyDataText="No hay rutas compartidas disponibles">
                                <Columns>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                    <asp:TemplateField HeaderText="Ver Ruta">
                                        <ItemTemplate>
                                            <asp:Button ID="btnVerMapa" runat="server" 
                                                Text="Ver Mapa" 
                                                CssClass="btn-map"
                                                OnClientClick="return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
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

    <!-- Modal para mostrar el mapa -->
    <div id="mapModal" class="modal">
        <div class="modal-content">
            <button class="close-modal" onclick="cerrarModal()">&times;</button>
            <h3 id="modalTitle" style="color: var(--main-color, #45ffca); margin-bottom: 1.5rem;"></h3>
            
            <div class="route-info">
                <h4 id="routeName"></h4>
                <p id="routeDescription"></p>
                <p><strong>Entrenador ID:</strong> <span id="routeTrainer"></span></p>
                <p><strong>Puntos:</strong> <span id="routePoints"></span></p>
            </div>
            
            <div id="mapPreview"></div>
            
            <div style="margin-top: 1.5rem; text-align: center;">
                <button class="btn-map" onclick="cerrarModal()">
                    <i class="fa-solid fa-xmark"></i> Cerrar
                </button>
            </div>
        </div>
    </div>

    <footer class="footer">
        <p>&copy; 2025 FitBuddy — Todos los derechos reservados.</p>
    </footer>

    <script>
        // Variables globales
        var map;
        var currentRoute;

        // Función para mostrar ruta desde botón
        function mostrarRutaDesdeAtributos(puntosJson, nombre, descripcion, trainerId) {
            mostrarRuta(puntosJson, nombre, descripcion, trainerId);
        }

        // Función principal para mostrar la ruta
        function mostrarRuta(puntosJson, nombre, descripcion, trainerId) {
            try {
                console.log('Mostrando ruta:', nombre);
                console.log('Puntos JSON:', puntosJson);

                // Parsear los puntos JSON
                var puntos = JSON.parse(puntosJson);

                // Mostrar información en el modal
                document.getElementById('modalTitle').textContent = 'Ruta: ' + nombre;
                document.getElementById('routeName').textContent = nombre;
                document.getElementById('routeDescription').textContent = descripcion || 'Sin descripción';
                document.getElementById('routeTrainer').textContent = trainerId || 'No especificado';
                document.getElementById('routePoints').textContent = puntos.length + ' puntos de ruta';

                // Mostrar modal
                document.getElementById('mapModal').style.display = 'block';

                // Inicializar mapa
                setTimeout(function () {
                    mostrarMapa(puntos);
                }, 50);

            } catch (error) {
                console.error('Error al parsear puntos:', error);

                // Mostrar mensaje de error
                document.getElementById('modalTitle').textContent = 'Error al cargar la ruta';
                document.getElementById('routeName').textContent = nombre;
                document.getElementById('routeDescription').textContent = 'No se pudo cargar la información de la ruta. Los datos pueden estar corruptos.';
                document.getElementById('routeTrainer').textContent = trainerId || 'N/A';
                document.getElementById('routePoints').textContent = 'Datos no disponibles';

                document.getElementById('mapModal').style.display = 'block';

                // Mostrar mapa de error
                setTimeout(function () {
                    mostrarMapaError();
                }, 50);
            }
        }

        // Función para mostrar el mapa con la ruta
        function mostrarMapa(puntos) {
            // Limpiar mapa existente
            if (map) {
                map.remove();
            }

            // Crear nuevo mapa
            map = L.map('mapPreview').setView([-34.6037, -58.3816], 13);

            // Agregar capa de OpenStreetMap
            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
                maxZoom: 19
            }).addTo(map);

            // Dibujar la ruta si hay puntos
            if (puntos && puntos.length > 0) {
                // Calcular centro
                var sumLat = 0, sumLng = 0;
                puntos.forEach(function (punto) {
                    sumLat += punto[0];
                    sumLng += punto[1];
                });
                var centerLat = sumLat / puntos.length;
                var centerLng = sumLng / puntos.length;

                // Centrar mapa
                map.setView([centerLat, centerLng], 13);

                // Crear polilínea
                currentRoute = L.polyline(puntos, {
                    color: '#45ffca',
                    weight: 4,
                    opacity: 0.8,
                    smoothFactor: 1
                }).addTo(map);

                // Agregar marcadores
                puntos.forEach(function (punto, index) {
                    var marker = L.marker([punto[0], punto[1]]).addTo(map);

                    var popupContent = '<div style="color: #000; font-weight: bold; padding: 5px;">';
                    popupContent += 'Punto ' + (index + 1);
                    if (index === 0) popupContent += '<br><small style="color: green; font-weight: bold;">🏁 INICIO</small>';
                    if (index === puntos.length - 1) popupContent += '<br><small style="color: red; font-weight: bold;">🎯 FIN</small>';
                    popupContent += '</div>';

                    marker.bindPopup(popupContent);
                });

                // Ajustar vista
                map.fitBounds(currentRoute.getBounds());

                // Abrir popups de inicio y fin
                if (puntos.length > 0) {
                    L.marker([puntos[0][0], puntos[0][1]]).addTo(map)
                        .bindPopup('<div style="color: #000; font-weight: bold;">🏁 PUNTO DE INICIO</div>')
                        .openPopup();

                    if (puntos.length > 1) {
                        L.marker([puntos[puntos.length - 1][0], puntos[puntos.length - 1][1]]).addTo(map)
                            .bindPopup('<div style="color: #000; font-weight: bold;">🎯 PUNTO FINAL</div>');
                    }
                }
            } else {
                // Si no hay puntos, mostrar mensaje
                L.marker([-34.6037, -58.3816]).addTo(map)
                    .bindPopup('<div style="color: #000; font-weight: bold;">Ruta sin puntos definidos</div>')
                    .openPopup();
            }
        }

        // Función para mostrar mapa con error
        function mostrarMapaError() {
            if (map) {
                map.remove();
            }

            map = L.map('mapPreview').setView([-34.6037, -58.3816], 13);

            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; OpenStreetMap contributors'
            }).addTo(map);

            L.marker([-34.6037, -58.3816]).addTo(map)
                .bindPopup('<div style="color: red; font-weight: bold; padding: 10px;">Error: No se pudo cargar la ruta</div>')
                .openPopup();
        }

        // Función para cerrar el modal
        function cerrarModal() {
            document.getElementById('mapModal').style.display = 'none';

            // Limpiar mapa
            if (map) {
                map.remove();
                map = null;
            }
        }

        // Cerrar modal al hacer clic fuera
        window.onclick = function (event) {
            var modal = document.getElementById('mapModal');
            if (event.target == modal) {
                cerrarModal();
            }
        }

        // Cerrar con tecla ESC
        document.addEventListener('keydown', function (event) {
            if (event.key === 'Escape') {
                cerrarModal();
            }
        });

        // Asignar eventos a los botones después de cargar la página
        document.addEventListener('DOMContentLoaded', function () {
            // Esta función se ejecutará después de que RowDataBound haya configurado los botones
            setTimeout(function () {
                var mapButtons = document.querySelectorAll('.btn-map');
                mapButtons.forEach(function (button) {
                    button.addEventListener('click', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                    });
                });
            }, 100);
        });
    </script>
</body>
</html>