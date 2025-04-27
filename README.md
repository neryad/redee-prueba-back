# RedeE Prueba Back

Este proyecto es una API desarrollada en .NET 9 con C# 13.0 que utiliza Entity Framework Core para la gestión de datos y proporciona servicios relacionados con consultas a la DGII (Dirección General de Impuestos Internos).

## Características

- **Framework**: .NET 9
- **Base de Datos**: SQL Server, configurada mediante Entity Framework Core.
- **Arquitectura**: API RESTful.
- **Servicios**:
  - Consultas a la DGII mediante `ServicioConsultasWebDgii`.
- **Controladores**:
  - `CompanyControllers` para la gestión de entidades relacionadas con empresas.
- **CORS**: Configuración para permitir cualquier origen, método y encabezado, facilitando pruebas y desarrollo.

## Configuración del Proyecto

### Requisitos Previos

- .NET SDK 9.0 o superior.
- SQL Server.
- Visual Studio 2022 o cualquier editor compatible con .NET.

### Instalación

1. Clona este repositorio:
   ` git clone <url-del-repositorio> cd redee-prueba-back`
2. Configura la cadena de conexión en el archivo `appsettings.json` o `appsettings.Development.json`:
   `{ "ConnectionStrings": { "DefaultConnection": "Server=<tu-servidor>;Database=<tu-base-de-datos>;User Id=<tu-usuario>;Password=<tu-contraseña>;" } }`
3. Aplica las migraciones para configurar la base de datos:
   `dotnet ef database update `
4. Ejecuta el proyecto:
   `dotnet run`

### Endpoints

- **Base URL**: `http://localhost:<puerto>`
- **Controladores**:
  - `/api/Company`: Endpoints para la gestión de empresas.

## Estructura del Proyecto

- **Data**: Contiene el contexto de la base de datos (`ApplicationDbContext`).
- **Entities**: Define las entidades del dominio, como `Company`.
- **Controllers**: Implementa los controladores de la API.
- **Migrations**: Contiene las migraciones generadas por Entity Framework Core.

## Paquetes Utilizados

Este proyecto utiliza los siguientes paquetes NuGet:

- **Microsoft.EntityFrameworkCore.SqlServer** (v9.0.4): Proveedor de Entity Framework Core para SQL Server.
- **Microsoft.EntityFrameworkCore.Tools** (v9.0.4): Herramientas para trabajar con migraciones y scaffolding en Entity Framework Core.
- **Octetus.ConsultasDgii** (v1.0.0): Biblioteca personalizada para realizar consultas a la DGII.

Para instalar estos paquetes, puedes usar los siguientes comandos en la consola de NuGet:

`dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.4 dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.4 dotnet add package Octetus.ConsultasDgii --version 1.0.0`

## Contribución

1. Haz un fork del repositorio.
2. Crea una rama para tu funcionalidad o corrección:
   `git checkout -b feature/nueva-funcionalidad`
3. Realiza tus cambios y haz un commit:
   `git commit -m "Descripción de los cambios"`
4. Envía tus cambios:
   `git push origin feature/nueva-funcionalidad`

5. Abre un Pull Request.

## Licencia

Este proyecto está bajo la licencia [MIT](LICENSE).

---

Si tienes preguntas o necesitas ayuda, no dudes en abrir un issue.
