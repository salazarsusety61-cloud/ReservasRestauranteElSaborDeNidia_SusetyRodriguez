using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RestauranteReservas.Logica
{
    internal class UsuarioLogica
    {
        public UsuarioLogica()
        {
        }

        // Validar nombre de usuario
        public bool ValidarNombreUsuario(string nombreUsuario)
        {
            return !string.IsNullOrWhiteSpace(nombreUsuario)
                && nombreUsuario.Length >= 3
                && nombreUsuario.Length <= 30;
        }

        // Validar contraseña
        public bool ValidarContrasenia(string contrasenia)
        {
            return !string.IsNullOrWhiteSpace(contrasenia)
                && contrasenia.Length >= 6;
        }

        // Validar correo electrónico
        public bool ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                return false;

            try
            {
                return Regex.IsMatch(correo,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}
