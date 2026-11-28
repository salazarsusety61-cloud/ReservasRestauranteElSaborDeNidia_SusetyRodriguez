using System;
using System.Collections.Generic;
using MySqlConnector;

namespace RestauranteReservas.Datos
{
    // =====================================================================
    // Tabla: detalle_orden (lineas de pedido de una reserva).
    // Guarda el precio_unitario del momento (no depende del precio actual
    // del plato). CP-12: al eliminar una reserva se borran sus lineas.
    // =====================================================================
    public static class DetalleOrdenDatos
    {
        public class FilaDetalle
        {
            public int Id;
            public int ReservaId;
            public int PlatoId;
            public string PlatoNombre = "";
            public int Cantidad;
            public decimal PrecioUnitario;
            public decimal Importe;        // cantidad * precio_unitario
        }

        public static List<FilaDetalle> ListarPorReserva(int reservaId)
        {
            var lista = new List<FilaDetalle>();
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT d.id, d.reserva_id, d.plato_id, p.nombre AS plato,
                                                d.cantidad, d.precio_unitario,
                                                (d.cantidad * d.precio_unitario) AS importe
                                         FROM detalle_orden d
                                         JOIN plato p ON p.id = d.plato_id
                                         WHERE d.reserva_id = @reserva
                                         ORDER BY d.id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@reserva", reservaId);
                        using (var leer = cmd.ExecuteReader())
                            while (leer.Read()) lista.Add(LeerFila(leer));
                    }
                }
            }
            catch (MySqlException)
            {
                lista = new List<FilaDetalle>();
            }
            return lista;
        }

        // Una linea de la orden; la Logica pasa el precio del plato al momento
        // de ordenar (Consulta PlatoDatos.ObtenerPorId).
        public static ResultadoDatos GuardarLinea(int reservaId, int platoId, int cantidad, decimal precioUnitario)
        {
            var r = new ResultadoDatos();
            if (reservaId <= 0 || platoId <= 0 || cantidad <= 0 || precioUnitario < 0)
            {
                r.Mensaje = "Datos de la línea de orden no válidos.";
                return r;
            }

            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"INSERT INTO detalle_orden
                        (reserva_id, plato_id, cantidad, precio_unitario)
                        VALUES (@reserva, @plato, @cant, @precio);
                        SELECT LAST_INSERT_ID();";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@reserva", reservaId);
                        cmd.Parameters.AddWithValue("@plato", platoId);
                        cmd.Parameters.AddWithValue("@cant", cantidad);
                        cmd.Parameters.AddWithValue("@precio", precioUnitario);

                        r.IdGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                        r.Exito = true;
                        r.Mensaje = "OK";
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

        // CP-12: borra las lineas de una reserva (la llama ReservaDatos.Eliminar
        // dentro de la misma transaccion junto con factura y reserva).
        public static bool EliminarPorReserva(int reservaId)
        {
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"DELETE FROM detalle_orden WHERE reserva_id = @reserva;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@reserva", reservaId);
                        return cmd.ExecuteNonQuery() >= 0;
                    }
                }
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        private static FilaDetalle LeerFila(MySqlDataReader leer)
        {
            return new FilaDetalle
            {
                Id = leer.GetInt32(leer.GetOrdinal("id")),
                ReservaId = leer.GetInt32(leer.GetOrdinal("reserva_id")),
                PlatoId = leer.GetInt32(leer.GetOrdinal("plato_id")),
                PlatoNombre = leer.GetString(leer.GetOrdinal("plato")),
                Cantidad = leer.GetInt32(leer.GetOrdinal("cantidad")),
                PrecioUnitario = leer.GetDecimal(leer.GetOrdinal("precio_unitario")),
                Importe = leer.GetDecimal(leer.GetOrdinal("importe"))
            };
        }
    }
}