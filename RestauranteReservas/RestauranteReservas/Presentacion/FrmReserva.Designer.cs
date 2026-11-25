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
            ((System.ComponentModel.ISupportInitialize)nudPersonas).BeginInit();
            SuspendLayout();
            // 
            // lblMesaInfo
            // 
            lblMesaInfo.AutoSize = true;
            lblMesaInfo.Location = new Point(29, 23);
            lblMesaInfo.Name = "lblMesaInfo";
            lblMesaInfo.Size = new Size(137, 20);
            lblMesaInfo.TabIndex = 0;
            lblMesaInfo.Text = "Mesa seleccionada:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(29, 61);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(85, 61);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(308, 27);
            dtpFecha.TabIndex = 2;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Location = new Point(29, 105);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(85, 20);
            lblHoraInicio.TabIndex = 3;
            lblHoraInicio.Text = "Hora inicio:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(111, 100);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.Size = new Size(177, 27);
            dtpHoraInicio.TabIndex = 4;
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Location = new Point(29, 145);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(66, 20);
            lblHoraFin.TabIndex = 5;
            lblHoraFin.Text = "Hora fin:";
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(111, 140);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.Size = new Size(170, 27);
            dtpHoraFin.TabIndex = 6;
            // 
            // lblPersonas
            // 
            lblPersonas.AutoSize = true;
            lblPersonas.Location = new Point(29, 188);
            lblPersonas.MinimumSize = new Size(0, 1);
            lblPersonas.Name = "lblPersonas";
            lblPersonas.Size = new Size(104, 20);
            lblPersonas.TabIndex = 7;
            lblPersonas.Text = "Cant.personas:";
            // 
            // nudPersonas
            // 
            nudPersonas.Location = new Point(138, 186);
            nudPersonas.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudPersonas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPersonas.Name = "nudPersonas";
            nudPersonas.Size = new Size(150, 27);
            nudPersonas.TabIndex = 8;
            nudPersonas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(29, 235);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(108, 20);
            lblObservaciones.TabIndex = 9;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(152, 232);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(125, 34);
            txtObservaciones.TabIndex = 10;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(55, 382);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(144, 29);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar Reserva";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(216, 383);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmReserva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            ((System.ComponentModel.ISupportInitialize)nudPersonas).EndInit();
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
    }
}