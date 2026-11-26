namespace RestauranteReservas.Datos
{
    // =====================================================================
    // Resultado comun de las operaciones de la capa Datos.
    // La ventana (Presentacion) lee Exito/Mensaje y muestra el MessageBox;
    // la capa Datos nunca muestra MessageBox (RF-01).
    // =====================================================================
    public class ResultadoDatos
    {
        public bool Exito;
        public string Mensaje = "";
        public int IdGenerado;   // en INSERT que devuelve LAST_INSERT_ID()
    }
}