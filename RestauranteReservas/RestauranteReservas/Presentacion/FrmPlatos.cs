using System;
using System.Windows.Forms;
using RestauranteReservas.Datos;
using RestauranteReservas.Entidades;

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
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Escribe el nombre del plato.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
                {
                    MessageBox.Show("El precio debe ser un número válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboCategoria.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecciona una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  Usamos el objeto completo en lugar de pasar cada dato separado
                var plato = new Plato
                {
                    Nombre = txtNombre.Text.Trim(),
                    Precio = precio,
                    CategoriaId = (int)cboCategoria.SelectedValue,
                    Disponible = true
                };

                bool exito = PlatoDatos.Agregar(plato);

                if (exito)
                {
                    MessageBox.Show(" Plato guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(" No se pudo guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Escribe el nombre del plato primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("¿Seguro que quieres desactivar este plato?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idPlato = 1; // ← Cambia este 1 por el ID real del plato
                    var resultado = PlatoDatos.Desactivar(idPlato);

                    if (resultado.Exito)
                    {
                        MessageBox.Show(" Plato desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show(" " + resultado.Mensaje, "No se pudo desactivar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            cboCategoria.SelectedIndex = -1;
            txtNombre.Focus();
        }
    }
}
