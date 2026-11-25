using System;
using System.Windows.Forms;
using RestauranteReservas.Datos;

namespace RestauranteReservas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //  Prueba de conexión con MySQL
            bool conectado = ConexionBD.ProbarConexion();
            if (conectado)
            {
                MessageBox.Show(" ¡CONECTADO A MYSQL CORRECTAMENTE!");
            }
            else
            {
                MessageBox.Show(" No se pudo conectar a MySQL");
            }

            Application.Run(new Presentacion.FrmLogin());
        }
    }
}
