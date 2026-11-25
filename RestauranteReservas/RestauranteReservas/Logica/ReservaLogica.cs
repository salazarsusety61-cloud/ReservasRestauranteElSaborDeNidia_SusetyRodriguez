using System;
using System.Collections.Generic;
using System.Linq;
using RestauranteReservas.RestauranteReservas.Entidades;

namespace RestauranteReservas.RestauranteReservas.Logica
{
    public static class ReservaLogica
    {
        public static string ValidarReserva(Reserva reserva, int capacidadMesa, List<Reserva> reservasExistentes)
        {
            // Regla 1: Ningún dato vacío
            if (reserva == null)
                return " La reserva no puede estar vacía.";
            if (reserva.Fecha == DateTime.MinValue)
                return " Debe seleccionar una fecha.";
            if (reserva.CantidadPersonas <= 0)
                return " La cantidad de personas debe ser mayor a 0.";

            // Regla 2: NO se puede reservar en fecha u hora pasada
            DateTime fechaHoraReserva = reserva.Fecha.Date.Add(reserva.HoraInicio);
            if (fechaHoraReserva < DateTime.Now)
                return " No puede hacer reservas en fechas u horas que ya pasaron.";

            // Regla 3: Hora fin debe ser mayor a hora inicio
            if (reserva.HoraFin <= reserva.HoraInicio)
                return " La hora de fin debe ser posterior a la hora de inicio.";

            // Regla 4: Dentro del horario de atención
            if (reserva.HoraInicio < Configuracion.HoraApertura || reserva.HoraFin > Configuracion.HoraCierre)
                return $" El horario de atención es de {Configuracion.HoraApertura:hh\\:mm} a {Configuracion.HoraCierre:hh\\:mm}.";

            // Regla 5: Duración no excede el máximo
            TimeSpan duracion = reserva.HoraFin - reserva.HoraInicio;
            if (duracion.TotalMinutes > Configuracion.DuracionMaximaMinutos)
                return $" La reserva no puede durar más de {Configuracion.DuracionMaximaMinutos / 60} horas.";

            // Regla 6: No superar la capacidad de la mesa
            if (reserva.CantidadPersonas > capacidadMesa)
                return $" Esta mesa solo tiene capacidad para {capacidadMesa} personas.";

            // Regla 7: No chocar con otra reserva
            bool hayChoque = reservasExistentes.Any(r =>
                reserva.HoraInicio < r.HoraFin && reserva.HoraFin > r.HoraInicio);
            if (hayChoque)
                return " Esta mesa ya tiene una reserva en ese horario.";

            return ""; //  Todo correcto
        }
    }
}
