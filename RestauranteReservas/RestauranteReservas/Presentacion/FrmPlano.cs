using RestauranteReservas.Datos;
using RestauranteReservas.Entidades;
using RestauranteReservas.RestauranteReservas.Entidades;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmPlano : Form
    {
        public FrmPlano()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void FrmPlano_Load(object sender, EventArgs e)
        {
            CargarMesas();
            ActualizarEtiquetaEstado();
        }

        private void CargarMesas()
        {
            var lista = MesaDatos.ObtenerTodas();
            flpMesas.Controls.Clear();

            foreach (var mesa in lista)
            {
                var btn = new Button
                {
                    Width = 90,
                    Height = 90,
                    Text = $"Mesa {mesa.Numero}\nCap: {mesa.Capacidad}",
                    BackColor = mesa.Disponible ? Color.LightGreen : Color.LightCoral,
                    Tag = mesa,
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                btn.Click += BtnMesa_Click;
                flpMesas.Controls.Add(btn);
            }
        }

        private void BtnMesa_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var mesa = btn?.Tag as Mesa;
            if (mesa == null) return;

            if (!mesa.Disponible)
            {
                MessageBox.Show($"La mesa {mesa.Numero} está fuera de servicio.",
                    "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new FrmReserva())
            {
                frm.MesaSeleccionadaId = mesa.Id;
                frm.MesaNumero = mesa.Numero;
                frm.ShowDialog();
            }

            CargarMesas();
        }

        private void ActualizarEtiquetaEstado()
        {
            lblLeyenda.Text =
                "🟢 Verde = Disponible   |   🔴 Rojo = Fuera de servicio";
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin login = new FrmLogin();
            login.ShowDialog();
            this.Close();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarMesas();
        }
    }
}
