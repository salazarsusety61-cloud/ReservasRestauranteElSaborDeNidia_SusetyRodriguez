using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteReservas.Entidades
{
    public class Plato
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public decimal Precio { get; set; }
        public int CategoriaId { get; set; }
        public bool Disponible { get; set; }
    }
}
