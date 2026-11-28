using System;
using System.Windows.Forms;
using RestauranteReservas.Datos;
using RestauranteReservas.Entidades;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmAdministrarPlatos : Form
    {
        public FrmAdministrarPlatos()
        {
            InitializeComponent();
            CargarCategorias();
            CargarPlatos();
        }

        private void CargarCategorias()
        {
            cboCategoria.Items.Clear();
            cboCategoria.Items.AddRange(new string[]
            {
                "Entradas",
                "Platos Fuertes",
                "Postres",
                "Bebidas"
            });
        }

        private void CargarPlatos()
        {
            try
            {
                dgvPlatos.DataSource = PlatoDatos.ListarTodos(txtBuscar.Text);
                dgvPlatos.Columns["IdPlato"].HeaderText = "ID";
                dgvPlatos.Columns["Nombre"].HeaderText = "Nombre";
                dgvPlatos.Columns["Categoria"].HeaderText = "Categoría";
                dgvPlatos.Columns["Precio"].HeaderText = "Precio (₡)";
                dgvPlatos.Columns["Disponible"].HeaderText = "Disponible";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar platos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validaciones y llamada a PlatoDatos.Agregar(...)
        }

        private void dgvPlatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cargar datos de la fila seleccionada a los campos de texto
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPlatos.Rows[e.RowIndex];
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                cboCategoria.Text = fila.Cells["Categoria"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value?.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                txtTiempo.Text = fila.Cells["TiempoPreparacion"].Value.ToString();
                chkDisponible.Checked = Convert.ToBoolean(fila.Cells["Disponible"].Value);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarPlatos(); // Filtrar mientras se escribe
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            cboCategoria.SelectedIndex = -1;
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtTiempo.Clear();
            chkDisponible.Checked = true;
            dgvPlatos.ClearSelection();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
