using System;
using System.Collections.Generic;
using System.Linq;
using RestauranteReservas.Entidades;

namespace RestauranteReservas.Datos
{
    public class UsuarioDatos
    {
        private List<Usuario> _usuarios = new List<Usuario>();

        public UsuarioDatos()
        {
            // Usuarios de prueba
            _usuarios.Add(new Usuario
            {
                Id = 1,
                Nombre = "Administrador",
                NombreUsuario = "admin",
                Contrasenia = "admin123",
                Telefono = "",
                Correo = "",
                Rol = "Administrador"
            });

            _usuarios.Add(new Usuario
            {
                Id = 2,
                Nombre = "Cliente Uno",
                NombreUsuario = "cliente1",
                Contrasenia = "cliente123",
                Telefono = "",
                Correo = "",
                Rol = "Cliente"
            });

            _usuarios.Add(new Usuario
            {
                Id = 3,
                Nombre = "Cliente Dos",
                NombreUsuario = "cliente2",
                Contrasenia = "cliente223",
                Telefono = "",
                Correo = "",
                Rol = "Cliente"
            });
        }

        public List<Usuario> Listar()
        {
            return _usuarios;
        }

        public Usuario? ObtenerPorId(int id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }

        public Usuario? ObtenerPorUsuario(string nombreUsuario)
        {
            return _usuarios.FirstOrDefault(u =>
                u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
        }

        //  Método que usa FrmLogin para validar acceso
        public Usuario? ValidarUsuario(string nombreUsuario, string contrasenia)
        {
            return _usuarios.FirstOrDefault(u =>
                u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) &&
                u.Contrasenia == contrasenia);
        }

        public bool ExisteUsuario(string nombreUsuario)
        {
            return _usuarios.Any(u =>
                u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
        }

        public bool ExisteCorreo(string correo)
        {
            return _usuarios.Any(u =>
                u.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase));
        }

        //  Método que usa FrmRegistro para guardar usuarios nuevos
        public bool Agregar(Usuario usuario)
        {
            try
            {
                usuario.Id = _usuarios.Count + 1;
                _usuarios.Add(usuario);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
