using RestauranteReservas.Datos;
using System;
using System.Windows.Forms;
using static RestauranteReservas.Datos.UsuarioDatos;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            // Ocultar contraseña
            txtContrasenia.PasswordChar = '●';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasenia = txtContrasenia.Text;

            // Validar campos vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenia))
            {
                lblMensaje.Text = "Complete todos los campos";
                lblMensaje.ForeColor = System.Drawing.Color.Orange;
                return;
            }

            try
            {
                // ✅ Usamos el método que SÍ existe en tu archivo UsuarioDatos.cs
                ResultadoLogin resultado = UsuarioDatos.ValidarLogin(usuario, contrasenia);

                if (resultado.Exito)
                {
                    lblMensaje.Text = "";
                    this.Hide();
                    FrmPlano frmPlano = new FrmPlano();
                    frmPlano.ShowDialog();
                    this.Close();
                }
                else
                {
                    lblMensaje.Text = resultado.Mensaje;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    txtContrasenia.Clear();
                    txtContrasenia.Focus();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContrasenia.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
