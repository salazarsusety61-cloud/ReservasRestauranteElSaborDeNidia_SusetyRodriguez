using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteReservas.Logica
{
    internal class PlatoLogica
    {
        // Constructor
        public PlatoLogica()
        {
        }

        // Aquí puedes agregar lógica de negocios para los platos
        // Ejemplo: validaciones, cálculos, reglas del negocio
        public bool ValidarDatos(string nombre, decimal precio, int tiempoPreparacion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;

            if (precio <= 0)
                return false;

            if (tiempoPreparacion <= 0)
                return false;

            return true;
        }
    }
}
