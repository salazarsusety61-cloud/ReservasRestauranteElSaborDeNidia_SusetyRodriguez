# Borrador del Manual Técnico — Sistema de Reservas
## Restaurante "El Sabor de Nidia"

---

##  4.1 Diccionario de Datos

### Tabla: usuario
| Campo | Tipo | Obligatorio | Descripción | Llave |
|-------|------|-------------|-------------|-------|
| id | INT | Sí | Identificador único del usuario | PK |
| nombre | VARCHAR(100) | Sí | Nombre completo del usuario | — |
| nombre_usuario | VARCHAR(50) | Sí | Nombre de inicio de sesión | Única |
| contraseña | VARCHAR(255) | Sí | Clave de acceso cifrada | — |
| telefono | VARCHAR(20) | No | Número de teléfono del usuario | — |
| correo | VARCHAR(100) | Sí | Correo electrónico del usuario | Única |
| rol | VARCHAR(20) | Sí | Rol: Administrador o Cliente | — |

### Tabla: configuracion
| Campo | Tipo | Obligatorio | Descripción | Llave |
|-------|------|-------------|-------------|-------|
| id | INT | Sí | Identificador único | PK |
| clave | VARCHAR(50) | Sí | Nombre del parámetro de configuración | Única |
| valor | VARCHAR(255) | Sí | Valor del parámetro | — |
| descripcion | TEXT | No | Explicación del parámetro | — |

### Tabla: mesa
| Campo | Tipo | Obligatorio | Descripción | Llave |
|-------|------|-------------|-------------|-------|
| id | INT | Sí | Identificador único de la mesa | PK |
| numero | INT | Sí | Número de mesa visible en el plano | Única |
| capacidad | INT | Sí | Cantidad máxima de personas | — |
| forma | VARCHAR(20) | Sí | Forma de la mesa: cuadrada, redonda, rectangular | — |
| posicion_x | INT | Sí | Coordenada horizontal en el plano | — |
| posicion_y | INT | Sí | Coordenada vertical en el plano | — |
| fuera_servicio | BOOLEAN | Sí | Indica si la mesa no está disponible | — |

### Tabla: categoria_plato
| Campo | Tipo | Obligatorio | Descripción | Llave |
|-------|------|-------------|-------------|-------|
| id | INT | Sí | Identificador único de la categoría | PK |
| nombre | VARCHAR(50) | Sí | Nombre de la categoría | — |
| descripcion | TEXT | No | Descripción de la categoría de platos | — |

### Tabla: plato
| Campo | Tipo | Obligatorio | Descripción | Llave |
|-------|------|-------------|-------------|-------|
| id | INT | Sí | Identificador único del plato | PK |
| nombre | VARCHAR(100) | Sí | Nombre del plato en el menú | Única |
| descripcion | TEXT | No | Ingredientes o detalles del plato | — |
| precio | DECIMAL(10,2) | Sí | Precio del plato en colones | — |
| disponible | BOOLEAN | Sí | Indica si el plato se puede ordenar | — |
| categoria_id | INT | Sí | Categoría a la que pertenece el plato | FK → categoria_plato |

### Tabla: reserva
| Campo | Tipo | Obligatorio | Descripción | Llave |
|-------|------|-------------|-------------|-------|
| id | INT | Sí | Identificador único de la reserva | PK |
| usuario_id | INT | Sí | Cliente que realizó la reserva | FK → usuario |
| mesa_id | INT | Sí | Mesa asignada a la reserva | FK → mesa |
| fecha | DATE | Sí | Fecha de la reserva | — |
| hora_inicio | TIME | Sí | Hora de inicio de la reserva | — |
| hora_fin | TIME | Sí | Hora de finalización estimada | — |
| cantidad_personas | INT | Sí | Número de personas que asistirán | — |
| observaciones | TEXT | No | Notas o solicitudes especiales del cliente | — |
| estado | VARCHAR(20) | Sí | Estado: Confirmada, Completada, Cancelada | — |

