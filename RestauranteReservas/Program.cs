using System;
using System.Windows.Forms;
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
            Application.Run(new FrmLogin());
        }
    }
}