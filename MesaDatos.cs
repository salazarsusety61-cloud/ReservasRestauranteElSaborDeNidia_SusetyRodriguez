using System;
using System.Collections.Generic;
using RestauranteReservas.Entidades;

namespace RestauranteReservas.Datos
{
    public class MesaDatos
    {
        private List<Mesa> _mesas = new List<Mesa>();

        public MesaDatos()
        {
            // Crear 10 mesas con sus datos
            _mesas.Add(new Mesa { Id = 1, Nombre = "Mesa 1", Capacidad = 2, PosicionX = 30, PosicionY = 30, Forma = "Redonda", Estado = "Disponible" });
            _mesas.Add(new Mesa { Id = 2, Nombre = "Mesa 2", Capacidad = 4, PosicionX = 120, PosicionY = 30, Forma = "Cuadrada", Estado = "Disponible" });
            _mesas.Add(new Mesa { Id = 3, Nombre = "Mesa 3", Capacidad = 2, PosicionX = 220, PosicionY = 30, Forma = "Redonda", Estado = "Disponible" });
            _mesas.Add(new Mesa { Id = 4, Nombre = "Mesa 4", Capacidad = 4, PosicionX = 30, PosicionY = 130, Forma = "Cuadrada", Estado = "Disponible" });
            _mesas.Add(new Mesa { Id = 5, Nombre = "Mesa 5", Capacidad = 6, PosicionX = 120, PosicionY = 130, Forma = "Rectangular", Estado = "Disponible" });
            _mesas.Add(new Mesa { Id = 6, Nombre = "Mesa 6", Capacidad = 2, PosicionX = 220, PosicionY = 130, Forma = "Redonda", Estado = "Disponible" });
            _mesas.Add(new Mesa { Id = 7, Nombre = "Mesa 7", Capacidad = 4, PosicionX = 30, PosicionY = 230, Forma = "Cuadrada", Estado = "Disponible" });
            _mesas.Add(new Mesa { Id = 8, Nombre = "Mesa 8", Capacidad = 2, PosicionX = 120, PosicionY = 230, Forma = "Redonda", Estado = "Fuera de Servicio" });
            _mesas.Add(new Mesa { Id = 9, Nombre = "Mesa 9", Capacidad = 4, PosicionX = 220, PosicionY = 230, Forma = "Cuadrada", Estado = "Disponible" });
            _mesas.Add(new Mesa { Id = 10, Nombre = "Mesa 10", Capacidad = 2, PosicionX = 30, PosicionY = 330, Forma = "Redonda", Estado = "Disponible" });
        }

        public List<Mesa> Listar()
        {
            return _mesas;
        }

        public Mesa? ObtenerPorId(int id)
        {
            return _mesas.Find(m => m.Id == id);
        }
    }
}
