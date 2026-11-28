using System;

namespace RestauranteReservas.Entidades
{
    public class Mesa
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }
        public string Forma { get; set; } = "";
        public string Ubicacion { get; set; } = "";
        public bool Disponible { get; set; } = true;
        public bool EstaReservada { get; set; } = false;
    }
}
