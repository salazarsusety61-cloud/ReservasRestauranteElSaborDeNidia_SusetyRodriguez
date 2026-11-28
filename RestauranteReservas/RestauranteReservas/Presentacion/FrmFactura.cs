using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using RestauranteReservas.RestauranteReservas.Entidades;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmFactura : Form
    {
        private Reserva? _reserva;
        private static int _numeroFactura = 1;

        public FrmFactura()
        {
            InitializeComponent();
            CargarFacturaVacia();
        }

        public FrmFactura(Reserva reservaGuardada)
        {
            InitializeComponent();
            _reserva = reservaGuardada;
            CargarDatosFactura();
        }

        private void CargarFacturaVacia()
        {
            lblNumeroFactura.Text = $"Nº Factura: {_numeroFactura++:000}";
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            dgvDetalleFactura.Columns.Clear();
            dgvDetalleFactura.Rows.Clear();

            dgvDetalleFactura.Columns.Add("Plato", "Concepto");
            dgvDetalleFactura.Columns.Add("Cantidad", "Cant.");
            dgvDetalleFactura.Columns.Add("Precio", "Precio");
            dgvDetalleFactura.Columns.Add("Subtotal", "Subtotal");

            lblSubtotal.Text = "Subtotal: ₡0";
            lblServicio.Text = "Servicio (10%): ₡0";
            lblIVA.Text = "IVA (13%): ₡0";
            lblTotal.Text = "Total a pagar: ₡0";
        }

        private void CargarDatosFactura()
        {
            lblNumeroFactura.Text = $"Nº Factura: {_numeroFactura++:000}";
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            dgvDetalleFactura.Columns.Clear();
            dgvDetalleFactura.Rows.Clear();

            dgvDetalleFactura.Columns.Add("Plato", "Concepto");
            dgvDetalleFactura.Columns.Add("Cantidad", "Cant.");
            dgvDetalleFactura.Columns.Add("Precio", "Precio");
            dgvDetalleFactura.Columns.Add("Subtotal", "Subtotal");

            if (_reserva != null)
            {
                dgvDetalleFactura.Rows.Add($"Reserva Mesa {_reserva.MesaId}",
                    _reserva.CantidadPersonas, "₡15.000",
                    $"₡{15000 * _reserva.CantidadPersonas:N0}");

                decimal subtotal = 15000 * _reserva.CantidadPersonas;
                decimal servicio = subtotal * 0.10m;
                decimal iva = subtotal * 0.13m;
                decimal total = subtotal + servicio + iva;

                lblSubtotal.Text = $"Subtotal: ₡{subtotal:N0}";
                lblServicio.Text = $"Servicio (10%): ₡{servicio:N0}";
                lblIVA.Text = $"IVA (13%): ₡{iva:N0}";
                lblTotal.Text = $"Total a pagar: ₡{total:N0}";
            }
        }

        private void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"Factura_{_numeroFactura - 1:000}.txt");

                using (StreamWriter writer = new StreamWriter(ruta))
                {
                    writer.WriteLine("========================================");
                    writer.WriteLine("          EL SABOR DE NIDIA             ");
                    writer.WriteLine("      Restaurante y Servicios           ");
                    writer.WriteLine("========================================");
                    writer.WriteLine($"Factura Nº: {lblNumeroFactura.Text}");
                    writer.WriteLine($"Fecha: {lblFecha.Text}");
                    writer.WriteLine("----------------------------------------");
                    writer.WriteLine("Concepto\tCant.\tPrecio\tSubtotal");
                    writer.WriteLine("----------------------------------------");

                    foreach (DataGridViewRow fila in dgvDetalleFactura.Rows)
                    {
                        if (fila.Cells[0].Value != null)
                            writer.WriteLine($"{fila.Cells[0].Value}\t{fila.Cells[1].Value}\t{fila.Cells[2].Value}\t{fila.Cells[3].Value}");
                    }

                    writer.WriteLine("----------------------------------------");
                    writer.WriteLine($"{lblSubtotal.Text}");
                    writer.WriteLine($"{lblServicio.Text}");
                    writer.WriteLine($"{lblIVA.Text}");
                    writer.WriteLine($"{lblTotal.Text}");
                    writer.WriteLine("========================================");
                    writer.WriteLine("¡Gracias por su preferencia!");
                    writer.WriteLine("¡Vuelva pronto!");
                }

                MessageBox.Show($"Factura guardada en el escritorio:\n{ruta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {

        }
    }
}
