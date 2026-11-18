namespace RestauranteReservas.Presentacion
{
    partial class FrmPlano
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlPlano = new Panel();
            dtpFecha = new DateTimePicker();
            dtpHoraInicio = new DateTimePicker();
            dtpHoraFin = new DateTimePicker();
            lblFecha = new Label();
            lblDesde = new Label();
            lblHasta = new Label();
            btnCambiarEstado = new Button();
            btnVerReservas = new Button();
            lblLeyenda = new Label();
            btnCerrarSesion = new Button();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // pnlPlano
            // 
            pnlPlano.BackColor = Color.White;
            pnlPlano.BorderStyle = BorderStyle.FixedSingle;
            pnlPlano.Location = new Point(40, 33);
            pnlPlano.Name = "pnlPlano";
            pnlPlano.Size = new Size(690, 472);
            pnlPlano.TabIndex = 0;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(855, 33);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(120, 27);
            dtpFecha.TabIndex = 1;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(855, 66);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(120, 27);
            dtpHoraInicio.TabIndex = 2;
            dtpHoraInicio.ValueChanged += dtpHoraInicio_ValueChanged;
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(855, 99);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(120, 27);
            dtpHoraFin.TabIndex = 3;
            dtpHoraFin.ValueChanged += dtpHoraFin_ValueChanged;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(795, 38);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 8;
            lblFecha.Text = "Fecha:";
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(795, 73);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(54, 20);
            lblDesde.TabIndex = 7;
            lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(799, 104);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(50, 20);
            lblHasta.TabIndex = 6;
            lblHasta.Text = "Hasta:";
            // 
            // btnCambiarEstado
            // 
            btnCambiarEstado.Location = new Point(774, 155);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(210, 35);
            btnCambiarEstado.TabIndex = 4;
            btnCambiarEstado.Text = "Cambiar Estado de Mesa";
            btnCambiarEstado.UseVisualStyleBackColor = true;
            btnCambiarEstado.Click += btnCambiarEstado_Click;
            // 
            // btnVerReservas
            // 
            btnVerReservas.Location = new Point(774, 196);
            btnVerReservas.Name = "btnVerReservas";
            btnVerReservas.Size = new Size(210, 35);
            btnVerReservas.TabIndex = 5;
            btnVerReservas.Text = "Ver Reservas de Mesa";
            btnVerReservas.UseVisualStyleBackColor = true;
            btnVerReservas.Click += btnVerReservas_Click;
            // 
            // lblLeyenda
            // 
            lblLeyenda.AutoSize = true;
            lblLeyenda.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblLeyenda.Location = new Point(12, 9);
            lblLeyenda.Name = "lblLeyenda";
            lblLeyenda.Size = new Size(72, 18);
            lblLeyenda.TabIndex = 3;
            lblLeyenda.Text = "Leyenda:";
            lblLeyenda.Click += lblLeyenda_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(799, 476);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(155, 29);
            btnCerrarSesion.TabIndex = 9;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // toolTip1
            // 
            toolTip1.ShowAlways = true;
            toolTip1.Popup += FrmPlano_Load;
            // 
            // FrmPlano
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 536);
            Controls.Add(lblLeyenda);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnVerReservas);
            Controls.Add(btnCambiarEstado);
            Controls.Add(lblHasta);
            Controls.Add(lblDesde);
            Controls.Add(lblFecha);
            Controls.Add(dtpHoraFin);
            Controls.Add(dtpHoraInicio);
            Controls.Add(dtpFecha);
            Controls.Add(pnlPlano);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmPlano";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Plano del Restaurante";
            Load += FrmPlano_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlPlano;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.Button btnVerReservas;
        private System.Windows.Forms.Label lblLeyenda;
        private Button btnCerrarSesion;
        private ToolTip toolTip1;
    }
}
