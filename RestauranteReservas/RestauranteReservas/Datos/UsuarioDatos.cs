using System;
using System.Collections.Generic;
using MySqlConnector;

namespace RestauranteReservas.Datos
{
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

        public class ResultadoDatos
        {
            public bool Exito;
            public int IdGenerado;
            public string Mensaje = "";
        }

        public static ResultadoLogin ValidarLogin(string nombreUsuario, string clave)
        {
            var resultado = new ResultadoLogin();
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(clave))
            {
                resultado.Mensaje = "Debe escribir el usuario y la contraseña.";
                return resultado;
            }
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT id, nombre, nombre_usuario, rol
                                         FROM usuario
                                         WHERE nombre_usuario = @usuario
                                           AND `contraseña` = @clave
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
                resultado.Mensaje = "Error MySQL: " + ex.Number + " - " + ex.Message;
            }
            catch (Exception ex)
            {
                resultado.Mensaje = "Error: " + ex.Message;
            }
            return resultado;
        }

        public static List<FilaUsuario> Listar(string? rol = null)
        {
            var lista = new List<FilaUsuario>();
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT id, nombre, nombre_usuario, telefono, correo, rol
                                         FROM usuario
                                         WHERE (@rol IS NULL OR rol = @rol)
                                         ORDER BY id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@rol", (object?)rol ?? DBNull.Value);
                        using (var leer = cmd.ExecuteReader())
                        {
                            while (leer.Read())
                                lista.Add(LeerFila(leer));
                        }
                    }
                }
            }
            catch { lista = new List<FilaUsuario>(); }
            return lista;
        }

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

        public static bool ExisteNombreUsuario(string nombreUsuario, int idExcluir = 0)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario)) return false;
            try
            {
                using (var cn = Conexion.ObtenerConexion())
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
            catch { return false; }
        }

        public static bool ExisteCorreo(string correo, int idExcluir = 0)
        {
            if (string.IsNullOrWhiteSpace(correo)) return false;
            try
            {
                using (var cn = Conexion.ObtenerConexion())
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
            catch { return false; }
        }

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
                using (var cn = Conexion.ObtenerConexion())
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
                        cmd.Parameters.AddWithValue("@telefono", (object?)telefono ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@correo", correo.Trim());
                        var resultado = cmd.ExecuteScalar();
                        if (resultado != null) r.IdGenerado = Convert.ToInt32(resultado);
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
                r.Mensaje = "Error al registrar: " + ex.Message;
            }
            return r;
        }
    }
}
