namespace RestauranteReservas.Presentacion
{
    partial class FrmAdministrarPlatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblCategoria = new Label();
            cboCategoria = new ComboBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblTiempo = new Label();
            txtTiempo = new TextBox();
            chkDisponible = new CheckBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnDesactivar = new Button();
            btnLimpiar = new Button();
            btnCerrar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dgvPlatos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPlatos).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(24, 26);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(97, 26);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(205, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(24, 94);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(77, 20);
            lblCategoria.TabIndex = 2;
            lblCategoria.Text = "Categoría:";
            // 
            // cboCategoria
            // 
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Items.AddRange(new object[] { "Entradas", "Platos Fuertes", "Postres", "Bebidas" });
            cboCategoria.Location = new Point(110, 91);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(192, 28);
            cboCategoria.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(24, 145);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(90, 20);
            lblDescripcion.TabIndex = 4;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(125, 142);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(177, 27);
            txtDescripcion.TabIndex = 5;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(24, 187);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(75, 20);
            lblPrecio.TabIndex = 6;
            lblPrecio.Text = "Precio (₡):";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(118, 187);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(125, 27);
            txtPrecio.TabIndex = 7;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Location = new Point(27, 239);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(186, 20);
            lblTiempo.TabIndex = 8;
            lblTiempo.Text = "Tiempo preparación (min):";
            // 
            // txtTiempo
            // 
            txtTiempo.Location = new Point(227, 239);
            txtTiempo.Name = "txtTiempo";
            txtTiempo.Size = new Size(125, 27);
            txtTiempo.TabIndex = 9;
            // 
            // chkDisponible
            // 
            chkDisponible.AutoSize = true;
            chkDisponible.Location = new Point(27, 286);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(103, 24);
            chkDisponible.TabIndex = 10;
            chkDisponible.Text = "Disponible";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(62, 341);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(162, 341);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 12;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Location = new Point(262, 341);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(94, 29);
            btnDesactivar.TabIndex = 13;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(364, 342);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 14;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(476, 343);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 29);
            btnCerrar.TabIndex = 15;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(24, 404);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(94, 20);
            lblBuscar.TabIndex = 16;
            lblBuscar.Text = "Buscar plato:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(124, 401);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(125, 27);
            txtBuscar.TabIndex = 17;
            // 
            // dgvPlatos
            // 
            dgvPlatos.AllowUserToAddRows = false;
            dgvPlatos.AllowUserToDeleteRows = false;
            dgvPlatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlatos.Location = new Point(317, 26);
            dgvPlatos.Name = "dgvPlatos";
            dgvPlatos.ReadOnly = true;
            dgvPlatos.RowHeadersWidth = 51;
            dgvPlatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlatos.Size = new Size(607, 175);
            dgvPlatos.TabIndex = 18;
            // 
            // FrmAdministrarPlatos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 503);
            Controls.Add(dgvPlatos);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(btnCerrar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnDesactivar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(chkDisponible);
            Controls.Add(txtTiempo);
            Controls.Add(lblTiempo);
            Controls.Add(txtPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(cboCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmAdministrarPlatos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrar Platillos";
            ((System.ComponentModel.ISupportInitialize)dgvPlatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblCategoria;
        private ComboBox cboCategoria;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblTiempo;
        private TextBox txtTiempo;
        private CheckBox chkDisponible;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnDesactivar;
        private Button btnCerrar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvPlatos;
        private Button btnLimpiar;
    }
}
