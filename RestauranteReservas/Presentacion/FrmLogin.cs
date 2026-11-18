using System;
using System.Windows.Forms;
using RestauranteReservas.Datos;
using RestauranteReservas.Entidades;
using RestauranteReservas.Presentacion;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmLogin : Form
    {
        private UsuarioDatos _usuarioDatos = new UsuarioDatos();

        public FrmLogin()
        {
            InitializeComponent();
            txtContrasenia.PasswordChar = '●';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasenia = txtContrasenia.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenia))
            {
                lblMensaje.Text = "Complete todos los campos";
                return;
            }

            Usuario usuarioEncontrado = _usuarioDatos.ValidarUsuario(usuario, contrasenia);

            if (usuarioEncontrado != null)
            {
                MessageBox.Show($"Bienvenido, {usuarioEncontrado.Nombre}!",
                    "Ingreso Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                FrmPlano frmPlano = new FrmPlano();
                frmPlano.Show();
                this.Hide();
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos";
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FrmRegistro registro = new FrmRegistro();
            registro.ShowDialog();
        }

        private void txtContrasenia_TexChanger(object sender, EventArgs e)
        {
            // Vacío, no hay problema
        }
    }
}
