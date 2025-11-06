# 🏋️‍♂️ FitBuddy - Tu Compañero de Entrenamiento

## 📋 Descripción del Proyecto

**FitBuddy** es una aplicación web desarrollada en **ASP.NET Web Forms** que conecta usuarios y entrenadores para mejorar la experiencia del entrenamiento.  
La aplicación permite registrarse, configurar perfiles, buscar compañeros de entrenamiento mediante filtros de ubicación y objetivos, crear y compartir rutinas o rutas, comunicarse a través de chat interno y llevar un historial de entrenamientos.

> **🔬 Trabajo Práctico Integrador Final**  
> *Carrera:* Técnico Superior de Analista de Sistemas  
> *Institución:* IFTS 18 - Prácticas Profesionales III  
> *Año:* 2025

**Diferencial clave:** A diferencia de otras aplicaciones deportivas, FitBuddy se centra en generar vínculos reales y motivación compartida, combinando tecnología con el aspecto social del entrenamiento.

---

## 🚀 Características Principales

### 👥 Para Usuarios (Trainees)
- **Emparejamiento Inteligente**: Conecta con entrenadores y compañeros según objetivos.  
- **Rutinas Personalizadas**: Accede a rutinas adaptadas a tu nivel.  
- **Gestión de Rutas**: Planifica y comparte rutas de entrenamiento.  
- **Seguimiento de Progreso**: Historial completo de entrenamientos.  
- **Chat Integrado**: Comunicación directa con entrenadores y compañeros.

### 👨‍🏫 Para Entrenadores
- **Gestión de Clientes**: Administra tu cartera de clientes.  
- **Creación de Rutinas**: Diseña y comparte entrenamientos personalizados.  
- **Perfil Profesional**: Muestra tu experiencia y especialidades.  
- **Comunicación Directa**: Chat integrado con tus clientes.

### ⚙️ Para Administradores
- **Gestión de Usuarios**: Control completo sobre la comunidad.  
- **Verificación de Entrenadores**: Aprobación de perfiles profesionales.  
- **Moderación de Contenido**: Gestión de rutinas y rutas compartidas.

---

## 📱 Funcionalidades por Módulo

### 🔐 Autenticación
- Registro de usuarios (Trainee/Entrenador)
- Inicio de sesión seguro
- Gestión de sesiones
- Control de acceso por roles

### 👤 Gestión de Perfiles
- Creación y edición de perfiles
- Configuración de objetivos deportivos
- Especializaciones para entrenadores
- Preferencias de entrenamiento

### 🏃 Módulo de Rutinas
- Creación de rutinas personalizadas
- Asignación a usuarios específicos
- Seguimiento de progreso
- Compartición entre usuarios

### 🗺️ Módulo de Rutas
- Planificación de rutas de ejercicio
- Compartición con la comunidad
- Filtrado por ubicación y dificultad
- Historial de rutas completadas

### 💬 Sistema de Chat
- Mensajería interna entre usuarios
- Comunicación trainee-entrenador
- Historial de conversaciones
- Notificaciones en tiempo real

---

## 🎯 Casos de Uso Principales

### Para Nuevos Usuarios
- Registro → Selección de rol → Confirmación → Login  
- Personalización → Configuración de perfil → Establecimiento de objetivos  
- Exploración → Búsqueda de compañeros/entrenadores → Conexión

### Flujo Trainee
- **Entrenamiento:** Buscar rutinas → Seguir progreso → Completar sesiones  
- **Social:** Encontrar compañeros → Coordinar entrenamientos → Compartir logros  
- **Planificación:** Agenda personal → Recordatorios → Seguimiento de metas

### Flujo Entrenador
- **Clientes:** Gestionar clientes → Comunicarse → Programar sesiones  
- **Contenido:** Crear rutinas → Personalizar → Publicar  
- **Profesional:** Perfil público → Especializaciones → Reputación

---

## 🔒 Seguridad

- Autenticación por sesiones ASP.NET  
- Validación de entrada en todos los formularios  
- Protección contra SQL Injection mediante parámetros  
- Control de acceso por roles (Trainee, Entrenador, Admin)  
- Manejo seguro de contraseñas  

---

## 🚀 Despliegue

### Requisitos de Producción
- Windows Server con IIS  
- SQL Server 2016 o superior  
- .NET Framework 4.8  
- Certificado SSL para HTTPS  

### Pasos de Despliegue
1. Publicar aplicación desde Visual Studio  
2. Configurar base de datos en servidor  
3. Configurar IIS con pool de aplicaciones  
4. Establecer conexiones y permisos  
5. Configurar dominio y certificado SSL  

---

## 🏗️ Arquitectura del Sistema

### 📐 Tecnologías Utilizadas

| Capa | Tecnologías |
|------|--------------|
| **Frontend** | ASP.NET Web Forms, HTML5, CSS3, JavaScript |
| **Backend** | C#, ASP.NET Web Forms, ADO.NET |
| **Base de Datos** | SQL Server con LINQ to SQL |
| **Autenticación** | ASP.NET Identity (Session-based) |
| **Control de Versiones** | GitHub |
| **Diseño UI/UX** | Figma |

---

### 🗂️ Estructura del Proyecto

