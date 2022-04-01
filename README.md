# Proyecto Innube

Este es el proyecto Innube para el último trimestre del SENA para la carrera ADSI. Este proyecto fue creado usando las siguientes herramientas: C#, MySQL, JavaScript, HTML y CSS. En pocas palabras es un sistema de información. Para la parte de *backend* se usó C#, es decir, el *framework* propio llamado ASP NET Core 6 (que proviene de .NET 6); para la base de datos se usó MySQL; para conectar el *backend* con la base se usó un conector llamado [Pomelo](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql); para el *frontend* simplemente se usaron HTML, CSS y JavaScript.

Para recrear el proyecto simplemente es necesario tener las herramientas instaladas, descargar el código fuente, crear la base de datos con el archivo `exportar_bd.sql`, crear un archivo `.env` donde van a estar el usuario y la contraseña para conectarse a la base de datos:

```
usuario_bd=usuario_creado
contraseña_bd=contraseña_creada
```

y correr dos comandos desde la carpeta del proyecto:

```
dotnet build
dotnet run
```

Básicamente `dotnet build` se encarga de descargar los paquetes necesarios descritos en `Proyecto-sena.csproj` y `dotnet run` es para correr el proyecto. Después navegar a `https://localhost:5001/` para ver el sistema de información.