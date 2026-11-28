namespace RestauranteReservas.Presentacion
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasenia = new Label();
            txtContrasenia = new TextBox();
            btnIngresar = new Button();
            btnCancelar = new Button();
            lblMensaje = new Label();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(69, 120);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(149, 116);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(228, 27);
            txtUsuario.TabIndex = 1;
            txtUsuario.KeyDown += txtUsuario_KeyDown;
            // 
            // lblContrasenia
            // 
            lblContrasenia.AutoSize = true;
            lblContrasenia.Location = new Point(69, 173);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(86, 20);
            lblContrasenia.TabIndex = 5;
            lblContrasenia.Text = "Contraseña:";
            // 
            // txtContrasenia
            // 
            txtContrasenia.Location = new Point(149, 169);
            txtContrasenia.Margin = new Padding(3, 4, 3, 4);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(228, 27);
            txtContrasenia.TabIndex = 2;
            txtContrasenia.KeyDown += txtContrasenia_KeyDown;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(149, 280);
            btnIngresar.Margin = new Padding(3, 4, 3, 4);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(103, 47);
            btnIngresar.TabIndex = 3;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(274, 280);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(103, 47);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.ForeColor = Color.Red;
            lblMensaje.Location = new Point(69, 227);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 20);
            lblMensaje.TabIndex = 1;
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(114, 27);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(261, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "El Sabor de Nidia";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 373);
            Controls.Add(lblTitulo);
            Controls.Add(lblMensaje);
            Controls.Add(btnCancelar);
            Controls.Add(btnIngresar);
            Controls.Add(txtContrasenia);
            Controls.Add(lblContrasenia);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de Sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblTitulo;
    }
}
