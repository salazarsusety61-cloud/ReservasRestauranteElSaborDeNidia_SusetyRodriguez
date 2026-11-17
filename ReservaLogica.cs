using System;
using System.Collections.Generic;
using RestauranteReservas.Entidades;
using RestauranteReservas.Datos;

namespace RestauranteReservas.Logica
{
    public class ReservaLogica
    {
        private ReservaDatos _datos = new ReservaDatos();

        public string ValidarReserva(Reserva reserva, Mesa mesa,
                                    TimeSpan horarioInicio, TimeSpan horarioFin,
                                    TimeSpan duracionMaxima)
        {
            // Regla 1: Datos obligatorios no vacíos
            if (reserva.Fecha == default || reserva.HoraInicio == default ||
                reserva.HoraFin == default || reserva.CantidadPersonas <= 0)
            {
                return " Complete todos los datos obligatorios.";
            }

            // Regla 2: Fecha y hora no en el pasado
            if (reserva.Fecha.Date < DateTime.Now.Date)
            {
                return " La fecha no puede ser anterior a hoy.";
            }
            if (reserva.Fecha.Date == DateTime.Now.Date && reserva.HoraInicio < DateTime.Now.TimeOfDay)
            {
                return " La hora de inicio ya pasó.";
            }

            // Regla 3: Hora fin debe ser mayor que hora inicio
            if (reserva.HoraFin <= reserva.HoraInicio)
            {
                return " La hora de fin debe ser posterior a la hora de inicio.";
            }

            // Regla 4: Dentro del horario de atención
            if (reserva.HoraInicio < horarioInicio || reserva.HoraFin > horarioFin)
            {
                return $" El horario de atención es de {horarioInicio:hh\\:mm} a {horarioFin:hh\\:mm}.";
            }

            // Regla 5: No exceder duración máxima
            TimeSpan duracion = reserva.HoraFin - reserva.HoraInicio;
            if (duracion > duracionMaxima)
            {
                return $" La duración máxima es de {duracionMaxima.TotalHours} horas.";
            }

            // Regla 6: No superar capacidad de la mesa
            if (reserva.CantidadPersonas > mesa.Capacidad)
            {
                return $" La mesa solo admite {mesa.Capacidad} personas.";
            }

            // Regla 7: No chocar con otra reserva
            List<Reserva> ocupadas = _datos.ObtenerReservasPorMesaYFecha(mesa.Id, reserva.Fecha);
            foreach (var otra in ocupadas)
            {
                bool hayChoque = reserva.HoraInicio < otra.HoraFin && reserva.HoraFin > otra.HoraInicio;
                if (hayChoque)
                {
                    return $" Conflicto con reserva de {otra.HoraInicio:hh\\:mm} a {otra.HoraFin:hh\\:mm}.";
                }
            }

            // Todo correcto
            return "";
        }

        public bool GuardarReserva(Reserva reserva)
        {
            return _datos.AgregarReserva(reserva);
        }

        public List<Reserva> ObtenerReservas(int mesaId, DateTime fecha)
        {
            return _datos.ObtenerReservasPorMesaYFecha(mesaId, fecha);
        }
    }
}
