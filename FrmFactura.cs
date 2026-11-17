using System;
using System.Windows.Forms;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmFactura : Form
    {
        public FrmFactura()
        {
            InitializeComponent();
            CargarFactura();
        }

        private void CargarFactura()
        {
            lblNumeroFactura.Text = "Nº Factura: 001";
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");

            // Limpiar y configurar la tabla de detalles
            dgvDetalleFactura.Columns.Clear();
            dgvDetalleFactura.Rows.Clear();
            dgvDetalleFactura.Columns.Add("Plato", "Plato");
            dgvDetalleFactura.Columns.Add("Cantidad", "Cant.");
            dgvDetalleFactura.Columns.Add("Precio", "Precio");
            dgvDetalleFactura.Columns.Add("Subtotal", "Subtotal");

            // Agregar los productos
            dgvDetalleFactura.Rows.Add("Casado", "2", "₡5.000", "₡10.000");
            dgvDetalleFactura.Rows.Add("Refresco", "2", "₡800", "₡1.600");

            // Calcular montos
            decimal subtotal = 11600;
            decimal servicio = subtotal * 0.10m;
            decimal iva = subtotal * 0.13m;
            decimal total = subtotal + servicio + iva;

            // Mostrar los totales
            lblSubtotal.Text = $"Subtotal: ₡{subtotal:N0}";
            lblServicio.Text = $"Servicio (10%): ₡{servicio:N0}";
            lblIVA.Text = $"IVA (13%): ₡{iva:N0}";
            lblTotal.Text = $"Total a pagar: ₡{total:N0}";
        }

        private void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Factura descargada.", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
