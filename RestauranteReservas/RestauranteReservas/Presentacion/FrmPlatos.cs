using System;
using System.Windows.Forms;
using RestauranteReservas.Datos;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmPlatos : Form
    {
        public FrmPlatos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Escribe el nombre del plato.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
                {
                    MessageBox.Show("El precio debe ser un número mayor o igual a cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? "" : txtDescripcion.Text.Trim();
                int? tiempoPreparacion = string.IsNullOrWhiteSpace(txtTiempo.Text)
                    ? null
                    : int.TryParse(txtTiempo.Text, out int t) ? t : (int?)null;
                bool disponible = chkDisponible.Checked;

                // Llamada con TODOS los parámetros: nombre, descripcion, precio, tiempo, disponible
                bool exito = PlatoDatos.Agregar(
                    txtNombre.Text.Trim(),
                    descripcion,
                    precio,
                    tiempoPreparacion,
                    disponible ? 1 : 0
                );

                if (exito)
                {
                    MessageBox.Show("Plato guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el plato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtTiempo.Clear();
            chkDisponible.Checked = true;
            txtNombre.Focus();
        }
    }
}