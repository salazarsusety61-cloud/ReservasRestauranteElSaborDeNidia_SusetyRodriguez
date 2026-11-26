namespace RestauranteReservas.Presentacion
{
    partial class FrmPlatos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            cboCategoria = new ComboBox();
            btnGuardar = new Button();
            btnDesactivar = new Button();
            SuspendLayout();

            // txtNombre
            txtNombre.Location = new Point(32, 25);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(219, 27);
            txtNombre.TabIndex = 0;

            // txtPrecio
            txtPrecio.Location = new Point(33, 86);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(218, 27);
            txtPrecio.TabIndex = 1;

            // cboCategoria
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(32, 142);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(219, 28);
            cboCategoria.TabIndex = 2;

            // btnGuardar
            btnGuardar.Location = new Point(64, 311);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(121, 29);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;

            // btnDesactivar
            btnDesactivar.Location = new Point(205, 311);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(126, 29);
            btnDesactivar.TabIndex = 4;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = true;
            btnDesactivar.Click += btnDesactivar_Click;

            // FrmPlatos
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnDesactivar);
            Controls.Add(btnGuardar);
            Controls.Add(cboCategoria);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Name = "FrmPlatos";
            Size = new Size(654, 415);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtPrecio;
        private ComboBox cboCategoria;
        private Button btnGuardar;
        private Button btnDesactivar;
    }
}
