namespace RestauranteReservas.RestauranteReservas.Presentacion
{
    partial class FrmPlano
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
            lblTitulo = new Label();
            label1 = new Label();
            lblLeyenda = new Label();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblHasta = new Label();
            dateTimePicker1 = new DateTimePicker();
            btnVerReservas = new Button();
            btnActualizar = new Button();
            btnRegresar = new Button();
            btnCerrarSeccion = new Button();
            btnMesa1 = new Button();
            btnMesa2 = new Button();
            btnMesa4 = new Button();
            btnMesa3 = new Button();
            lblMesa5 = new Button();
            btnMesa10 = new Button();
            btnMesa6 = new Button();
            btnMesa7 = new Button();
            btnMesa9 = new Button();
            btnMesa8 = new Button();
            lblBarra = new Label();
            lblCocina = new Label();
            flpMesas = new FlowLayoutPanel();
            flpMesas.SuspendLayout();
           
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(350, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(242, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "El Sabor de Nidia";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 2233);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // lblLeyenda
            // 
            lblLeyenda.AutoSize = true;
            lblLeyenda.Location = new Point(34, 570);
            lblLeyenda.Name = "lblLeyenda";
            lblLeyenda.Size = new Size(335, 20);
            lblLeyenda.TabIndex = 2;
            lblLeyenda.Text = "\U0001f7e2 Disponible\U0001f7e1 Reservada🔴 Fuera de servicio";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(640, 80);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Time;
            dtpFecha.Location = new Point(695, 75);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(78, 27);
            dtpFecha.TabIndex = 4;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(640, 173);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(50, 20);
            lblHasta.TabIndex = 5;
            lblHasta.Text = "Hasta:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.Location = new Point(697, 168);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(90, 27);
            dateTimePicker1.TabIndex = 6;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // btnVerReservas
            // 
            btnVerReservas.Location = new Point(640, 227);
            btnVerReservas.Name = "btnVerReservas";
            btnVerReservas.Size = new Size(230, 40);
            btnVerReservas.TabIndex = 7;
            btnVerReservas.Text = "Ver Reservas de Mesa";
            btnVerReservas.UseVisualStyleBackColor = true;
            btnVerReservas.Click += btnVerReservas_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(415, 560);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 40);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Cilck;
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(550, 560);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(100, 40);
            btnRegresar.TabIndex = 9;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // btnCerrarSeccion
            // 
            btnCerrarSeccion.Location = new Point(740, 560);
            btnCerrarSeccion.Name = "btnCerrarSeccion";
            btnCerrarSeccion.Size = new Size(100, 40);
            btnCerrarSeccion.TabIndex = 10;
            btnCerrarSeccion.Text = "Cerrar Sesión";
            btnCerrarSeccion.UseVisualStyleBackColor = true;
            btnCerrarSeccion.Click += btnCerrarSesion_Click;
            // 
            // btnMesa1
            // 
            btnMesa1.BackColor = Color.LightGreen;
            btnMesa1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMesa1.Location = new Point(3, 3);
            btnMesa1.Name = "btnMesa1";
            btnMesa1.Size = new Size(90, 90);
            btnMesa1.TabIndex = 11;
            btnMesa1.Text = "Mesa 1";
            btnMesa1.UseVisualStyleBackColor = false;
            // 
            // btnMesa2
            // 
            btnMesa2.BackColor = Color.LightYellow;
            btnMesa2.Location = new Point(99, 3);
            btnMesa2.Name = "btnMesa2";
            btnMesa2.Size = new Size(90, 90);
            btnMesa2.TabIndex = 12;
            btnMesa2.Text = "Mesa 2";
            btnMesa2.UseVisualStyleBackColor = false;
            // 
            // btnMesa4
            // 
            btnMesa4.BackColor = Color.LightGreen;
            btnMesa4.Location = new Point(291, 3);
            btnMesa4.Name = "btnMesa4";
            btnMesa4.Size = new Size(90, 90);
            btnMesa4.TabIndex = 13;
            btnMesa4.Text = "Mesa 4";
            btnMesa4.UseVisualStyleBackColor = false;
            // 
            // btnMesa3
            // 
            btnMesa3.BackColor = Color.LightCoral;
            btnMesa3.Location = new Point(195, 3);
            btnMesa3.Name = "btnMesa3";
            btnMesa3.Size = new Size(90, 90);
            btnMesa3.TabIndex = 14;
            btnMesa3.Text = "Mesa 3";
            btnMesa3.UseVisualStyleBackColor = false;
            btnMesa3.Click += button2_Click;
            // 
            // lblMesa5
            // 
            lblMesa5.BackColor = Color.LightYellow;
            lblMesa5.Location = new Point(387, 3);
            lblMesa5.Name = "lblMesa5";
            lblMesa5.Size = new Size(90, 90);
            lblMesa5.TabIndex = 15;
            lblMesa5.Text = "Mesa 5";
            lblMesa5.UseVisualStyleBackColor = false;
            // 
            // btnMesa10
            // 
            btnMesa10.BackColor = Color.LightGreen;
            btnMesa10.Location = new Point(387, 99);
            btnMesa10.Name = "btnMesa10";
            btnMesa10.Size = new Size(90, 90);
            btnMesa10.TabIndex = 16;
            btnMesa10.Text = "Mesa 10";
            btnMesa10.UseVisualStyleBackColor = false;
            // 
            // btnMesa6
            // 
            btnMesa6.BackColor = Color.LightGreen;
            btnMesa6.Location = new Point(3, 99);
            btnMesa6.Name = "btnMesa6";
            btnMesa6.Size = new Size(90, 90);
            btnMesa6.TabIndex = 17;
            btnMesa6.Text = "Mesa 6";
            btnMesa6.UseVisualStyleBackColor = false;
            // 
            // btnMesa7
            // 
            btnMesa7.BackColor = Color.LightYellow;
            btnMesa7.Location = new Point(99, 99);
            btnMesa7.Name = "btnMesa7";
            btnMesa7.Size = new Size(90, 90);
            btnMesa7.TabIndex = 18;
            btnMesa7.Text = "Mesa 7";
            btnMesa7.UseVisualStyleBackColor = false;
            // 
            // btnMesa9
            // 
            btnMesa9.BackColor = Color.LightYellow;
            btnMesa9.Location = new Point(291, 99);
            btnMesa9.Name = "btnMesa9";
            btnMesa9.Size = new Size(90, 90);
            btnMesa9.TabIndex = 19;
            btnMesa9.Text = "Mesa 9";
            btnMesa9.UseVisualStyleBackColor = false;
            btnMesa9.Click += btnMesa9_Click;
            // 
            // btnMesa8
            // 
            btnMesa8.BackColor = Color.LightCoral;
            btnMesa8.Location = new Point(195, 99);
            btnMesa8.Name = "btnMesa8";
            btnMesa8.Size = new Size(90, 90);
            btnMesa8.TabIndex = 20;
            btnMesa8.Text = "Mesa 8";
            btnMesa8.UseVisualStyleBackColor = false;
            btnMesa8.Click += btnMesa8_Click;
            // 
            // lblBarra
            // 
            lblBarra.AutoSize = true;
            lblBarra.BackColor = Color.IndianRed;
            lblBarra.Location = new Point(3, 192);
            lblBarra.Name = "lblBarra";
            lblBarra.Size = new Size(56, 20);
            lblBarra.TabIndex = 21;
            lblBarra.Text = "BARRA";
            lblBarra.Click += lblBarra_Click;
            // 
            // lblCocina
            // 
            lblCocina.AutoSize = true;
            lblCocina.BackColor = Color.RosyBrown;
            lblCocina.Location = new Point(483, 96);
            lblCocina.Name = "lblCocina";
            lblCocina.Size = new Size(63, 20);
            lblCocina.TabIndex = 22;
            lblCocina.Text = "COCINA";
            // 
            // flpMesas
            // 
            flpMesas.AutoScroll = true;
            flpMesas.Controls.Add(btnMesa1);
            flpMesas.Controls.Add(btnMesa2);
            flpMesas.Controls.Add(btnMesa3);
            flpMesas.Controls.Add(btnMesa4);
            flpMesas.Controls.Add(lblMesa5);
            flpMesas.Controls.Add(btnMesa6);
            flpMesas.Controls.Add(btnMesa7);
            flpMesas.Controls.Add(btnMesa8);
            flpMesas.Controls.Add(btnMesa9);
            flpMesas.Controls.Add(btnMesa10);
            flpMesas.Controls.Add(lblCocina);
            flpMesas.Controls.Add(lblBarra);
            flpMesas.Location = new Point(34, 80);
            flpMesas.Name = "flpMesas";
            flpMesas.Size = new Size(571, 467);
            flpMesas.TabIndex = 23;
            flpMesas.Paint += flpMesas_Paint;
            // 
            // FrmPlano
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 706);
            Controls.Add(flpMesas);
            Controls.Add(btnCerrarSeccion);
            Controls.Add(btnRegresar);
            Controls.Add(btnActualizar);
            Controls.Add(btnVerReservas);
            Controls.Add(dateTimePicker1);
            Controls.Add(lblHasta);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(lblLeyenda);
            Controls.Add(label1);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "FrmPlano";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Plano del Restaurante";
            Load += FrmPlano_Load;
            flpMesas.ResumeLayout(false);
            flpMesas.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label label1;
        private Label lblLeyenda;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblHasta;
        private DateTimePicker dateTimePicker1;
        private Button btnVerReservas;
        private Button btnActualizar;
        private Button btnRegresar;
        private Button btnCerrarSeccion;
        private Button btnMesa1;
        private Button btnMesa2;
        private Button btnMesa4;
        private Button btnMesa3;
        private Button lblMesa5;
        private Button btnMesa10;
        private Button btnMesa6;
        private Button btnMesa7;
        private Button btnMesa9;
        private Button btnMesa8;
        private Label lblBarra;
        private Label lblCocina;
        private FlowLayoutPanel flpMesas;
    }
}