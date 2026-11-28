using MySqlConnector;
using RestauranteReservas.Datos;
using System;
using System.Collections.Generic;

namespace RestauranteReservas.Entidades
{
    public class MesaDatos
    {
        public static List<Mesa> ObtenerTodas()
        {
            var lista = new List<Mesa>();
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = @"
                    SELECT id_mesa, numero_mesa, capacidad, forma, disponible,
                    CASE 
                        WHEN EXISTS (
                            SELECT 1 FROM reserva r 
                            WHERE r.id_mesa = m.id_mesa 
                            AND r.estado = 'Confirmada' 
                            AND r.fecha >= CURDATE()
                        ) THEN 1
                        ELSE 0
                    END AS esta_reservada
                    FROM mesa m
                    ORDER BY numero_mesa";

                using (var cmd = new MySqlCommand(sql, conn))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Mesa
                        {
                            Id = dr.GetInt32("id_mesa"),
                            Numero = dr.GetInt32("numero_mesa"),
                            Capacidad = dr.GetInt32("capacidad"),
                            Forma = dr.GetString("forma"),
                            Disponible = dr.GetBoolean("disponible"),
                            //  Agrega esta línea
                            EstaReservada = dr.GetBoolean("esta_reservada")
                        });
                    }
                }
            }
            return lista;
        }
    }
}
