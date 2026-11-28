using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace RestauranteReservas.Datos
{
    public static class PlatoDatos
    {
        public class FilaPlato
        {
            public int Id;
            public string Nombre = "";
            public string Descripcion = "";
            public decimal Precio;
            public int? TiempoPreparacion;
            public bool Disponible;
            public int CategoriaId;
            public string CategoriaNombre = "";
        }

        public static List<FilaPlato> ListarTodos()
        {
            var lista = new List<FilaPlato>();
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    string sql = @"SELECT p.id, p.nombre, p.descripcion, p.precio,
                                          p.tiempo_preparacion, p.disponible,
                                          p.categoria_id, c.nombre AS categoria
                                   FROM plato p
                                   JOIN categoria_plato c ON c.id = p.categoria_id
                                   ORDER BY c.nombre, p.nombre;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    using (var leer = cmd.ExecuteReader())
                        while (leer.Read()) lista.Add(LeerFila(leer));
                }
            }
            catch (MySqlException)
            {
                lista = new List<FilaPlato>();
            }
            return lista;
        }

        public static List<FilaPlato> Listar(bool soloDisponibles = false)
        {
            var lista = new List<FilaPlato>();
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    string sql = @"SELECT p.id, p.nombre, p.descripcion, p.precio,
                                          p.tiempo_preparacion, p.disponible,
                                          p.categoria_id, c.nombre AS categoria
                                   FROM plato p
                                   JOIN categoria_plato c ON c.id = p.categoria_id
                                   WHERE (@solo = 0 OR p.disponible = 1)
                                   ORDER BY c.nombre, p.nombre;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@solo", soloDisponibles ? 1 : 0);
                        using (var leer = cmd.ExecuteReader())
                            while (leer.Read()) lista.Add(LeerFila(leer));
                    }
                }
            }
            catch (MySqlException)
            {
                lista = new List<FilaPlato>();
            }
            return lista;
        }

        public static List<FilaPlato> ListarPorCategoria(int categoriaId, bool soloDisponibles = true)
        {
            var lista = new List<FilaPlato>();
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT p.id, p.nombre, p.descripcion, p.precio,
                                                p.tiempo_preparacion, p.disponible,
                                                p.categoria_id, c.nombre AS categoria
                                         FROM plato p
                                         JOIN categoria_plato c ON c.id = p.categoria_id
                                         WHERE p.categoria_id = @cat
                                           AND (@solo = 0 OR p.disponible = 1)
                                         ORDER BY p.nombre;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@cat", categoriaId);
                        cmd.Parameters.AddWithValue("@solo", soloDisponibles ? 1 : 0);
                        using (var leer = cmd.ExecuteReader())
                            while (leer.Read()) lista.Add(LeerFila(leer));
                    }
                }
            }
            catch (MySqlException)
            {
                lista = new List<FilaPlato>();
            }
            return lista;
        }

        public static FilaPlato? ObtenerPorId(int id)
        {
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT p.id, p.nombre, p.descripcion, p.precio,
                                                p.tiempo_preparacion, p.disponible,
                                                p.categoria_id, c.nombre AS categoria
                                         FROM plato p
                                         JOIN categoria_plato c ON c.id = p.categoria_id
                                         WHERE p.id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var leer = cmd.ExecuteReader())
                            return leer.Read() ? LeerFila(leer) : null;
                    }
                }
            }
            catch (MySqlException)
            {
                return null;
            }
        }

        public static bool ExisteNombre(string nombre, int idExcluir = 0)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return false;
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT COUNT(1) FROM plato
                                         WHERE nombre = @nombre
                                           AND (@idExcluir = 0 OR id <> @idExcluir);";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre.Trim());
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

        public static bool EstaEnOrden(int platoId)
        {
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT COUNT(1) FROM detalle_orden WHERE plato_id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", platoId);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        private static FilaPlato LeerFila(MySqlDataReader leer)
        {
            return new FilaPlato
            {
                Id = leer.GetInt32("id"),
                Nombre = leer.GetString("nombre"),
                Descripcion = leer.IsDBNull("descripcion") ? "" : leer.GetString("descripcion"),
                Precio = leer.GetDecimal("precio"),
                TiempoPreparacion = leer.IsDBNull("tiempo_preparacion") ? null : leer.GetInt32("tiempo_preparacion"),
                Disponible = leer.GetBoolean("disponible"),
                CategoriaId = leer.GetInt32("categoria_id"),
                CategoriaNombre = leer.GetString("categoria")
            };
        }

        public static ResultadoDatos Agregar(string nombre, string? descripcion, decimal precio,
                                             int? tiempoPreparacion, int categoriaId)
        {
            var r = new ResultadoDatos();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                r.Mensaje = "El nombre del plato es obligatorio."; return r;
            }
            if (precio < 0)
            {
                r.Mensaje = "El precio no puede ser negativo."; return r;
            }
            if (categoriaId <= 0)
            {
                r.Mensaje = "Debe seleccionar la categoría del plato."; return r;
            }
            if (ExisteNombre(nombre))
            {
                r.Mensaje = "Ya existe un plato con ese nombre."; return r;
            }

            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"INSERT INTO plato
                        (nombre, descripcion, precio, tiempo_preparacion, disponible, categoria_id)
                        VALUES (@nombre, @desc, @precio, @tiempo, 1, @cat);
                        SELECT LAST_INSERT_ID();";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre.Trim());
                        cmd.Parameters.AddWithValue("@desc", (object?)descripcion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@tiempo", (object?)tiempoPreparacion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@cat", categoriaId);

                        var resultado = cmd.ExecuteScalar();
                        if (resultado != null)
                            r.IdGenerado = Convert.ToInt32(resultado);
                        r.Exito = true;
                        r.Mensaje = "OK";
                    }
                }
            }
            catch (MySqlException ex)
            {
                r.Mensaje = ex.Number == 1062
                    ? "Ya existe un plato con ese nombre."
                    : ex.Number == 1452
                        ? "La categoría seleccionada no existe en la base de datos."
                        : "MySQL " + ex.Number + ": " + ex.Message;
            }
            catch (Exception ex)
            {
                r.Mensaje = ex.Message;
            }
            return r;
        }

        public static ResultadoDatos Modificar(FilaPlato plato)
        {
            var r = new ResultadoDatos();
            if (plato == null || plato.Id <= 0)
            {
                r.Mensaje = "Falta el identificador del plato."; return r;
            }
            if (string.IsNullOrWhiteSpace(plato.Nombre))
            {
                r.Mensaje = "El nombre del plato es obligatorio."; return r;
            }
            if (plato.Precio < 0)
            {
                r.Mensaje = "El precio no puede ser negativo."; return r;
            }
            if (plato.CategoriaId <= 0)
            {
                r.Mensaje = "Debe seleccionar la categoría del plato."; return r;
            }
            if (ExisteNombre(plato.Nombre, plato.Id))
            {
                r.Mensaje = "Ya existe otro plato con ese nombre."; return r;
            }

            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"UPDATE plato SET nombre = @nombre, descripcion = @desc,
                                            precio = @precio, tiempo_preparacion = @tiempo,
                                            categoria_id = @cat
                                         WHERE id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", plato.Nombre.Trim());
                        cmd.Parameters.AddWithValue("@desc", (object?)plato.Descripcion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@precio", plato.Precio);
                        cmd.Parameters.AddWithValue("@tiempo", (object?)plato.TiempoPreparacion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@cat", plato.CategoriaId);
                        cmd.Parameters.AddWithValue("@id", plato.Id);

                        r.Exito = cmd.ExecuteNonQuery() > 0;
                        r.Mensaje = r.Exito ? "OK" : "Plato no encontrado.";
                    }
                }
            }
            catch (MySqlException ex)
            {
                r.Mensaje = ex.Number == 1062
                    ? "Ya existe otro plato con ese nombre."
                    : ex.Number == 1452
                        ? "La categoría seleccionada no existe en la base de datos."
                        : "MySQL " + ex.Number + ": " + ex.Message;
            }
            catch (Exception ex)
            {
                r.Mensaje = ex.Message;
            }
            return r;
        }

        public static ResultadoDatos DarDeBaja(int platoId)
        {
            var r = new ResultadoDatos();
            if (platoId <= 0)
            {
                r.Mensaje = "Falta el identificador del plato."; return r;
            }
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();

                    bool usado;
                    const string sqlCheck = @"SELECT COUNT(1) FROM detalle_orden WHERE plato_id = @id;";
                    using (var cmdCheck = new MySqlCommand(sqlCheck, cn))
                    {
                        cmdCheck.Parameters.AddWithValue("@id", platoId);
                        usado = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0;
                    }

                    const string sql = @"UPDATE plato SET disponible = 0 WHERE id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", platoId);
                        int filas = cmd.ExecuteNonQuery();
                        r.Exito = filas > 0;
                        if (!r.Exito)
                        {
                            r.Mensaje = "Plato no encontrado.";
                        }
                        else if (usado)
                        {
                            r.Mensaje = "Desactivado: este plato ya aparece en una orden, no se puede borrar. Queda fuera del menú.";
                        }
                        else
                        {
                            r.Mensaje = "Plato desactivado del menú.";
                        }
                    }
                }
            }
            catch (MySqlException ex)
