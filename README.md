# BiblioTeisBackEnd
BackEnd simple de biblio teis, un proyecto educativo diseñado para reforzar el conocimiento de Android.

# Como ejecutar
El proyecto está escrito usando dotnet core 7.
- Descarga .net core 7 usando el siguiente link: [download](https://dotnet.microsoft.com/es-es/download/dotnet/7.0)
- Ejecuta el archivo obtenido
- Abre la carpeta contenedora del backend
- Ejecuta el comando dotnet run

  Como resultado de seguir esos pasos deberías ver en el terminal abierto una serie de mensaje de info y la url donde se ha desplegado el API.
  http://localhost:5097


# Documentación relevante del api
Si el despliegue de la app se ha realizado con exito será posible consultar la documentación del API usando la dirección
[http://localhost:5097/swagger](http://localhost:5097/swagger)

Esta API es muy simple y podría contener bugs. Si fuera necesario crear algún nuevo endpoint o existiese algún comportamiento inesperado se podrán reportar errores o solicitar modificaciones usando la pestaña de issues y detallando el problema.

# Detalles sobre la API
Existen 3 controladores principales y uno de apoyo en el API. 
- /Books: Servirá para gestionar los libros de la biblioteca así como consultarlos
- /Users: Servirá para gestionar los usuarios de la biblioteca así como consultarlos
- /BookLendings: Servirá para gestionar el prestamo y devolución de libros por los usuarios de la biblioteca
- /Image: Permitirá el acceso a la imagenes almacenadas en la carpeta wwwroot del sistema.
