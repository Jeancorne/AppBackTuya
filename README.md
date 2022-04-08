# Introducción
Api en .NET Core 5.0 con principios SOLID, integra Entity framework que conecta con SQL Server, y esta bajo la arquitectura limpia que esta basada en la norma ISO 25010.

Consiste en unos servicios que permite registrar y logear un usuario de red con autenticación JWT, luego permite simular un cajero/a que realiza unas ventas. Ejemplo:
"Comprar 2 productos de 1500$ y cada uno de 2 cantidades" Esto genera un ticket de un precio total y la descripción de cada producto. 
Adicional permite consultar que cajero/a hizo que ventas y con sus detalles. 


# Como empezar

1.	Ejecutar el script para crear la BD, DBScript.SQL, contiene todas las instrucciones, NOTA: el motor es SQL.
2.  El api rest usa swagger, sin embargo lo recomendado es usar postman, en el proyecto hay un archivo "PruebaTuya.postman_collection", este se puede importar en postman que contiene todos los endpoint.
2.	Crear primero un usuario de red, ya que solo hay 2 rutas que no tienen autorización, que es login y crear usuario. Las otras implementan JWT.
    Nota: esto valida si el usuario ya fue creado, que no permita repetidos y que el cajero este asociado a un usuario de red.

3.	Después de crear el usuario, sigue iniciar sesión, esta recibe usuario y contraseña y retorna un token, es obligatorio envíar este token a las otras rutas para que respondan, el tipo es "Bearer token", en postman está en "Authorization > Lista desplegable Type > Bearer Token", aquí se copia y se pega ese token retornado.

# Tecnologías/Librerias/Arquitectura/BD
.Net Core 5.0
Entity Framework
SQL Server
SOLID
Arquitectura Limpia



#BuenasPracticas #Arquitectura #NetCore #Backend
If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)
