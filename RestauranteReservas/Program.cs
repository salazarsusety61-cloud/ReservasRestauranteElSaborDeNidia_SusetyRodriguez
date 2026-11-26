using System;
using System.Windows.Forms;
using RestauranteReservas.Datos;
using RestauranteReservas.Presentacion;

namespace RestauranteReservas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Prueba de conexión con MySQL (RNF-03 / RNF-04).
            // La capa Datos captura el error y lo guarda en UltimoError;
            // Program es quien lo muestra. Si MySQL no responde, el sistema
            // NO se cierra: advierte y abre igual la ventana de inicio.
            if (!ConexionBD.ProbarConexion())
            {
                MessageBox.Show(
                    "No se pudo conectar con la base de datos.\n" +
                    "Verifique que el servicio de MySQL esté iniciado y vuelva a intentar.\n\n" +
                    "Detalle técnico: " + ConexionBD.UltimoError,
                    "Base de datos no disponible",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            Application.Run(new FrmLogin());
        }
    }
}