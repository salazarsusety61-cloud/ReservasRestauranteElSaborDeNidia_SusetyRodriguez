using MySqlConnector;

namespace RestauranteReservas.Datos
{
    internal class Conexion
    {
        public static MySqlConnection ObtenerConexion()
        {
            string cadenaConexion = "server=localhost;database=restaurante;user=root;password=Uisil2026;";
            return new MySqlConnection(cadenaConexion);
        }
    }
}