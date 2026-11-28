namespace RestauranteReservas.Presentacion
{
    partial class FrmReserva
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
            lblMesaInfo = new Label();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblHoraInicio = new Label();
            dtpHoraInicio = new DateTimePicker();
            lblHoraFin = new Label();
            dtpHoraFin = new DateTimePicker();
            lblPersonas = new Label();
            nudPersonas = new NumericUpDown();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            lblNombreCliente = new Label();
            txtNombreCliente = new TextBox();
            cboMesa = new ComboBox();
            lblEstado = new Label();
            cboEstado = new ComboBox();
            grpPlatos = new GroupBox();
            clbPlatos = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)nudPersonas).BeginInit();
            grpPlatos.SuspendLayout();
            SuspendLayout();
            // 
            // lblMesaInfo
            // 
            lblMesaInfo.AutoSize = true;
            lblMesaInfo.Location = new Point(28, 64);
            lblMesaInfo.Name = "lblMesaInfo";
            lblMesaInfo.Size = new Size(51, 20);
            lblMesaInfo.TabIndex = 0;
            lblMesaInfo.Text = "Mesa :";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(28, 103);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(75, 103);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(274, 27);
            dtpFecha.TabIndex = 2;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Location = new Point(28, 141);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(85, 20);
            lblHoraInicio.TabIndex = 3;
            lblHoraInicio.Text = "Hora inicio:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(119, 141);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.Size = new Size(88, 27);
            dtpHoraInicio.TabIndex = 4;
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Location = new Point(28, 181);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(66, 20);
            lblHoraFin.TabIndex = 5;
            lblHoraFin.Text = "Hora fin:";
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(119, 179);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.Size = new Size(88, 27);
            dtpHoraFin.TabIndex = 6;
            // 
            // lblPersonas
            // 
            lblPersonas.AutoSize = true;
            lblPersonas.Location = new Point(12, 214);
            lblPersonas.MinimumSize = new Size(0, 1);
            lblPersonas.Name = "lblPersonas";
            lblPersonas.Size = new Size(104, 20);
            lblPersonas.TabIndex = 7;
            lblPersonas.Text = "Cant.personas:";
            // 
            // nudPersonas
            // 
            nudPersonas.Location = new Point(129, 212);
            nudPersonas.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudPersonas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPersonas.Name = "nudPersonas";
            nudPersonas.Size = new Size(78, 27);
            nudPersonas.TabIndex = 8;
            nudPersonas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(12, 250);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(108, 20);
            lblObservaciones.TabIndex = 9;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(126, 245);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(125, 34);
            txtObservaciones.TabIndex = 10;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(152, 509);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(144, 29);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar Reserva";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(325, 509);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Location = new Point(12, 19);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(140, 20);
            lblNombreCliente.TabIndex = 13;
            lblNombreCliente.Text = "Nombre del cliente:";
            lblNombreCliente.Click += label1_Click;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(152, 19);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(197, 27);
            txtNombreCliente.TabIndex = 14;
            // 
            // cboMesa
            // 
            cboMesa.FormattingEnabled = true;
            cboMesa.Location = new Point(85, 64);
            cboMesa.Name = "cboMesa";
            cboMesa.Size = new Size(178, 28);
            cboMesa.TabIndex = 15;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(12, 295);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(57, 20);
            lblEstado.TabIndex = 16;
            lblEstado.Text = "Estado:";
            lblEstado.Click += lblEstado_Click;
            // 
            // cboEstado
            // 
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.FormattingEnabled = true;
            cboEstado.Items.AddRange(new object[] { "Confirmada", "Atendida", "Cancelada" });
            cboEstado.Location = new Point(75, 292);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(202, 28);
            cboEstado.TabIndex = 17;
            cboEstado.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // grpPlatos
            // 
            grpPlatos.Controls.Add(clbPlatos);
            grpPlatos.Location = new Point(28, 341);
            grpPlatos.Name = "grpPlatos";
            grpPlatos.Size = new Size(250, 125);
            grpPlatos.TabIndex = 18;
            grpPlatos.TabStop = false;
            grpPlatos.Text = "Platos solicitados";
            // 
            // clbPlatos
            // 
            clbPlatos.FormattingEnabled = true;
            clbPlatos.Location = new Point(6, 37);
            clbPlatos.Name = "clbPlatos";
            clbPlatos.Size = new Size(150, 48);
            clbPlatos.TabIndex = 19;
            // 
            // FrmReserva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 560);
            Controls.Add(grpPlatos);
            Controls.Add(cboEstado);
            Controls.Add(lblEstado);
            Controls.Add(cboMesa);
            Controls.Add(txtNombreCliente);
            Controls.Add(lblNombreCliente);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtObservaciones);
            Controls.Add(lblObservaciones);
            Controls.Add(nudPersonas);
            Controls.Add(lblPersonas);
            Controls.Add(dtpHoraFin);
            Controls.Add(lblHoraFin);
            Controls.Add(dtpHoraInicio);
            Controls.Add(lblHoraInicio);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(lblMesaInfo);
            Name = "FrmReserva";
            Text = "FrmReserva";
            Load += FrmReserva_Load_1;
            ((System.ComponentModel.ISupportInitialize)nudPersonas).EndInit();
            grpPlatos.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMesaInfo;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblHoraInicio;
        private DateTimePicker dtpHoraInicio;
        private Label lblHoraFin;
        private DateTimePicker dtpHoraFin;
        private Label lblPersonas;
        private NumericUpDown nudPersonas;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblNombreCliente;
        private TextBox txtNombreCliente;
        private ComboBox cboMesa;
        private Label lblEstado;
        private ComboBox cboEstado;
        private GroupBox grpPlatos;
        private CheckedListBox clbPlatos;
    }
}