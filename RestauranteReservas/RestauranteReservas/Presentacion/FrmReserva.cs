using System;
using System.Linq;
using System.Windows.Forms;
using RestauranteReservas.RestauranteReservas.Datos;
using RestauranteReservas.RestauranteReservas.Entidades;
using RestauranteReservas.RestauranteReservas.Logica;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmReserva : Form
    {
        private Mesa _mesaSeleccionada;
        private ReservaDatos _reservaDatos = new ReservaDatos();

        // Constructor
        public FrmReserva(Mesa mesa) 
        {
            InitializeComponent();
            _mesaSeleccionada = mesa;

            //  Precargar fechas y horarios
            dtpFecha.Value = DateTime.Today;
            dtpHoraInicio.Value = new DateTime(2026, 1, 1, 11, 0, 0);
            dtpHoraFin.Value = new DateTime(2026, 1, 1, 21, 0, 0);
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
                CantidadPersonas = (int)nudPersonas.Value
            };

            // Obtener reservas existentes de esa mesa para hoy
            var reservasExistentes = _reservaDatos.ListarPorMesaYFecha(_mesaSeleccionada.Id, dtpFecha.Value);

            //  Validar usando la Capa Lógica
            string mensajeError = ReservaLogica.ValidarReserva(
                nuevaReserva,
                _mesaSeleccionada.Capacidad,
                reservasExistentes
            );

            // Si hay error, mostrarlo
            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  Si todo está bien, guardar
            _reservaDatos.Agregar(nuevaReserva);

            MessageBox.Show(" Reserva guardada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
