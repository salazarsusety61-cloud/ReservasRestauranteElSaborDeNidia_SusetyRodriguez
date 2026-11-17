using System;
using System.Collections.Generic;
using System.Linq;
using RestauranteReservas.Entidades;

namespace RestauranteReservas.Datos
{
    public class ReservaDatos
    {
        private List<Reserva> _reservas = new List<Reserva>();

        public bool AgregarReserva(Reserva reserva)
        {
            try
            {
                reserva.Id = _reservas.Count + 1;
                _reservas.Add(reserva);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Reserva> Listar()
        {
            return _reservas;
        }

        public List<Reserva> ObtenerReservasPorMesaYFecha(int mesaId, DateTime fecha)
        {
            return _reservas.FindAll(r => r.MesaId == mesaId && r.Fecha.Date == fecha.Date);
        }

        public List<Reserva> ListarPorMesaYFecha(int mesaId, DateTime fecha)
        {
            return ObtenerReservasPorMesaYFecha(mesaId, fecha);
        }
    }
}
