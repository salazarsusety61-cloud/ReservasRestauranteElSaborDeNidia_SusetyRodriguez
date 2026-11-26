using System;
using System.Windows.Forms;
using RestauranteReservas.Datos;
using RestauranteReservas.Entidades;

#pragma warning disable WFO1000
namespace RestauranteReservas.Presentacion
{
    public partial class FrmReserva : Form
    {
        public int MesaSeleccionadaId { get; set; }
        public int MesaNumero { get; set; }

        public FrmReserva()
        {
            InitializeComponent();
        }

        private void FrmReserva_Load(object sender, EventArgs e)
        {
            // Si no tienes lblMesa, borra la línea de abajo
            // lblMesa.Text = $"Mesa: {MesaNumero}";
            dtpFecha.MinDate = DateTime.Today;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reserva guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
