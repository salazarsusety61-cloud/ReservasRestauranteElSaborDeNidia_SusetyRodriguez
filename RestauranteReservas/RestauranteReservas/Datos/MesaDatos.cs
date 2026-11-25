using System;
using System.Collections.Generic;
using System.Linq;
using RestauranteReservas.RestauranteReservas.Entidades;

namespace RestauranteReservas.RestauranteReservas.Datos
{
    public class MesaDatos
    {
        private static List<Mesa> _listaMesas = new List<Mesa>();

        // Constructor con las 10 mesas creadas
        public MesaDatos()
        {
            if (_listaMesas.Count == 0)
            {
                CrearMesasIniciales();
            }
        }

        private void CrearMesasIniciales()
        {
            _listaMesas.Add(new Mesa { Id = 1, Nombre = "Mesa 1", Capacidad = 4, Estado = "Disponible", PosicionX = 30, PosicionY = 30 });
            _listaMesas.Add(new Mesa { Id = 2, Nombre = "Mesa 2", Capacidad = 4, Estado = "Disponible", PosicionX = 110, PosicionY = 30 });
            _listaMesas.Add(new Mesa { Id = 3, Nombre = "Mesa 3", Capacidad = 2, Estado = "Fuera de Servicio", PosicionX = 190, PosicionY = 30 });
            _listaMesas.Add(new Mesa { Id = 4, Nombre = "Mesa 4", Capacidad = 6, Estado = "Disponible", PosicionX = 30, PosicionY = 120 });
            _listaMesas.Add(new Mesa { Id = 5, Nombre = "Mesa 5", Capacidad = 4, Estado = "Disponible", PosicionX = 110, PosicionY = 120 });
            _listaMesas.Add(new Mesa { Id = 6, Nombre = "Mesa 6", Capacidad = 4, Estado = "Disponible", PosicionX = 190, PosicionY = 120 });
            _listaMesas.Add(new Mesa { Id = 7, Nombre = "Mesa 7", Capacidad = 4, Estado = "Disponible", PosicionX = 30, PosicionY = 210 });
            _listaMesas.Add(new Mesa { Id = 8, Nombre = "Mesa 8", Capacidad = 2, Estado = "Fuera de Servicio", PosicionX = 110, PosicionY = 210 });
            _listaMesas.Add(new Mesa { Id = 9, Nombre = "Mesa 9", Capacidad = 4, Estado = "Disponible", PosicionX = 190, PosicionY = 210 });
            _listaMesas.Add(new Mesa { Id = 10, Nombre = "Mesa 10", Capacidad = 6, Estado = "Disponible", PosicionX = 270, PosicionY = 210 });
        }

        public List<Mesa> Listar()
        {
            return _listaMesas;
        }

        // "GUARDAR CAMBIOS"
        public void GuardarCambios(Mesa mesaActualizada)
        {
            var mesaEnLista = _listaMesas.FirstOrDefault(m => m.Id == mesaActualizada.Id);
            if (mesaEnLista != null)
            {
                mesaEnLista.Estado = mesaActualizada.Estado;
            }
        }
    }
}
