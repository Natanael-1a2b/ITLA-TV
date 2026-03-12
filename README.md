# ITLA TV 📺

Bienvenido al repositorio de **ITLA TV**. Esta es una aplicación web desarrollada con fines educativos, basada en la arquitectura **N-Capas** utilizando **ASP.NET Core MVC** y **Entity Framework Core**. El propósito del sistema es administrar un catálogo de series y peliculas, gestionando sus géneros y las productoras asociadas de manera organizada y eficiente.

---

## 🏗️ Arquitectura del Proyecto

El proyecto está diseñado de forma modular utilizando una arquitectura de 3 capas principales para mantener una separación clara de responsabilidades:

1. **ITLA TV (Capa de Presentación)**  
   Proyecto web basado en ASP.NET Core MVC. Contiene los _Controllers_, _Views_ (UI) y _Models_ para interactuar directamente con el usuario final.

2. **Logica de Negocio (BLL)**  
   Contiene todos los servicios (`SerieService`, `ProductoraService`, `GeneroService`), respositorios, y ViewModels. Aquí residen las reglas y operaciones de negocio que conectan la presentación con los datos.

3. **Database (DAL)**  
   Capa de acceso a datos. Utiliza Entity Framework Core con un enfoque *Code-First* para interactuar con SQL Server. Aquí se definen los contextos (`AppContexts`), migraciones y las entidades principales del dominio.

---

## 🗂️ Modelo de Datos (Entidades)

El dominio central de la base de datos se basa en las siguientes entidades:

- **Serie**: Representa una serie de televisión.  
  _Propiedades principales_: Nombre, Descripción, Imagen (URL de portada), EnlaceYouTube (Trailer o capítulo), Productora, Género Primario y Género Secundario (Opcional).
  
- **Productora**: Entidad dueña de la creación de las series.  
  _Propiedades principales_: Nombre y Descripción. (Ej. Netflix, HBO, AMC).

- **Genero**: Clasificación de las series.  
  _Propiedades principales_: Nombre y Descripción. (Ej. Acción, Comedia, Drama).

---

## 🛠️ Tecnologías Utilizadas

- **C#**
- **ASP.NET Core 8.0/9.0** (MVC)
- **Entity Framework Core**
- **SQL Server**
- HTML, CSS, Bootstrap (Interfaz de usuario)

---

## 🚀 Requisitos Previos

Asegúrate de tener instalado en tu máquina lo siguiente antes de ejecutar el proyecto:

1. **[.NET SDK](https://dotnet.microsoft.com/download)** (Compatible con la versión usada en el proyecto).
2. **[Visual Studio 2022](https://visualstudio.microsoft.com/)** o Visual Studio Code.
3. **[SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)** (Express o Developer).

---

## ⚙️ Instalación y Configuración

Sigue estos sencillos pasos para poner en marcha el proyecto:

1. **Clonar el repositorio**:
   ```bash
   git clone https://github.com/Natanael-1a2b/ITLA-TV.git
   cd ITLA-TV
   ```

2. **Configurar la cadena de conexión**:
   Abre el archivo `appsettings.json` o `appsettings.Development.json` en el proyecto **ITLA TV** y asegúrate de que el `ConnectionStrings > DefaultConexion` apunte a tu instancia local de SQL Server. Por defecto se espera `Server=TuServidor\\SQLEXPRESS;Database=ItlaTV;...`

3. **Aplicar Migraciones a la Base de Datos**:
   Asegúrate de que la base de datos sea generada. Abre la Consola del Administrador de Paquetes (Package Manager Console) en Visual Studio, selecciona `Database` como proyecto predeterminado y ejecuta:
   ```powershell
   Update-Database
   ```
   *(Como alternativa con .NET CLI en la consola)*:
   ```bash
   dotnet ef database update --project Database --startup-project "ITLA TV"
   ```

4. **Ejecutar el Proyecto**:
   Establece **ITLA TV** como el proyecto de inicio (_Startup Project_) y presiona `F5` o el botón de ejecución en Visual Studio.  
   *(O usando .NET CLI desde la carpeta del proyecto MVC)*:
   ```bash
   dotnet run --project "ITLA TV"
   ```

---

## 👨‍💻 Autor

Desarrollado por **[Natanael-1a2b](https://github.com/Natanael-1a2b/)**.
