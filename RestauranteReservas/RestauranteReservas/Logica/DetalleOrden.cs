using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteReservas.Logica
{
    internal class DetalleOrden
    {
        // Constructor
        public DetalleOrden()
        {
        }

        // Propiedades básicas
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int PlatoId { get; set; }
        public string NombrePlato { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
        public string? Observaciones { get; set; }
    }
}
