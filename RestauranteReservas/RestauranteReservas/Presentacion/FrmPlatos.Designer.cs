namespace RestauranteReservas.Presentacion
{
    partial class FrmPlatos
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblTiempo = new Label();
            txtTiempo = new TextBox();
            chkDisponible = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(34, 40);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 11;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(137, 36);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(285, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(34, 93);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(90, 20);
            lblDescripcion.TabIndex = 10;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(137, 89);
            txtDescripcion.Margin = new Padding(3, 4, 3, 4);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(285, 79);
            txtDescripcion.TabIndex = 2;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(34, 200);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(53, 20);
            lblPrecio.TabIndex = 9;
            lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(137, 196);
            txtPrecio.Margin = new Padding(3, 4, 3, 4);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(137, 27);
            txtPrecio.TabIndex = 3;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Location = new Point(34, 253);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(186, 20);
            lblTiempo.TabIndex = 8;
            lblTiempo.Text = "Tiempo preparación (min):";
            // 
            // txtTiempo
            // 
            txtTiempo.Location = new Point(226, 253);
            txtTiempo.Margin = new Padding(3, 4, 3, 4);
            txtTiempo.Name = "txtTiempo";
            txtTiempo.Size = new Size(151, 27);
            txtTiempo.TabIndex = 4;
            // 
            // chkDisponible
            // 
            chkDisponible.AutoSize = true;
            chkDisponible.Checked = true;
            chkDisponible.CheckState = CheckState.Checked;
            chkDisponible.Location = new Point(137, 307);
            chkDisponible.Margin = new Padding(3, 4, 3, 4);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(103, 24);
            chkDisponible.TabIndex = 5;
            chkDisponible.Text = "Disponible";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(137, 373);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 47);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(274, 373);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(103, 47);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmPlatos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 467);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(chkDisponible);
            Controls.Add(txtTiempo);
            Controls.Add(lblTiempo);
            Controls.Add(txtPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FrmPlatos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Plato";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.TextBox txtTiempo;
        private System.Windows.Forms.CheckBox chkDisponible;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
