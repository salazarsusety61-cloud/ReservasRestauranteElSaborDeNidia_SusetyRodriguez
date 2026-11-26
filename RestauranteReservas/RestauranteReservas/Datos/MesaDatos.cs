using System;
using System.Collections.Generic;
using MySqlConnector;

namespace RestauranteReservas.Datos
{
    // =====================================================================
    // Tabla: mesa (plano del restaurante).
    // El plano se carga con Listar(); los colores y el horario no vienen
    // aqui, los trae ConfiguracionDatos. CP-05: un cambio hecho en Workbench
    // aparece al recargar porque siempre se lee de la tabla.
    // =====================================================================
    public static class MesaDatos
    {
        public class FilaMesa
        {
            public int Id;
            public int Numero;
            public int Capacidad;
            public string Forma = "";      // redonda, cuadrada, rectangular
            public int PosicionX;
            public int PosicionY;
            public bool FueraServicio;
        }

        // Lectura del plano: una fila por mesa.
        public static List<FilaMesa> Listar()
        {
            var lista = new List<FilaMesa>();

            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT id, numero, capacidad, forma,
                                                posicion_x, posicion_y, fuera_servicio
                                         FROM mesa
                                         ORDER BY numero;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    using (var leer = cmd.ExecuteReader())
                    {
                        while (leer.Read())
                            lista.Add(LeerFila(leer));
                    }
                }
            }
            catch (MySqlException)
            {
                lista = new List<FilaMesa>();
            }

            return lista;
        }

        public static FilaMesa ObtenerPorId(int id)
        {
            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT id, numero, capacidad, forma,
                                                posicion_x, posicion_y, fuera_servicio
                                         FROM mesa WHERE id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var leer = cmd.ExecuteReader())
                        {
                            return leer.Read() ? LeerFila(leer) : null;
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                return null;
            }
        }

        // CP-09: capacidad que valida la Logica al crear la reserva.
        public static int CapacidadDe(int idMesa)
        {
            var mesa = ObtenerPorId(idMesa);
            return mesa == null ? 0 : mesa.Capacidad;
        }

        // Cambia el estado fuera de servicio (el plano la pinta con el color
        // configurado para ese estado).
        public static ResultadoDatos MarcarFueraServicio(int idMesa, bool fuera)
        {
            var r = new ResultadoDatos();
            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"UPDATE mesa SET fuera_servicio = @fs WHERE id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@fs", fuera);
                        cmd.Parameters.AddWithValue("@id", idMesa);
                        r.Exito = cmd.ExecuteNonQuery() > 0;
                        r.Mensaje = r.Exito ? "OK" : "Mesa no encontrada.";
                    }
                }
            }
            catch (MySqlException ex)
            {
                r.Mensaje = "MySQL " + ex.Number + ": " + ex.Message;
            }
            catch (Exception ex)
            {
                r.Mensaje = ex.Message;
            }
            return r;
        }

        // Guardar nueva mesa o modificar la existente (Id = 0 es agregar).
        public static ResultadoDatos Guardar(FilaMesa mesa)
        {
            var r = new ResultadoDatos();
            if (mesa == null || mesa.Capacidad <= 0 || string.IsNullOrWhiteSpace(mesa.Forma))
            {
                r.Mensaje = "La capacidad y la forma son obligatorias.";
                return r;
            }

            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    string sql;
                    if (mesa.Id == 0)
                    {
                        sql = @"INSERT INTO mesa (numero, capacidad, forma, posicion_x, posicion_y, fuera_servicio)
                                VALUES (@numero, @cap, @forma, @x, @y, @fs);
                                SELECT LAST_INSERT_ID();";
                    }
                    else
                    {
                        sql = @"UPDATE mesa SET numero = @numero, capacidad = @cap, forma = @forma,
                                                posicion_x = @x, posicion_y = @y, fuera_servicio = @fs
                                WHERE id = @id;";
                    }

                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@numero", mesa.Numero);
                        cmd.Parameters.AddWithValue("@cap", mesa.Capacidad);
                        cmd.Parameters.AddWithValue("@forma", mesa.Forma);
                        cmd.Parameters.AddWithValue("@x", mesa.PosicionX);
                        cmd.Parameters.AddWithValue("@y", mesa.PosicionY);
                        cmd.Parameters.AddWithValue("@fs", mesa.FueraServicio);
                        if (mesa.Id != 0) cmd.Parameters.AddWithValue("@id", mesa.Id);

                        if (mesa.Id == 0)
                        {
                            r.IdGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                            r.Exito = true;
                        }
                        else
                        {
                            r.Exito = cmd.ExecuteNonQuery() > 0;
                        }
                        r.Mensaje = r.Exito ? "OK" : "No se guardó la mesa.";
                    }
                }
            }
            catch (MySqlException ex)
            {
                r.Mensaje = ex.Number == 1062
                    ? "Ese número de mesa ya existe."
                    : "MySQL " + ex.Number + ": " + ex.Message;
            }
            catch (Exception ex)
            {
                r.Mensaje = ex.Message;
            }
            return r;
        }

        private static FilaMesa LeerFila(MySqlDataReader leer)
        {
            return new FilaMesa
            {
                Id = leer.GetInt32(leer.GetOrdinal("id")),
                Numero = leer.GetInt32(leer.GetOrdinal("numero")),
                Capacidad = leer.GetInt32(leer.GetOrdinal("capacidad")),
                Forma = leer.GetString(leer.GetOrdinal("forma")),
                PosicionX = leer.GetInt32(leer.GetOrdinal("posicion_x")),
                PosicionY = leer.GetInt32(leer.GetOrdinal("posicion_y")),
                FueraServicio = leer.GetBoolean(leer.GetOrdinal("fuera_servicio"))
            };
        }
    }
}