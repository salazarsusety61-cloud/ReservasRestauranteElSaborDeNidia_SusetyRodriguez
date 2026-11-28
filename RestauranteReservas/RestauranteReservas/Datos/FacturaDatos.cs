using System;
using MySqlConnector;

namespace RestauranteReservas.Datos
{
    // =====================================================================
    // Tabla: factura (se evalua en la entrega final; la tabla ya existe en
    // el script). Subtotal + 10 % de servicio + 13 % de IVA = total.
    // La factura se emite sobre una reserva Completada.
    // =====================================================================
    public static class FacturaDatos
    {
        public static bool ExisteParaReserva(int reservaId)
        {
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT COUNT(1) FROM factura WHERE reserva_id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", reservaId);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public static ResultadoDatos Guardar(int reservaId, decimal subtotal,
                                             decimal montoServicio, decimal montoIva, decimal total)
        {
            var r = new ResultadoDatos();
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"INSERT INTO factura
                        (reserva_id, fecha_emision, subtotal, monto_servicio, monto_iva, total)
                        VALUES (@reserva, NOW(), @subtotal, @servicio, @iva, @total);
                        SELECT LAST_INSERT_ID();";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@reserva", reservaId);
                        cmd.Parameters.AddWithValue("@subtotal", subtotal);
                        cmd.Parameters.AddWithValue("@servicio", montoServicio);
                        cmd.Parameters.AddWithValue("@iva", montoIva);
                        cmd.Parameters.AddWithValue("@total", total);

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

        // CP-12: soporte de borrado. El borrado principal lo hace en
        // transaccion ReservaDatos.EliminarConDetalle; este metodo queda
        // disponible si se requiere borrar una factura aparte.
        public static bool EliminarPorReserva(int reservaId)
        {
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"DELETE FROM factura WHERE reserva_id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", reservaId);
                        return cmd.ExecuteNonQuery() >= 0;
                    }
                }
            }
            catch (MySqlException)
            {
                return false;
            }
        }
    }
}