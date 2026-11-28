using System;
using System.Drawing;
using System.Windows.Forms;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmPlano : Form
    {
        public FrmPlano()
        {
           
        }

        private void FrmPlano_Load(object sender, EventArgs e)
        {
            // Cuando se abre la ventana, se ponen los colores correctos
            ActualizarColoresMesas();
        }

        private void ActualizarColoresMesas()
        {
            // Recorre todos los controles del formulario
            foreach (Control control in this.Controls)
            {
                // Solo trabaja con los botones que dicen "Mesa"
                if (control is Button btn && btn.Text.StartsWith("Mesa"))
                {
                    string numero = btn.Text.Replace("Mesa ", "").Trim();
                    int numMesa = int.Parse(numero);

                    // Asigna el color según el estado de cada mesa
                    switch (numMesa)
                    {
                        case 1: btn.BackColor = Color.LightGreen; btn.Text = "Mesa 1\nDisponible"; break;
                        case 2: btn.BackColor = Color.LightYellow; btn.Text = "Mesa 2\nReservada"; break;
                        case 3: btn.BackColor = Color.LightCoral; btn.Text = "Mesa 3\nFuera de\nservicio"; break;
                        case 4: btn.BackColor = Color.LightGreen; btn.Text = "Mesa 4\nDisponible"; break;
                        case 5: btn.BackColor = Color.LightYellow; btn.Text = "Mesa 5\nReservada"; break;
                        case 6: btn.BackColor = Color.LightGreen; btn.Text = "Mesa 6\nDisponible"; break;
                        case 7: btn.BackColor = Color.LightYellow; btn.Text = "Mesa 7\nReservada"; break;
                        case 8: btn.BackColor = Color.LightCoral; btn.Text = "Mesa 8\nFuera de\nservicio"; break;
                        case 9: btn.BackColor = Color.LightYellow; btn.Text = "Mesa 9\nReservada"; break;
                        case 10: btn.BackColor = Color.LightGreen; btn.Text = "Mesa 10\nDisponible"; break;
                    }
                }
            }
        }

        // Botón Actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarColoresMesas();
            MessageBox.Show("Plano actualizado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Botón Regresar
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
