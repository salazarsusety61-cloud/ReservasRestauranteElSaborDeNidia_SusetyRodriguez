using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteReservas.Entidades
{
    internal class DetalleOrden
    {
        // Propiedades de ejemplo (agrega las que necesites)
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int PlatoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
