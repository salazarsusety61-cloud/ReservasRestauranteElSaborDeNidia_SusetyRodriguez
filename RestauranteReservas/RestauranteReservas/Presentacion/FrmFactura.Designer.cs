namespace RestauranteReservas.Presentacion
{
    partial class FrmFactura
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
            lblNumeroFactura = new Label();
            lblFecha = new Label();
            dgvDetalleFactura = new DataGridView();
            lblSubtotal = new Label();
            lblServicio = new Label();
            lblIVA = new Label();
            lblTotal = new Label();
            btnDescargarPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleFactura).BeginInit();
            SuspendLayout();
            // 
            // lblNumeroFactura
            // 
            lblNumeroFactura.AutoSize = true;
            lblNumeroFactura.Location = new Point(40, 22);
            lblNumeroFactura.Name = "lblNumeroFactura";
            lblNumeroFactura.Size = new Size(104, 20);
            lblNumeroFactura.TabIndex = 0;
            lblNumeroFactura.Text = "N°Factura: 001";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(39, 68);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha:";
            // 
            // dgvDetalleFactura
            // 
            dgvDetalleFactura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleFactura.Location = new Point(40, 107);
            dgvDetalleFactura.Name = "dgvDetalleFactura";
            dgvDetalleFactura.RowHeadersWidth = 51;
            dgvDetalleFactura.Size = new Size(674, 98);
            dgvDetalleFactura.TabIndex = 2;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(43, 257);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(88, 20);
            lblSubtotal.TabIndex = 3;
            lblSubtotal.Text = "Subtotal: ₡0";
            // 
            // lblServicio
            // 
            lblServicio.AutoSize = true;
            lblServicio.Location = new Point(40, 299);
            lblServicio.Name = "lblServicio";
            lblServicio.Size = new Size(126, 20);
            lblServicio.TabIndex = 4;
            lblServicio.Text = "Servicio (10%): ₡0";
            // 
            // lblIVA
            // 
            lblIVA.AutoSize = true;
            lblIVA.Location = new Point(43, 338);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(92, 20);
            lblIVA.TabIndex = 5;
            lblIVA.Text = "IVA (13%):₡0";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(43, 385);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(65, 20);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total: ₡0";
            // 
            // btnDescargarPDF
            // 
            btnDescargarPDF.Location = new Point(643, 367);
            btnDescargarPDF.Name = "btnDescargarPDF";
            btnDescargarPDF.Size = new Size(94, 29);
            btnDescargarPDF.TabIndex = 7;
            btnDescargarPDF.Text = "Descargar PDF";
            btnDescargarPDF.UseVisualStyleBackColor = true;
            btnDescargarPDF.Click += btnDescargarPDF_Click;
            // 
            // FrmFactura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 439);
            Controls.Add(btnDescargarPDF);
            Controls.Add(lblTotal);
            Controls.Add(lblIVA);
            Controls.Add(lblServicio);
            Controls.Add(lblSubtotal);
            Controls.Add(dgvDetalleFactura);
            Controls.Add(lblFecha);
            Controls.Add(lblNumeroFactura);
            Name = "FrmFactura";
            Text = "FrmFactura";
            Load += FrmFactura_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalleFactura).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumeroFactura;
        private Label lblFecha;
        private DataGridView dgvDetalleFactura;
        private Label lblSubtotal;
        private Label lblServicio;
        private Label lblIVA;
        private Label lblTotal;
        private Button btnDescargarPDF;
    }
}