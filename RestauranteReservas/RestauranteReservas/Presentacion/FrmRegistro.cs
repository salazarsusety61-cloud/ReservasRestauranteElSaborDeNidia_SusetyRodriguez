using System;
using System.Windows.Forms;
using RestauranteReservas.Datos;
using RestauranteReservas.Entidades;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de registro en desarrollo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
