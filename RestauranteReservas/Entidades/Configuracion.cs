using System.Drawing;

namespace RestauranteReservas.Entidades
{
    public static class Configuracion
    {
        //  Colores de las mesas
        public static Color ColorDisponible => Color.LightGreen;
        public static Color ColorReservada => Color.LightGoldenrodYellow;
        public static Color ColorFueraDeServicio => Color.LightCoral;

        //  Horarios de atención
        public static TimeSpan HoraApertura => new TimeSpan(11, 0, 0);
        public static TimeSpan HoraCierre => new TimeSpan(21, 0, 0);

        //  Duración máxima de una reserva
        public static int DuracionMaximaMinutos => 120;
    }
}
