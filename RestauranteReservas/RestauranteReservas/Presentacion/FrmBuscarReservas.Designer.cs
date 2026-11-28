namespace RestauranteReservas.RestauranteReservas.Presentacion
{
    partial class FrmBuscarReservas
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            grpFiltros = new GroupBox();
            lblNombreCliente = new Label();
            txtNombreCliente = new TextBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            chkTodasFechas = new CheckBox();
            lblMesa = new Label();
            txtMesa = new TextBox();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            dgvReservas = new DataGridView();
            grpAcciones = new GroupBox();
            btnVerDetalle = new Button();
            btnModificar = new Button();
            btnCancelar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            SuspendLayout();
            // 
            // grpFiltros
            // 
            grpFiltros.Location = new Point(26, 29);
            grpFiltros.Name = "grpFiltros";
            grpFiltros.Size = new Size(250, 125);
            grpFiltros.TabIndex = 0;
            grpFiltros.TabStop = false;
            grpFiltros.Text = "Filtros de Búsqueda";
            grpFiltros.Enter += grpFiltros_Enter;
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Location = new Point(32, 170);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(140, 20);
            lblNombreCliente.TabIndex = 1;
            lblNombreCliente.Text = "Nombre del cliente:";
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(177, 165);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(202, 27);
            txtNombreCliente.TabIndex = 2;
            txtNombreCliente.TextChanged += txtNombreCliente_TextChanged;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(38, 214);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(94, 214);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 27);
            dtpFecha.TabIndex = 4;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // chkTodasFechas
            // 
            chkTodasFechas.AutoSize = true;
            chkTodasFechas.Location = new Point(47, 265);
            chkTodasFechas.Name = "chkTodasFechas";
            chkTodasFechas.Size = new Size(138, 24);
            chkTodasFechas.TabIndex = 5;
            chkTodasFechas.Text = "Todas las fechas";
            chkTodasFechas.UseVisualStyleBackColor = true;
            chkTodasFechas.CheckedChanged += chkTodasFechas_CheckedChanged;
            // 
            // lblMesa
            // 
            lblMesa.AutoSize = true;
            lblMesa.Location = new Point(47, 305);
            lblMesa.Name = "lblMesa";
            lblMesa.Size = new Size(126, 20);
            lblMesa.TabIndex = 6;
            lblMesa.Text = "Número de mesa:";
            // 
            // txtMesa
            // 
            txtMesa.Location = new Point(182, 306);
            txtMesa.Name = "txtMesa";
            txtMesa.Size = new Size(125, 27);
            txtMesa.TabIndex = 7;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(57, 351);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(57, 386);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += button1_Click;
            // 
            // dgvReservas
            // 
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.AllowUserToOrderColumns = true;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Location = new Point(396, 53);
            dgvReservas.MultiSelect = false;
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.RowHeadersWidth = 51;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(479, 188);
            dgvReservas.TabIndex = 10;
            dgvReservas.CellContentClick += dgvReservas_CellContentClick;
            // 
            // grpAcciones
            // 
            grpAcciones.Location = new Point(428, 266);
            grpAcciones.Name = "grpAcciones";
            grpAcciones.Size = new Size(306, 125);
            grpAcciones.TabIndex = 11;
            grpAcciones.TabStop = false;
            grpAcciones.Text = "Acciones";
            grpAcciones.Enter += grpAcciones_Enter;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Location = new Point(64, 455);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(94, 29);
            btnVerDetalle.TabIndex = 12;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(164, 455);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 13;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(264, 455);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += button1_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(364, 455);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(477, 458);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 29);
            btnCerrar.TabIndex = 16;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrmBuscarReservas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(btnCerrar);
            Controls.Add(btnEliminar);
            Controls.Add(btnCancelar);
            Controls.Add(btnModificar);
            Controls.Add(btnVerDetalle);
            Controls.Add(grpAcciones);
            Controls.Add(dgvReservas);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(txtMesa);
            Controls.Add(lblMesa);
            Controls.Add(chkTodasFechas);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(txtNombreCliente);
            Controls.Add(lblNombreCliente);
            Controls.Add(grpFiltros);
            Name = "FrmBuscarReservas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar y Gestionar Reservas";
            Load += FrmBuscarReservas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpFiltros;
        private Label lblNombreCliente;
        private TextBox txtNombreCliente;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private CheckBox chkTodasFechas;
        private Label lblMesa;
        private TextBox txtMesa;
        private Button btnBuscar;
        private Button btnLimpiar;
        private DataGridView dgvReservas;
        private GroupBox grpAcciones;
        private Button btnVerDetalle;
        private Button btnModificar;
        private Button btnCancelar;
        private Button btnEliminar;
        private Button btnCerrar;
    }
}