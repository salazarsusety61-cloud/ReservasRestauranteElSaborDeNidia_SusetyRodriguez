using System;
using MySqlConnector;

namespace RestauranteReservas.Datos
{
    // =====================================================================
    // Única clase que conoce la cadena de conexión (RNF-06).
    // Paquete NuGet exigido en el Avance 3 (sección 3.2): MySqlConnector.
    // La capa Datos NO usa MessageBox: guarda el detalle del error en
    // UltimoError y la ventana es la que lo muestra (RNF-03 / RNF-04).
    // =====================================================================
    public static class ConexionBD
    {
        // No se usa la clave SslMode: el valor por defecto es "Preferred" y
        // funciona en el MySQL local. La sintaxis "SslMode=None" venía de la
        // guía del proveedor MySql.Data (Oracle); con MySqlConnector se omite
        // la clave (si hiciera falta desactivar SSL, el valor es "Disabled").
        //
        // Verificado en este equipo: el servicio MySQL 8.0.46 (servicio
        // "MySQL80.") escucha en el PUERTO 3307; el puerto 3306 lo ocupa
        // MariaDB y no es el motor del proyecto.
        private const string CadenaConexion =
            "Server=localhost;Port=3307;Database=restaurante;" +
            "User ID=root;Password=Uisil2026;";

        // Detalle del último fallo de conexión (lo lee la ventana).
        public static string UltimoError { get; private set; } = "";

        // Devuelve una conexión CERRADA. Quien la usa hace:
        //     using (var cn = ConexionBD.ObtenerConexion())
        //     {
        //         cn.Open();
        //         // ... consultas ...
        //     }
        // y la conexión se cierra sola al salir del bloque using.
        public static MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        // Prueba rápida de arranque (la llama Program.cs o FrmLogin).
        // Retorna true si MySQL responde; false si no. En false, el detalle
        // queda en UltimoError para que la ventana lo muestre.
        public static bool ProbarConexion()
        {
            UltimoError = "";
            try
            {
                using (var conexion = new MySqlConnection(CadenaConexion))
                {
                    conexion.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                // Códigos frecuentes de MySqlException.Number:
                //   0    no se pudo abrir: servicio apagado, puerto 3307 o firewall
                //   1042 no se encuentra el host (localhost mal escrito)
                //   1044 sin permisos para usar la base de datos
                //   1045 usuario o contraseña incorrectos
                //   1049 la base de datos 'restaurante' no existe (falta el script)
                UltimoError = "MySQL " + ex.Number + ": " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                UltimoError = ex.GetType().Name + ": " + ex.Message;
                return false;
            }
        }
    }
}