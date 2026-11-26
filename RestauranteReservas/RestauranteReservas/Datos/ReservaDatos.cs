using System;
using System.Collections.Generic;
using MySqlConnector;

namespace RestauranteReservas.Datos
{
    // =====================================================================
    // Tabla: reserva (cliente + mesa + rango de horario).
    // CP-06: persiste en MySQL al cerrar el programa.
    // CP-07 / CP-08: choque de horarios; el tope compartido (una termina
    //   cuando otra empieza) SÍ se permite.
    // CP-10: al modificar, la propia reserva no debe chocarse consigo misma.
    // CP-11: cancelar deja estado 'Cancelada' (la mesa queda libre).
    // CP-12: eliminar borra reserva + detalle_orden + factura en transaccion.
    // CP-16: busqueda por nombre con apostrofo; todo por parametros.
    //
    // Validaciones de negocio (capacidad CP-09, horario de apertura/cierre,
    // duracion maxima 120 min) las aplica la capa Logica antes de llamar
    // a Guardar; aqui solo se persiste y se detecta el choque de mesa.
    // =====================================================================
    public static class ReservaDatos
    {
        public class FilaReserva
        {
            public int Id;
            public int UsuarioId;
            public string NombreCliente = "";
            public int MesaId;
            public int NumeroMesa;
            public DateTime Fecha;
            public TimeSpan HoraInicio;
            public TimeSpan HoraFin;
            public int CantidadPersonas;
            public string Observaciones = "";
            public string Estado = "";     // Confirmada, Completada, Cancelada
        }

