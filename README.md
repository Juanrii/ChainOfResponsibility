# ChainOfResponsibility

### Descripción
Este proyecto está enfocado en la implementación del Patrón de Diseño Chain of Responsibility y utiliza una arquitectura basada en capas para mejorar la separación de responsabilidades y facilitar el mantenimiento. El proyecto también incluye funcionalidades como persistencia de datos en MySQL Server, envío de correos electrónicos y encriptación.

### Funcionalidades
- **Patrón Chain of Responsibility:** Implementación del patrón de diseño que permite manejar solicitudes a través de una cadena de objetos.
- **Persistencia en MySQL Server:** El proyecto utiliza MySQL Server para almacenar y recuperar datos, incluyendo información de usuarios.
- **Envío de Emails:** Se realiza el envío de correos electrónicos a los usuarios registrados en la tabla `User`.
- **Configuración de Cliente SMTP:** Configuración del cliente SMTP en `App.config` para el envío de emails.
- **Singleton Pattern:** Utiliza el patrón Singleton para asegurar que el servicio de autenticación se instancie una única vez durante el proceso de login.
- **Validador de Email:** Funcionalidad para validar direcciones de correo electrónico antes de enviarlas.
- **Encriptación con MD5:** Encripta datos sensibles utilizando el algoritmo MD5.


### Configuración

1. **Configuración del Cliente SMTP:**
    - En `App.config` agregar:
      - `SmtpServer`: "smtp.gmail.com"
      - `SmtpPort`: "587"
      - `SmtpEmail`: "tu_correo@gmail.com"
      - `SmtpPassword`: "tu_contraseña_de_aplicacion"
2. **Conexión a MySQL Server:**
    - Configurar la cadena de conexión `connectionStrings` para la base de datos.


## Demo

## ![Screenshot 2024-09-13 at 1 52 59 AM](https://github.com/user-attachments/assets/e307b3e6-f211-415b-80ed-a94aef3a5727)
## ![Screenshot 2024-09-13 at 1 53 14 AM](https://github.com/user-attachments/assets/659bf828-25c3-4214-890f-6e2468aefd16)
## ![Screenshot 2024-09-13 at 1 54 34 AM](https://github.com/user-attachments/assets/106993fb-abb7-45f2-b0ef-cfbe295e8db0)
## ![Screenshot 2024-09-13 at 1 56 25 AM](https://github.com/user-attachments/assets/0e3e5314-d73f-4972-a2f1-132803c92ac5)
## ![Screenshot 2024-09-13 at 1 55 00 AM](https://github.com/user-attachments/assets/c758afd1-7063-4fc4-8f5e-3000ebdc4cea)



