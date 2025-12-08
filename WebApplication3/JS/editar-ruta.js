// ===============================
// MAPA DE EDICIÓN DE RUTA
// ===============================

var map;
var drawnRoute = null;
var routePoints = [];

function inicializarMapa() {
    map = L.map('mapEditor').setView([-34.6037, -58.3816], 13);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; OpenStreetMap contributors',
        maxZoom: 19
    }).addTo(map);

    // Permitir agregar puntos
    map.on('click', function (event) {
        var lat = event.latlng.lat;
        var lng = event.latlng.lng;

        routePoints.push([lat, lng]);
        actualizarRuta();
        guardarEnHidden();
    });
}

// Dibuja la ruta
function actualizarRuta() {
    if (drawnRoute) {
        drawnRoute.remove();
    }

    if (routePoints.length > 0) {
        drawnRoute = L.polyline(routePoints, {
            color: '#45ffca',
            weight: 4,
            opacity: 0.8
        }).addTo(map);

        map.fitBounds(drawnRoute.getBounds());
    }
}

// Cargar puntos existentes desde el HiddenField (cuando editamos)
function cargarPuntosGuardados() {
    var json = document.getElementById("hfPuntos").value;

    if (!json || json.trim() === "") return;

    try {
        routePoints = JSON.parse(json);
        actualizarRuta();
    } catch (e) {
        console.error("Error cargando JSON:", e);
    }
}

// Guarda los puntos en el HiddenField
function guardarEnHidden() {
    document.getElementById("hfPuntos").value = JSON.stringify(routePoints);
}

// Inicializar el mapa al cargar la página
window.addEventListener("load", function () {
    inicializarMapa();
    cargarPuntosGuardados();
});
