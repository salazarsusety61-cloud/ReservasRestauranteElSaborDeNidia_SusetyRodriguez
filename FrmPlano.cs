using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RestauranteReservas.Datos;
using RestauranteReservas.Entidades;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmPlano : Form
    {
        private readonly MesaDatos _mesaDatos = new MesaDatos();
        private readonly ReservaDatos _reservaDatos = new ReservaDatos();

        // ✅ Inicializar listas para evitar errores de referencia nula
        private List<Mesa> _mesas = new List<Mesa>();
        private List<Reserva> _reservasHoy = new List<Reserva>();
        private Mesa? _mesaSeleccionada;

        public FrmPlano()
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Today;

            // Valores por defecto para los selectores de hora
            dtpHoraInicio.Value = new DateTime(2026, 1, 1, 11, 0, 0);
            dtpHoraFin.Value = new DateTime(2026, 1, 1, 21, 0, 0);

            // Actualizar el plano cuando cambie la fecha u horas
            dtpFecha.ValueChanged += (s, e) => { ActualizarReservasDelDia(); DibujarPlano(); };
            dtpHoraInicio.ValueChanged += (s, e) => { ActualizarReservasDelDia(); DibujarPlano(); };
            dtpHoraFin.ValueChanged += (s, e) => { ActualizarReservasDelDia(); DibujarPlano(); };

            CargarMesas();
            DibujarPlano();
        }

        private void CargarMesas()
        {
            _mesas = _mesaDatos.Listar();
            ActualizarReservasDelDia();
        }

        private void ActualizarReservasDelDia()
        {
            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan horaInicioFiltro = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan horaFinFiltro = dtpHoraFin.Value.TimeOfDay;

            _reservasHoy = _reservaDatos.Listar()
                .Where(r => r.Fecha.Date == fecha
                         && r.HoraInicio < horaFinFiltro
                         && r.HoraFin > horaInicioFiltro)
                .ToList();
        }

        // ✅ Método auxiliar para verificar si una mesa está fuera de servicio
        private bool EstaFueraDeServicio(Mesa mesa)
        {
            return mesa.Estado.Equals("Fuera de Servicio", StringComparison.OrdinalIgnoreCase);
        }

        // ✅ Método auxiliar para obtener el Id de la mesa
        private int ObtenerIdMesa(Mesa mesa)
        {
            return mesa.Id;
        }

        private Color ObtenerColorMesa(Mesa mesa)
        {
            if (EstaFueraDeServicio(mesa))
                return Color.LightCoral;

            int idMesa = ObtenerIdMesa(mesa);
            bool tieneReserva = _reservasHoy != null && _reservasHoy.Any(r => r.MesaId == idMesa);

            if (tieneReserva)
                return Color.LightGoldenrodYellow;

            return Color.LightGreen;
        }

        private string ObtenerEstadoMesa(Mesa mesa)
        {
            if (EstaFueraDeServicio(mesa))
                return "Fuera de servicio";

            int idMesa = ObtenerIdMesa(mesa);
            bool tieneReserva = _reservasHoy != null && _reservasHoy.Any(r => r.MesaId == idMesa);

            if (tieneReserva)
                return "Reservada";

            return "Disponible";
        }

        private void DibujarPlano()
        {
            if (_mesas == null || _mesas.Count == 0) return;

            pnlPlano.Controls.Clear();

            // === ELEMENTOS FIJOS DEL RESTAURANTE ===
            Label lblEntrada = new Label
            {
                Text = " ENTRADA",
                Location = new Point(150, 380),
                AutoSize = true,
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.Brown
            };
            pnlPlano.Controls.Add(lblEntrada);

            Label lblBarra = new Label
            {
                Text = " BARRA",
                BackColor = Color.LightYellow,
                Location = new Point(380, 30),
                Size = new Size(120, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 9, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle
            };
            pnlPlano.Controls.Add(lblBarra);

            Label lblCocina = new Label
            {
                Text = " COCINA",
                BackColor = Color.LightSalmon,
                Location = new Point(380, 110),
                Size = new Size(120, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 9, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle
            };
            pnlPlano.Controls.Add(lblCocina);
            // === FIN ELEMENTOS FIJOS ===

            // DIBUJAR MESAS
            foreach (var mesa in _mesas)
            {
                int idMesa = ObtenerIdMesa(mesa);
                Button btnMesa = new Button
                {
                    Name = $"btnMesa{idMesa}",
                    Text = $"Mesa {idMesa}\n{ObtenerEstadoMesa(mesa)}",
                    Location = new Point(mesa.PosicionX, mesa.PosicionY),
                    Size = new Size(70, 70),
                    BackColor = ObtenerColorMesa(mesa),
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 8),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Tag = mesa
                };
                btnMesa.Click += BtnMesa_Click;
                pnlPlano.Controls.Add(btnMesa);
            }
        }

        private void BtnMesa_Click(object? sender, EventArgs e)
        {
            if (sender == null) return;

            Button btn = (Button)sender;
            _mesaSeleccionada = btn.Tag as Mesa;

            if (_mesaSeleccionada == null) return;

            // Verificar si está fuera de servicio
            if (EstaFueraDeServicio(_mesaSeleccionada))
            {
                MessageBox.Show("Esta mesa está fuera de servicio y no se puede reservar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = ObtenerIdMesa(_mesaSeleccionada);
            var reservasMesa = _reservaDatos.ListarPorMesaYFecha(id, dtpFecha.Value);

            if (reservasMesa.Count > 0)
            {
                string info = $"Mesa {id}\nCapacidad: {_mesaSeleccionada.Capacidad} personas\n\nReservas para hoy:\n";
                foreach (var r in reservasMesa)
                    info += $"• {r.HoraInicio:hh\\:mm} - {r.HoraFin:hh\\:mm} ({r.CantidadPersonas} pers.)\n";
                MessageBox.Show(info, "Información de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult respuesta = MessageBox.Show(
                    $"Mesa {id} — Disponible\n¿Desea crear una reserva?",
                    "Mesa Disponible",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    FrmReserva frmReserva = new FrmReserva(_mesaSeleccionada);
                    if (frmReserva.ShowDialog() == DialogResult.OK)
                    {
                        ActualizarReservasDelDia();
                        DibujarPlano();
                    }
                }
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            ActualizarReservasDelDia();
            DibujarPlano();
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (_mesaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una mesa primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cambiar entre "Disponible" y "Fuera de Servicio"
            if (_mesaSeleccionada.Estado == "Disponible")
                _mesaSeleccionada.Estado = "Fuera de Servicio";
            else if (_mesaSeleccionada.Estado == "Fuera de Servicio")
                _mesaSeleccionada.Estado = "Disponible";

            DibujarPlano();
        }

        private void btnVerReservas_Click(object sender, EventArgs e)
        {
            if (_mesaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una mesa primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = ObtenerIdMesa(_mesaSeleccionada);
            var reservas = _reservaDatos.ListarPorMesaYFecha(id, dtpFecha.Value);

            if (reservas.Count == 0)
                MessageBox.Show("Esta mesa no tiene reservas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"Tiene {reservas.Count} reserva(s).", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtpHoraInicio_ValueChanged(object sender, EventArgs e)
        {
            ActualizarReservasDelDia();
            DibujarPlano();
        }

        private void dtpHoraFin_ValueChanged(object sender, EventArgs e)
        {
            ActualizarReservasDelDia();
            DibujarPlano();
        }
    }
}
