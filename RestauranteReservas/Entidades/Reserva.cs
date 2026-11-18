using System;

namespace RestauranteReservas.Entidades
{
    public class Reserva
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int CantidadPersonas { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public string Estado { get; set; } = "Confirmada";
        public string NombreCliente { get; set; } = string.Empty;

    }
}
