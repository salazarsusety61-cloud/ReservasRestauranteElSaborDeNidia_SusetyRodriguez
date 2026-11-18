#  Sistema de Reservas — El Sabor de Nidia

Aplicación de escritorio en **C# / Windows Forms** para la gestión de reservas de mesas del restaurante *El Sabor de Nidia*. Permite iniciar sesión, registrar clientes, visualizar el plano del restaurante, crear reservas con validaciones de horario y capacidad, y mostrar la factura del consumo con servicio e IVA.

> Proyecto académico desarrollado con una arquitectura por capas: **Presentación → Lógica → Datos → Entidades**.

---

##  Características

- **Inicio de sesión** (`FrmLogin`) con validación de usuario y contraseña.
- **Registro de usuarios** (`FrmRegistro`) con validación de campos, confirmación de contraseñas y usuario/correo únicos.
- **Plano del restaurante** (`FrmPlano`) con 10 mesas dibujadas por posición, color según estado:
  - 🟢 Disponible
  - 🟡 Reservada
  - 🔴 Fuera de servicio
  - Filtros por fecha y rango de horas; consulta de reservas por mesa.
- **Reservas** (`FrmReserva` + `ReservaLogica`) con reglas de validación de negocio.
- **Factura** (`FrmFactura`) con detalle de platos, cálculo de **servicio 10%**, **IVA 13%** y total en colones (₡).
- Cambio de estado de una mesa entre *Disponible* y *Fuera de Servicio*.

##  Tecnologías

- Lenguaje: **C#**
- Interfaz: **Windows Forms (WinForms)**
- Entorno: **Visual Studio 2022** (solución `RestauranteReservas.slnx`)
- Datos: almacenamiento en listas en memoria (capa `Datos`); pendiente conectar base de datos.

##  Estructura del proyecto

| Capa / Archivo | Función |
|---|---|
| `RestauranteReservas.slnx` | Solución de Visual Studio |
| `Entidades/Mesa.cs` | Modelo de mesa: Id, Nombre, Capacidad, Forma, Estado, Posición X/Y |
| `Entidades/Reserva.cs` | Modelo de reserva: MesaId, Fecha, HoraInicio, HoraFin, CantidadPersonas, Observaciones, Estado |
| `Entidades/Usuario.cs` | Modelo de usuario: Nombre, NombreUsuario, Contraseña, Teléfono, Correo, Rol |
| `Datos/MesaDatos.cs` | Listado de las 10 mesas precargadas y consulta por Id |
| `Datos/ReservaDatos.cs` | Almacenamiento y consulta de reservas por mesa y fecha |
| `Datos/UsuarioDatos.cs` | Validación de acceso, registro y verificación de usuario/correo |
| `Logica/ReservaLogica.cs` | Reglas de validación y guardado de reservas |
| `Presentacion/FrmLogin.cs` | Pantalla de inicio de sesión |
| `Presentacion/FrmRegistro.cs` | Pantalla de registro de clientes |
| `Presentacion/FrmPlano.cs` | Plano visual del restaurante y selección de mesas |
| `Presentacion/FrmReserva.cs` | Formulario de creación de reservas |
| `Presentacion/FrmFactura.cs` | Factura con subtotal, servicio, IVA y total |

##  Reglas de validación de una reserva

La clase `ReservaLogica.ValidarReserva` valida que:

1. Se completen todos los datos obligatorios (fecha, hora de inicio, hora de fin y cantidad de personas mayor que 0).
2. La fecha no sea anterior a hoy; si es hoy, la hora de inicio ya no debe haber pasado.
3. La hora de fin sea posterior a la hora de inicio.
4. La reserva esté dentro del horario de atención: **7:00 a. m. – 10:00 p. m.**
5. La duración no supere las **4 horas**.
6. La cantidad de personas no supere la capacidad de la mesa seleccionada.
7. No exista otra reserva que se solape en horario con la misma mesa.

##  Usuarios de prueba

Precargados en `UsuarioDatos.cs`:

| Usuario | Contraseña | Rol |
|---|---|---|
| `admin` | `admin123` | Administrador |
| `cliente1` | `cliente123` | Cliente |
| `cliente2` | `cliente223` | Cliente |

##  Cómo ejecutar el proyecto

1. Abrir `RestauranteReservas.slnx` en **Visual Studio 2022**.
2. Compilar con **Ctrl + Shift + B**.
3. Ejecutar con **F5** (o el botón Inicio ▶).
4. Iniciar sesión con uno de los usuarios de prueba.

##  Flujo de uso

1. Iniciar sesión o registrarse desde `FrmLogin` / `FrmRegistro`.
2. En el plano (`FrmPlano`), elegir la fecha y el rango de horas deseados.
3. Seleccionar una mesa disponible; si está libre, confirmar *¿Desea crear una reserva?*
4. Completar el formulario de reserva y guardar; las validaciones se ejecutan antes de guardar.
5. Ver la información de la mesa y las reservas del día; generar la factura de consumo.

##  Estado actual y pendientes

- Los datos se guardan en listas en memoria y se pierden al cerrar la aplicación; falta persistencia en base de datos.
- Las contraseñas se guardan en texto plano; falta cifrado.
- El botón de descarga de PDF en la factura aún es un aviso; falta generar el PDF real.
- Pendiente: gestión de menú/platos y reportes de reservas.

## 👤 Autor

Proyecto desarrollado por **Susety Rodriguez** — *Sistema de Reserva, El Sabor de Nidia*.