### Tabla: detalle_orden
| Campo | Tipo | Obligatorio | Descripción | Llave |
|-------|------|-------------|-------------|-------|
| id | INT | Sí | Identificador único del detalle | PK |
| reserva_id | INT | Sí | Reserva a la que pertenece la orden | FK → reserva |
| plato_id | INT | Sí | Plato ordenado | FK → plato |
| cantidad | INT | Sí | Cantidad de porciones solicitadas | — |
| precio_unitario | DECIMAL(10,2) | Sí | Precio del plato al momento de ordenar | — |

### Tabla: factura
| Campo | Tipo | Obligatorio | Descripción | Llave |
|-------|------|-------------|-------------|-------|
| id | INT | Sí | Número de factura | PK |
| reserva_id | INT | Sí | Reserva asociada a esta factura | FK → reserva |
| fecha_emision | DATETIME | Sí | Fecha y hora de emisión de la factura | — |
| subtotal | DECIMAL(10,2) | Sí | Suma de los montos sin impuestos | — |
| monto_servicio | DECIMAL(10,2) | Sí | 10% por servicio | — |
| monto_iva | DECIMAL(10,2) | Sí | 13% de impuesto al valor agregado | — |
| total | DECIMAL(10,2) | Sí | Total a pagar por el cliente | — |

---

##  4.2 Tabla de Casos de Prueba

| ID | Descripción | Datos | Resultado esperado | Resultado obtenido |
|----|-------------|-------|-------------------|-------------------|
| CP-01 | Inicio de sesión correcto | Usuario: admin, Contraseña: Uisil2026 | El sistema ingresa y muestra la ventana de administrador | Pendiente de prueba |
| CP-02 | Inicio de sesión con contraseña incorrecta | Usuario: admin, Contraseña: equivocada | El sistema muestra mensaje: "Usuario o contraseña incorrectos" | Pendiente de prueba |
| CP-03 | Registro con usuario ya existente | Nombre de usuario: admin | El sistema no permite guardar y avisa que ya existe | Pendiente de prueba |
| CP-04 | Cliente inicia sesión tras reiniciar | Registrar cliente → cerrar sistema → abrir → iniciar sesión | Las credenciales funcionan después de reiniciar | Pendiente de prueba |
| CP-05 | Modificar mesa desde la base de datos | UPDATE mesa SET fuera_servicio = TRUE WHERE id = 5; | Al recargar el plano, la mesa aparece como fuera de servicio | Pendiente de prueba |
| CP-06 | Reserva persiste al reiniciar | Crear reserva → cerrar sistema → abrir de nuevo | La reserva creada sigue visible en el sistema | Pendiente de prueba |
| CP-07 | Reserva que choca con otra del mismo horario | Mesa 2, hoy, 18:00 a 20:00; ya ocupada de 17:00 a 19:00 | El sistema no permite guardar y muestra mensaje de conflicto | Pendiente de prueba |
| CP-08 | Reserva que termina justo cuando empieza otra | Mesa 3, 17:00 a 19:00 y otra 19:00 a 21:00 |  El sistema permite guardar ambas sin conflicto | Pendiente de prueba |
| CP-09 | Más personas que la capacidad de la mesa | Mesa capacidad=2, personas=4 | El sistema muestra mensaje de capacidad insuficiente | Pendiente de prueba |
| CP-10 | Modificar reserva sin cambiar horario | Cambiar solo observaciones de una reserva existente | Se guarda correctamente sin detectar conflicto con sí misma | Pendiente de prueba |
| CP-11 | Cancelar una reserva existente | Eliminar una reserva activa | La reserva desaparece y la mesa queda disponible en ese horario | Pendiente de prueba |
| CP-12 | Eliminar reserva con orden asociada | Eliminar reserva que tiene platos pedidos en su orden | Se elimina la reserva, su orden y su factura sin errores | Pendiente de prueba |
| CP-13 | No permitir nombre de plato repetido | Intentar agregar un plato con un nombre que ya existe | El sistema muestra mensaje de nombre duplicado | Pendiente de prueba |
| CP-14 | No eliminar plato que ya está en uso | Intentar borrar un plato que aparece en una orden | No se elimina, solo se marca como no disponible | Pendiente de prueba |
| CP-15 | Mensaje cuando MySQL no está disponible | Detener el servicio MySQL80 e intentar iniciar sesión | El sistema muestra mensaje claro y NO se cierra | Pendiente de prueba |
