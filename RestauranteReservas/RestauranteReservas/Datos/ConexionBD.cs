using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RestauranteReservas.Datos
{
    public class ConexionBD
    {
        //  CAMBIA "123456" POR TU CONTRASEÑA DE ROOT DE MYSQL
        private static string cadenaConexion =
     "server=localhost;port=3306;user=root;password=uisil2026;SslMode=None;";

        public static MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadenaConexion);
        }

        public static bool ProbarConexion()
        {
            try
            {
                using (MySqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
                return false;
            }
        }
    }
}
