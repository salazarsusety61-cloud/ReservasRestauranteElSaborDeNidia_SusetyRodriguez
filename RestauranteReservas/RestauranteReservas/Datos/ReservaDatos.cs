using System;
using System.Collections.Generic;
using System.Linq;
using RestauranteReservas.RestauranteReservas.Entidades;

namespace RestauranteReservas.RestauranteReservas.Datos
{
    public class ReservaDatos
    {
        private static List<Reserva> _listaReservas = new List<Reserva>();

        // ✅ Constructor con 5 reservas de prueba
        public ReservaDatos()
        {
            DateTime hoy = DateTime.Today;

            _listaReservas.Add(new Reserva
            {
                Id = 1,
                MesaId = 2,
                Fecha = hoy,
                HoraInicio = new TimeSpan(12, 0, 0),
                HoraFin = new TimeSpan(14, 0, 0),
                CantidadPersonas = 4,
                NombreCliente = "Cliente Frecuente"
            });

            _listaReservas.Add(new Reserva
            {
                Id = 2,
                MesaId = 3,
                Fecha = hoy,
                HoraInicio = new TimeSpan(13, 0, 0),
                HoraFin = new TimeSpan(15, 0, 0),
                CantidadPersonas = 2,
                NombreCliente = "Familia Pérez"
            });

            _listaReservas.Add(new Reserva
            {
                Id = 3,
                MesaId = 5,
                Fecha = hoy,
                HoraInicio = new TimeSpan(18, 0, 0),
                HoraFin = new TimeSpan(20, 0, 0),
                CantidadPersonas = 6,
                NombreCliente = "Grupo Amigos"
            });

            _listaReservas.Add(new Reserva
            {
                Id = 4,
                MesaId = 7,
                Fecha = hoy,
                HoraInicio = new TimeSpan(19, 0, 0),
                HoraFin = new TimeSpan(20, 30, 0),
                CantidadPersonas = 3,
                NombreCliente = "Sr. Rodríguez"
            });

            _listaReservas.Add(new Reserva
            {
                Id = 5,
                MesaId = 9,
                Fecha = hoy,
                HoraInicio = new TimeSpan(11, 30, 0),
                HoraFin = new TimeSpan(13, 0, 0),
                CantidadPersonas = 2,
                NombreCliente = "Sra. Vargas"
            });
        }

        public List<Reserva> Listar()
        {
            return _listaReservas;
        }

        public List<Reserva> ListarPorMesaYFecha(int mesaId, DateTime fecha)
        {
            return _listaReservas
                .Where(r => r.MesaId == mesaId && r.Fecha.Date == fecha.Date)
                .ToList();
        }

        public void Agregar(Reserva reserva)
        {
            _listaReservas.Add(reserva);
        }
    }
}