        // Busqueda general; con filtroNombre busca por nombre del cliente
        // (parametro LIKE seguro para apostrofos, CP-16).
        public static List<FilaReserva> Listar(string filtroNombre = null)
        {
            var lista = new List<FilaReserva>();
            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT r.id, r.usuario_id, u.nombre AS cliente,
                                                r.mesa_id, m.numero AS numero_mesa,
                                                r.fecha, r.hora_inicio, r.hora_fin,
                                                r.cantidad_personas, r.observaciones, r.estado
                                         FROM reserva r
                                         JOIN usuario u ON u.id = r.usuario_id
                                         JOIN mesa m ON m.id = r.mesa_id
                                         WHERE (@filtro IS NULL OR u.nombre LIKE @patron)
                                         ORDER BY r.fecha DESC, r.hora_inicio DESC;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@filtro", (object)filtroNombre ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@patron",
                            (object)("%" + (filtroNombre ?? "").Trim() + "%") ?? DBNull.Value);
                        using (var leer = cmd.ExecuteReader())
                            while (leer.Read()) lista.Add(LeerFila(leer));
                    }
                }
            }
            catch (MySqlException)
            {
                lista = new List<FilaReserva>();
            }
            return lista;
        }

        // Reservas del plano del dia (fecha igual a la fecha del sistema).
        public static List<FilaReserva> ListarPorFecha(DateTime fecha)
        {
            var lista = new List<FilaReserva>();
            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT r.id, r.usuario_id, u.nombre AS cliente,
                                                r.mesa_id, m.numero AS numero_mesa,
                                                r.fecha, r.hora_inicio, r.hora_fin,
                                                r.cantidad_personas, r.observaciones, r.estado
                                         FROM reserva r
                                         JOIN usuario u ON u.id = r.usuario_id
                                         JOIN mesa m ON m.id = r.mesa_id
                                         WHERE r.fecha = @fecha
                                         ORDER BY r.hora_inicio;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@fecha", fecha.Date);
                        using (var leer = cmd.ExecuteReader())
                            while (leer.Read()) lista.Add(LeerFila(leer));
                    }
                }
            }
            catch (MySqlException)
            {
                lista = new List<FilaReserva>();
            }
            return lista;
        }

        // CP-07 / CP-08: ¿otras reservas activas de la misma mesa se cruzan?
        // La comparacion es estricta (hora_inicio < nueva_hora_fin y
        // hora_fin > nueva_hora_inicio), por eso los rangos que solo se
        // tocan (19:00 fin contra 19:00 inicio) NO chocan.
        public static bool ExisteConflictoHorario(int mesaId, DateTime fecha,
                                                  TimeSpan horaInicio, TimeSpan horaFin,
                                                  int reservaIdExcluir = 0)
        {
            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"SELECT COUNT(1) FROM reserva
                                         WHERE mesa_id = @mesa
                                           AND fecha = @fecha
                                           AND estado <> 'Cancelada'
                                           AND id <> @idExcluir
                                           AND hora_inicio < @horaFin
                                           AND hora_fin   > @horaInicio;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@mesa", mesaId);
                        cmd.Parameters.AddWithValue("@fecha", fecha.Date);
                        cmd.Parameters.AddWithValue("@horaInicio", horaInicio);
                        cmd.Parameters.AddWithValue("@horaFin", horaFin);
                        cmd.Parameters.AddWithValue("@idExcluir", reservaIdExcluir);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (MySqlException)
            {
                return true; // En duda, no guardar; la ventana muestra el detalle.
            }
        }

        public static ResultadoDatos Agregar(int usuarioId, int mesaId, DateTime fecha,
                                             TimeSpan horaInicio, TimeSpan horaFin,
                                             int cantidadPersonas, string observaciones)
        {
            var r = new ResultadoDatos();
            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"INSERT INTO reserva
                        (usuario_id, mesa_id, fecha, hora_inicio, hora_fin,
                         cantidad_personas, observaciones, estado)
                        VALUES (@usuario, @mesa, @fecha, @inicio, @fin,
                                @personas, @obs, 'Confirmada');
                        SELECT LAST_INSERT_ID();";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuarioId);
                        cmd.Parameters.AddWithValue("@mesa", mesaId);
                        cmd.Parameters.AddWithValue("@fecha", fecha.Date);
                        cmd.Parameters.AddWithValue("@inicio", horaInicio);
                        cmd.Parameters.AddWithValue("@fin", horaFin);
                        cmd.Parameters.AddWithValue("@personas", cantidadPersonas);
                        cmd.Parameters.AddWithValue("@obs", (object)observaciones ?? DBNull.Value);

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

        // CP-10: modifica la reserva (la Logica ya verifico que no se
        // choca consigo misma pasando el id a ExisteConflictoHorario).
        public static ResultadoDatos Modificar(int id, int mesaId, DateTime fecha,
                                               TimeSpan horaInicio, TimeSpan horaFin,
                                               int cantidadPersonas, string observaciones)
        {
            var r = new ResultadoDatos();
            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"UPDATE reserva SET mesa_id = @mesa, fecha = @fecha,
                                            hora_inicio = @inicio, hora_fin = @fin,
                                            cantidad_personas = @personas, observaciones = @obs
                                         WHERE id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@mesa", mesaId);
                        cmd.Parameters.AddWithValue("@fecha", fecha.Date);
                        cmd.Parameters.AddWithValue("@inicio", horaInicio);
                        cmd.Parameters.AddWithValue("@fin", horaFin);
                        cmd.Parameters.AddWithValue("@personas", cantidadPersonas);
                        cmd.Parameters.AddWithValue("@obs", (object)observaciones ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", id);

                        r.Exito = cmd.ExecuteNonQuery() > 0;
                        r.Mensaje = r.Exito ? "OK" : "Reserva no encontrada.";
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

        // Cambia el estado: Confirmada, Completada, Cancelada.
        // CP-11: Cancelar usa estado 'Cancelada'.
        public static ResultadoDatos CambiarEstado(int id, string estado)
        {
            var r = new ResultadoDatos();
            if (estado != "Confirmada" && estado != "Completada" && estado != "Cancelada")
            {
                r.Mensaje = "Estado no válido (Confirmada, Completada o Cancelada).";
                return r;
            }
            try
            {
                using (var cn = ConexionBD.ObtenerConexion())
                {
                    cn.Open();
                    const string sql = @"UPDATE reserva SET estado = @estado WHERE id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.Parameters.AddWithValue("@id", id);
                        r.Exito = cmd.ExecuteNonQuery() > 0;
                        r.Mensaje = r.Exito ? "OK" : "Reserva no encontrada.";
                    }
                }
            }
            catch (MySqlException ex)
            {
                r.Mensaje = "MySQL " + ex.Number + ": " + ex.Message;
            }
            return r;
        }

        // CP-12: borra en una transaccion la factura, las lineas de orden y
        // la reserva; si algo falla, se revierte todo (ROLLBACK).
        public static ResultadoDatos EliminarConDetalle(int idReserva)
        {
            var r = new ResultadoDatos();
            MySqlConnection cn = null;
            MySqlTransaction tx = null;
            try
            {
                cn = ConexionBD.ObtenerConexion();
                cn.Open();
                tx = cn.BeginTransaction();

                EjecutarBorrado(cn, tx, @"DELETE FROM factura WHERE reserva_id = @id;", idReserva);
                EjecutarBorrado(cn, tx, @"DELETE FROM detalle_orden WHERE reserva_id = @id;", idReserva);
                int filas = EjecutarBorrado(cn, tx, @"DELETE FROM reserva WHERE id = @id;", idReserva);

                tx.Commit();
                r.Exito = filas > 0;
                r.Mensaje = r.Exito ? "OK" : "Reserva no encontrada.";
            }
            catch (Exception ex)
            {
                if (tx != null) try { tx.Rollback(); } catch { /* ya revertida */ }
                r.Mensaje = "No se pudo eliminar la reserva: " + ex.Message;
            }
            finally
            {
                if (tx != null) tx.Dispose();
                if (cn != null) cn.Dispose();
            }
            return r;
        }

        private static int EjecutarBorrado(MySqlConnection cn, MySqlTransaction tx,
                                           string sql, int idReserva)
        {
            using (var cmd = new MySqlCommand(sql, cn, tx))
            {
                cmd.Parameters.AddWithValue("@id", idReserva);
                return cmd.ExecuteNonQuery();
            }
        }

        private static FilaReserva LeerFila(MySqlDataReader leer)
        {
            int ordObs = leer.GetOrdinal("observaciones");
            return new FilaReserva
            {
                Id = leer.GetInt32(leer.GetOrdinal("id")),
                UsuarioId = leer.GetInt32(leer.GetOrdinal("usuario_id")),
                NombreCliente = leer.GetString(leer.GetOrdinal("cliente")),
                MesaId = leer.GetInt32(leer.GetOrdinal("mesa_id")),
                NumeroMesa = leer.GetInt32(leer.GetOrdinal("numero_mesa")),
                Fecha = leer.GetDateTime(leer.GetOrdinal("fecha")),
                HoraInicio = leer.GetTimeSpan(leer.GetOrdinal("hora_inicio")),
                HoraFin = leer.GetTimeSpan(leer.GetOrdinal("hora_fin")),
                CantidadPersonas = leer.GetInt32(leer.GetOrdinal("cantidad_personas")),
                Observaciones = leer.IsDBNull(ordObs) ? "" : leer.GetString(ordObs),
                Estado = leer.GetString(leer.GetOrdinal("estado"))
            };
        }
    }
}