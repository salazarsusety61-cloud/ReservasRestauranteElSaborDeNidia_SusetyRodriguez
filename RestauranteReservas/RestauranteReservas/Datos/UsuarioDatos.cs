using System;
using System.Collections.Generic;
using System.Linq;
using RestauranteReservas.RestauranteReservas.Entidades;

namespace RestauranteReservas.RestauranteReservas.Datos
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

        //
        // Método que usa FrmLogin para validar acceso
        public Usuario? ValidarUsuario(string nombreUsuario, string contrasenia)
        {
            return _usuarios.FirstOrDefault(u =>
                u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) &&
                u.Contrasenia == contrasenia);
        }

        //  Verifica si el nombre de usuario ya existe
        public bool ExisteUsuario(string nombreUsuario)
        {
            return _usuarios.Any(u =>
                u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
        }

        //  Verifica si el correo ya está registrado
        public bool ExisteCorreo(string correo)
        {
            return _usuarios.Any(u =>
                !string.IsNullOrEmpty(u.Correo) &&
                u.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase));
        }

        //  Agrega un nuevo usuario
        public bool Agregar(Usuario usuario)
        {
            try
            {
                // Verificar que no exista antes de agregar
                if (ExisteUsuario(usuario.NombreUsuario) ||
                    !string.IsNullOrEmpty(usuario.Correo) && ExisteCorreo(usuario.Correo))
                {
                    return false;
                }

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
