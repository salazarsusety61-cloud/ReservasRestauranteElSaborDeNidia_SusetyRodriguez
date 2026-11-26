using System;
using System.Collections.Generic;
using MySqlConnector;

namespace RestauranteReservas.Datos
{
    // =====================================================================
    // Tabla: usuario (administradores y clientes).
    // Metodos: login (CP-01/CP-02), registro de cliente (CP-03/CP-04),
    // listado. Todas las consultas usan parametros; la clave nunca se
    // concatena dentro del SQL (RNF-05).
    //
    // Si el proyecto ya tiene Entidades/Usuario.cs, reemplazar la clase
    // FilaUsuario por esa entidad en el metodo LeerFila (ver comentario).
    // =====================================================================
    public static class UsuarioDatos
    {
        public class FilaUsuario
        {
            public int Id;
            public string Nombre = "";
            public string NombreUsuario = "";
            public string Telefono = "";
            public string Correo = "";
            public string Rol = "";
        }

        public class ResultadoLogin
        {
            public bool Exito;
            public int Id;
            public string Nombre = "";
            public string NombreUsuario = "";
            public string Rol = "";
            public string Mensaje = "";
        }

        // CP-01 / CP-02: valida contra la tabla `usuario`.
        public static ResultadoLogin ValidarLogin(string nombreUsuario, string clave)
        {
            var resultado = new ResultadoLogin();

            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(clave))
            {
                resultado.Mensaje = "Debe escribir el nombre de usuario y la contraseña.";
                return resultado;
            }

            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();

                    const string sql = @"SELECT id, nombre, nombre_usuario, rol
                                         FROM usuario
                                         WHERE nombre_usuario = @usuario
                                           AND `contraseña`  = @clave
                                         LIMIT 1;";

                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", nombreUsuario.Trim());
                        cmd.Parameters.AddWithValue("@clave", clave.Trim());

                        using (var leer = cmd.ExecuteReader())
                        {
                            if (leer.Read())
                            {
                                resultado.Exito = true;
                                resultado.Id = leer.GetInt32(leer.GetOrdinal("id"));
                                resultado.Nombre = leer.GetString(leer.GetOrdinal("nombre"));
                                resultado.NombreUsuario = leer.GetString(leer.GetOrdinal("nombre_usuario"));
                                resultado.Rol = leer.GetString(leer.GetOrdinal("rol"));
                                resultado.Mensaje = "OK";
                            }
                            else
                            {
                                resultado.Mensaje = "Usuario o contraseña incorrectos.";
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                resultado.Mensaje = "No se pudo consultar la base de datos (MySQL "
                                    + ex.Number + ": " + ex.Message + ").";
            }
            catch (Exception ex)
            {
                resultado.Mensaje = "Error inesperado al iniciar sesión: " + ex.Message;
            }

            return resultado;
        }

        // CP-03: nombre de usuario repetido (UNIQUE uk_usuario).
        public static bool ExisteNombreUsuario(string nombreUsuario, int idExcluir = 0)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario)) return false;

            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT COUNT(1) FROM usuario
                                         WHERE nombre_usuario = @usuario
                                           AND (@idExcluir = 0 OR id <> @idExcluir);";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", nombreUsuario.Trim());
                        cmd.Parameters.AddWithValue("@idExcluir", idExcluir);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (MySqlException)
            {
                return false; // La ventana muestra UltimoError/ResultadoDatos.Mensaje segun el caso.
            }
        }

        // CP-03: correo repetido (UNIQUE uk_correo).
        public static bool ExisteCorreo(string correo, int idExcluir = 0)
        {
            if (string.IsNullOrWhiteSpace(correo)) return false;

            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT COUNT(1) FROM usuario
                                         WHERE correo = @correo
                                           AND (@idExcluir = 0 OR id <> @idExcluir);";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@correo", correo.Trim());
                        cmd.Parameters.AddWithValue("@idExcluir", idExcluir);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        // CP-04: registra un cliente nuevo; la fila persiste aunque se cierre
        // el programa porque queda en la tabla `usuario` de MySQL.
        public static ResultadoDatos RegistrarCliente(string nombre, string nombreUsuario,
                                                      string clave, string telefono, string correo)
        {
            var r = new ResultadoDatos();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(nombreUsuario)
                || string.IsNullOrWhiteSpace(clave) || string.IsNullOrWhiteSpace(correo))
            {
                r.Mensaje = "Nombre, usuario, contraseña y correo son obligatorios.";
                return r;
            }
            if (ExisteNombreUsuario(nombreUsuario))
            {
                r.Mensaje = "El nombre de usuario ya existe. Elija otro.";
                return r;
            }
            if (ExisteCorreo(correo))
            {
                r.Mensaje = "El correo ya está registrado.";
                return r;
            }

            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"INSERT INTO usuario
                                             (nombre, nombre_usuario, `contraseña`, telefono, correo, rol)
                                         VALUES (@nombre, @usuario, @clave, @telefono, @correo, 'Cliente');
                                         SELECT LAST_INSERT_ID();";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre.Trim());
                        cmd.Parameters.AddWithValue("@usuario", nombreUsuario.Trim());
                        cmd.Parameters.AddWithValue("@clave", clave.Trim());
                        cmd.Parameters.AddWithValue("@telefono", (object)telefono ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@correo", correo.Trim());

                        r.IdGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                        r.Exito = true;
                        r.Mensaje = "OK";
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                    r.Mensaje = "El usuario o el correo ya están registrados.";
                else
                    r.Mensaje = "MySQL " + ex.Number + ": " + ex.Message;
            }
            catch (Exception ex)
            {
                r.Mensaje = "Error al registrar el cliente: " + ex.Message;
            }

            return r;
        }

        // Listado general; con rol filtra ('Administrador' o 'Cliente').
        public static List<FilaUsuario> Listar(string rol = null)
        {
            var lista = new List<FilaUsuario>();

            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT id, nombre, nombre_usuario, telefono, correo, rol
                                         FROM usuario
                                         WHERE (@rol IS NULL OR rol = @rol)
                                         ORDER BY id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@rol", (object)rol ?? DBNull.Value);
                        using (var leer = cmd.ExecuteReader())
                        {
                            while (leer.Read())
                                lista.Add(LeerFila(leer));
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                lista = new List<FilaUsuario>(); // La ventana complementa con ConexionBD.UltimoError.
            }

            return lista;
        }

        // Mapeo de la fila del reader a una clase. Si el proyecto ya tiene
        // Entidades/Usuario.cs, cambie el tipo de retorno por esa entidad
        // y asigne aqui sus propiedades (p. ej. u.Id, u.Nombre, u.Rol).
        private static FilaUsuario LeerFila(MySqlDataReader leer)
        {
            var f = new FilaUsuario
            {
                Id = leer.GetInt32(leer.GetOrdinal("id")),
                Nombre = leer.GetString(leer.GetOrdinal("nombre")),
                NombreUsuario = leer.GetString(leer.GetOrdinal("nombre_usuario")),
                Correo = leer.GetString(leer.GetOrdinal("correo")),
                Rol = leer.GetString(leer.GetOrdinal("rol"))
            };

            int ordTel = leer.GetOrdinal("telefono");
            f.Telefono = leer.IsDBNull(ordTel) ? "" : leer.GetString(ordTel);

            return f;
        }
    }
}