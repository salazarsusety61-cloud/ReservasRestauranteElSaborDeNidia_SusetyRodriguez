using System;
using System.Linq;
using System.Windows.Forms;
using RestauranteReservas.Datos;
using RestauranteReservas.Entidades;

namespace RestauranteReservas.Presentacion
{
    public partial class FrmRegistro : Form
    {
        private UsuarioDatos _usuarioDatos = new UsuarioDatos();

        public FrmRegistro()
        {
            InitializeComponent();
            txtClave.PasswordChar = '●';
            txtConfirmarClave.PasswordChar = '●';
            lblMensaje.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //  1. Validar campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmarClave.Text))
            {
                lblMensaje.Text = " Complete todos los campos";
                return;
            }

            //  2. Validar que las contraseñas coincidan
            if (txtClave.Text != txtConfirmarClave.Text)
            {
                lblMensaje.Text = " Las contraseñas no coinciden";
                return;
            }

            //  3. Verificar que el usuario no exista
            if (_usuarioDatos.ExisteUsuario(txtUsuario.Text.Trim()))
            {
                lblMensaje.Text = " Este nombre de usuario ya está en uso";
                return;
            }

            //  4. Verificar que el correo no exista
            if (_usuarioDatos.ExisteCorreo(txtCorreo.Text.Trim()))
            {
                lblMensaje.Text = " Este correo ya está registrado";
                return;
            }

            //  5. Crear el nuevo usuario
            Usuario nuevoUsuario = new Usuario
            {
                Nombre = txtNombre.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                NombreUsuario = txtUsuario.Text.Trim(),
                Contrasenia = txtClave.Text,
                Rol = "Cliente"
            };

            //  6. Guardar y confirmar
            _usuarioDatos.Agregar(nuevoUsuario);
            MessageBox.Show(
                "¡Usuario registrado con éxito!\nAhora puede iniciar sesión.",
                "Registro Completo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

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
