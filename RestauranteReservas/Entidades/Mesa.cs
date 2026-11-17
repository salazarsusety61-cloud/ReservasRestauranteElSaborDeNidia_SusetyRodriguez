using System;
using System.Collections.Generic;

namespace RestauranteReservas.Entidades
{
    public class Mesa
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Capacidad { get; set; }
        public string Forma { get; set; } = "Cuadrada";
        public string Estado { get; set; } = "Disponible";
        public int PosicionX { get; set; }
        public int PosicionY { get; set; }
    }
}