```
FitBuddy-App/
├── 📁 auth/                     # Sistema de autenticación
│   ├── 🔐 login.aspx            # Página de inicio de sesión
│   ├── 📝 register.aspx         # Página de registro
│   └── ⚡ login.aspx.cs         # Lógica de autenticación
├── 📁 css/                      # Hojas de estilo
│   ├── 🎨 estilo.css            # Estilos principales
│   └── 🎨 auth.css              # Estilos de autenticación
├── 📁 main/                     # Páginas principales
│   ├── 🏠 default.aspx          # Página principal
│   └── ⚡ default.aspx.cs       # Lógica de la página principal
├── 📁 user/                     # Paneles de usuario
│   ├── 👤 trainee.aspx          # Panel de usuario Trainee
│   ├── 👨‍🏫 trainer.aspx         # Panel de usuario Trainer
│   ├── ⚙️ admin.aspx            # Panel de administrador
│   └── ⚡ archivos .cs          # Lógica de cada panel
├── 📁 modules/                  # Módulos funcionales
│   ├── 💬 chat.aspx             # Sistema de mensajería
│   ├── 🏃 rutinas.aspx          # Gestión de rutinas
│   ├── 🗺️ rutas.aspx            # Gestión de rutas
│   └── ⚡ archivos .cs          # Lógica de módulos
├── 📁 Clases/                   # Capa de negocio y datos
│   ├── 🏷️ Trainee.cs            # Entidad Usuario
│   ├── 🏷️ Entrenador.cs         # Entidad Entrenador
│   ├── 🏷️ Rutina.cs             # Entidad Rutina
│   ├── 📊 RutinaDAO.cs          # Acceso a datos de rutinas
│   ├── 👤 UsuarioDAO.cs         # Acceso a datos de usuarios
│   └── 🔗 Conexion.cs           # Gestión de conexiones BD
├── 📁 image/                    # Recursos visuales
├── 📄 Web.config                # Configuración de la aplicación
└── 📄 packages.config           # Dependencias de NuGet
```

---

## 🗃️ Modelo de Datos

### Principales Entidades
- **Usuarios**: Gestión de perfiles de trainees y entrenadores.  
- **Rutinas**: Creación y seguimiento de planes de entrenamiento.  
- **Rutas**: Planificación y compartición de rutas de ejercicio.  
- **Mensajes**: Sistema de comunicación interna.  
- **Historial**: Registro de entrenamientos completados.

---

## 🔧 Configuración y Ejecución

### Prerrequisitos
- **Visual Studio 2022** o superior  
- **.NET Framework 4.8**  
- **SQL Server** (LocalDB o Express)  
- **IIS Express** (incluido en Visual Studio)

### 🚀 Ejecución Local

1. **Clona el repositorio:**
   ```bash
   git clone https://github.com/mauriciof94/FitBuddy-App.git
   ```

2. **Abre el proyecto en Visual Studio:**
   - Abre `WebApplication3.csproj` o la solución correspondiente  
   - Restaura los paquetes NuGet si es necesario

3. **Configura la base de datos:**
   - Ejecuta los scripts SQL para crear la base de datos  
   - Configura la cadena de conexión en `Web.config`

4. **Ejecuta la aplicación:**
   - Presiona **F5** o selecciona **IIS Express**  
   - La aplicación se abrirá en `https://localhost:[puerto]`

---

### ⚙️ Configuración de Base de Datos

En el archivo `Web.config`, configura tu cadena de conexión:

```xml
<connectionStrings>
  <add name="FitBuddyConnection" 
       connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FitBuddyDB;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

---

## 👥 Equipo de Desarrollo

| Nombre | Rol Principal | Tecnologías |
|--------|----------------|-------------|
| **Fernandez, Mauricio** | Backend & Database | C#, ASP.NET, SQL Server |
| **Rojas, Maximiliano** | Frontend & UI/UX | ASP.NET Web Forms, CSS3 |
| **Ledesma, Emmanuel** | Arquitectura & Integración | C#, ADO.NET, Pruebas |

---

## 📈 Próximas Características

### 🚀 En Desarrollo
- ✅ Sistema de chat en tiempo real  
- 🔄 Mejoras en responsive design  
- 📊 Panel de métricas avanzadas  

### 📅 Planificado para V2
- Integración con APIs de mapas  
- Sistema de notificaciones push  
- Aplicación móvil nativa  
- Integración con wearables  

---

## 🤝 Contribución

### Para Colaboradores
1. Fork del proyecto  
2. Crear rama de feature: `git checkout -b feature/nueva-funcionalidad`  
3. Commit cambios: `git commit -m 'feat: agregar funcionalidad'`  
4. Push a la rama: `git push origin feature/nueva-funcionalidad`  
5. Pull Request  

### Convenciones
- C#: Patrón de nomenclatura PascalCase  
- Base de datos: Scripts versionados  
- Commits: Conventional commits  
- Documentación: Mantenimiento actualizado  

---

## 📞 Soporte y Contacto

- **Repositorio:** [https://github.com/mauriciof94/FitBuddy-App](https://github.com/mauriciof94/FitBuddy-App)  
- **Documentación Técnica:** Incluida en el repositorio  
- **Equipo:** Contacto a través de los canales académicos  

---

<div align="center">

🎓 **IFTS 18 - Prácticas Profesionales III**  
*Técnico Superior de Analista de Sistemas*  
**Trabajo Práctico Integrador Final - 2025**  

💪 ¡Conectando pasión, tecnología y entrenamiento! 🚀  

</div>

---

## 🔄 Historial de Versiones

### v2.0.0 (Actual - ASP.NET)
- ✅ Migración completa a **ASP.NET Web Forms**  
- ✅ Base de datos **SQL Server** integrada  
- ✅ Sistema de autenticación por roles  
- ✅ Módulos de rutinas y rutas funcionales  
- ✅ Arquitectura en capas (**N-Tier**)  

### v1.0.0 (Anterior - HTML/CSS/JS) -> https://github.com/EmmaLedesma/SITIO_APP_FITBUDDY-MASTER
- ✅ Prototipo funcional **frontend**  
- ✅ Diseño **responsive**  
- ✅ Persistencia con **localStorage**  

---

¿Listo para comenzar?  
Abre el proyecto en **Visual Studio** y presiona **F5** para descubrir **FitBuddy** 🎉

