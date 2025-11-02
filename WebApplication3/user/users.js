// ======================= GESTIÓN DE USUARIOS =======================

/**
 * Obtiene el usuario actual de localStorage
 */
function getCurrentUser() {
    const user = localStorage.getItem("currentUser");
    return user ? JSON.parse(user) : null;
}

/**
 * Cierra la sesión y redirige al login
 */
function logout() {
    localStorage.removeItem("currentUser");
    showNotification("Sesión cerrada correctamente", "success");
    setTimeout(() => {
        window.location.href = "../auth/login.html";
    }, 1500);
}

/**
 * Muestra notificación estilizada
 */
function showNotification(message, type = "info") {
    const notification = document.createElement('div');
    notification.className = `notification ${type}`;
    notification.innerHTML = `
        <div class="notification-content">
            <i class="bx ${type === 'success' ? 'bx-check-circle' : type === 'error' ? 'bx-error-circle' : 'bx-info-circle'}"></i>
            <span>${message}</span>
        </div>
    `;

    notification.style.cssText = `
        position: fixed;
        top: 100px;
        right: 20px;
        background: ${type === 'success' ? 'rgba(69, 255, 202, 0.9)' : type === 'error' ? 'rgba(255, 69, 69, 0.9)' : 'rgba(69, 150, 255, 0.9)'};
        color: #000;
        padding: 1.5rem 2rem;
        border-radius: 1rem;
        font-size: 1.4rem;
        font-weight: 600;
        z-index: 10000;
        box-shadow: 0 5px 15px rgba(0,0,0,0.3);
        transform: translateX(400px);
        transition: transform 0.3s ease;
        max-width: 300px;
    `;

    document.body.appendChild(notification);

    setTimeout(() => {
        notification.style.transform = 'translateX(0)';
    }, 100);

    setTimeout(() => {
        notification.style.transform = 'translateX(400px)';
        setTimeout(() => {
            if (notification.parentNode) {
                notification.parentNode.removeChild(notification);
            }
        }, 300);
    }, 4000);
}

/**
 * Genera datos de ejemplo para la demo
 */
function generateSampleData() {
    // Datos de ejemplo para entrenadores
    const sampleTrainers = [
        { username: "pro_trainer", name: "Carlos Rodríguez", specialty: "CrossFit", experience: "5 años", status: "online" },
        { username: "fit_maria", name: "María González", specialty: "Yoga", experience: "3 años", status: "online" },
        { username: "coach_max", name: "Maximiliano Silva", specialty: "Running", experience: "4 años", status: "busy" },
        { username: "ana_fit", name: "Ana Martínez", specialty: "Pilates", experience: "2 años", status: "offline" }
    ];

    // Datos de ejemplo para usuarios
    const sampleUsers = [
        { username: "runner23", name: "Laura Méndez", level: "Intermedio", goals: "Maratón", status: "online" },
        { username: "fit_guru", name: "Diego Ramírez", level: "Avanzado", goals: "Fuerza", status: "online" },
        { username: "sporty", name: "Sofía Chen", level: "Principiante", goals: "Pérdida de peso", status: "offline" }
    ];

    // Guardar en localStorage si no existen
    if (!localStorage.getItem('sampleTrainers')) {
        localStorage.setItem('sampleTrainers', JSON.stringify(sampleTrainers));
    }
    if (!localStorage.getItem('sampleUsers')) {
        localStorage.setItem('sampleUsers', JSON.stringify(sampleUsers));
    }
}

/**
 * Obtiene el avatar del usuario basado en su nombre
 */
function getUserAvatar(name) {
    return name.split(' ').map(n => n[0]).join('').toUpperCase();
}

/**
 * Inicializa la página de usuario
 */
function initializeUserPage() {
    const currentUser = getCurrentUser();

    if (!currentUser) {
        showNotification("Debes iniciar sesión para acceder a esta página", "error");
        setTimeout(() => {
            window.location.href = "../auth/login.html";
        }, 2000);
        return;
    }

    // Actualizar información del usuario en la página
    const avatarElement = document.querySelector('.user-avatar');
    const nameElement = document.querySelector('.user-details h2');
    const roleElement = document.querySelector('.user-role');

    if (avatarElement) {
        avatarElement.textContent = getUserAvatar(currentUser.username);
    }
    if (nameElement) {
        nameElement.textContent = currentUser.username;
    }
    if (roleElement) {
        roleElement.textContent = currentUser.role === 'trainee' ? 'TRAINEE' :
            currentUser.role === 'trainer' ? 'ENTRENADOR' : 'ADMINISTRADOR';
    }

    // Generar datos de ejemplo para la demo
    generateSampleData();

    // Configurar botón de logout
    const logoutBtn = document.querySelector('.logout-btn');
    if (logoutBtn) {
        logoutBtn.addEventListener('click', (e) => {
            e.preventDefault();
            logout();
        });
    }
}

// Inicializar cuando el DOM esté listo
document.addEventListener('DOMContentLoaded', initializeUserPage);