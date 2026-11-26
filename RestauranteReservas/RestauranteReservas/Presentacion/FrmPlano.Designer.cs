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
            this.flpMesas = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // flpMesas
            this.flpMesas.AutoScroll = true;
            this.flpMesas.Location = new System.Drawing.Point(30, 80);
            this.flpMesas.Name = "flpMesas";
            this.flpMesas.Size = new System.Drawing.Size(520, 320);
            this.flpMesas.TabIndex = 0;

            // lblLeyenda
            this.lblLeyenda.AutoSize = true;
            this.lblLeyenda.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLeyenda.Location = new System.Drawing.Point(30, 420);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(400, 15);
            this.lblLeyenda.Text = "🟢 Verde = Disponible   |   🔴 Rojo = Fuera de servicio";

            // btnRegresar
            this.btnRegresar.Location = new System.Drawing.Point(370, 460);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(85, 30);
            this.btnRegresar.TabIndex = 1;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);

            // btnRefrescar
            this.btnRefrescar.Location = new System.Drawing.Point(260, 460);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(95, 30);
            this.btnRefrescar.TabIndex = 2;
            this.btnRefrescar.Text = "Actualizar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(190, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(180, 25);
            this.lblTitulo.Text = "Plano del Restaurante";

            // FrmPlano
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 520);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.lblLeyenda);
            this.Controls.Add(this.flpMesas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPlano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plano de Mesas";
            this.Load += new System.EventHandler(this.FrmPlano_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpMesas;
        private Label lblLeyenda;
        private Button btnRegresar;
        private Button btnRefrescar;
        private Label lblTitulo;
    }
}
