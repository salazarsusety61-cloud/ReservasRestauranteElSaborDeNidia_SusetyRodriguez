using System;
using System.Windows.Forms;
using RestauranteReservas.Entidades;
using RestauranteReservas.Logica;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmReserva : Form
    {
        private Mesa _mesaSeleccionada;
        private ReservaLogica _logica = new ReservaLogica();

        // Configuración del horario del restaurante
        private readonly TimeSpan HORARIO_APERTURA = new TimeSpan(7, 0, 0);   // 7:00 AM
        private readonly TimeSpan HORARIO_CIERRE = new TimeSpan(22, 0, 0);    // 10:00 PM
        private readonly TimeSpan DURACION_MAXIMA = new TimeSpan(4, 0, 0);   // 4 horas máximo

        // Constructor
        public FrmReserva(Mesa mesa)
        {
            InitializeComponent();
            _mesaSeleccionada = mesa;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Crear objeto reserva con los datos del formulario
            Reserva nuevaReserva = new Reserva
            {
                MesaId = _mesaSeleccionada.Id,
                Fecha = dtpFecha.Value.Date,
                HoraInicio = dtpHoraInicio.Value.TimeOfDay,
                HoraFin = dtpHoraFin.Value.TimeOfDay,
                CantidadPersonas = (int)nudPersonas.Value,
                Observaciones = txtObservaciones.Text
            };

            // Validar usando la Capa Lógica
            string mensajeError = _logica.ValidarReserva(
                nuevaReserva,
                _mesaSeleccionada,
                HORARIO_APERTURA,
                HORARIO_CIERRE,
                DURACION_MAXIMA
            );

            // Si hay error, mostrarlo
            if (mensajeError != "")
            {
                MessageBox.Show(mensajeError, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si todo está bien, guardar
            if (_logica.GuardarReserva(nuevaReserva))
            {
                MessageBox.Show(" Reserva guardada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(" No se pudo guardar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
