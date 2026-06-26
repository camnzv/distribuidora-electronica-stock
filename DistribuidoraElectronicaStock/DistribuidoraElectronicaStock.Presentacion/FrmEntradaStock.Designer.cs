namespace DistribuidoraElectronicaStock.Presentacion
{
    partial class FrmEntradaStock
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEncargadoDeInventario = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPendientes = new System.Windows.Forms.TabPage();
            this.btnConfirmarP = new System.Windows.Forms.Button();
            this.dgvPendientes = new System.Windows.Forms.DataGridView();
            this.grpDatosP = new System.Windows.Forms.GroupBox();
            this.lblEstadoValorP = new System.Windows.Forms.Label();
            this.lblFechaValorP = new System.Windows.Forms.Label();
            this.lblProvValorP = new System.Windows.Forms.Label();
            this.lblSinPendientes = new System.Windows.Forms.Label();
            this.cmbOrdenesPendientes = new System.Windows.Forms.ComboBox();
            this.lblOrdenP = new System.Windows.Forms.Label();
            this.tabParciales = new System.Windows.Forms.TabPage();
            this.btnConfirmarParcial = new System.Windows.Forms.Button();
            this.dgvParciales = new System.Windows.Forms.DataGridView();
            this.grpDatosParcial = new System.Windows.Forms.GroupBox();
            this.lblEstadoValorParcial = new System.Windows.Forms.Label();
            this.lblFechaValorParcial = new System.Windows.Forms.Label();
            this.lblProvValorParcial = new System.Windows.Forms.Label();
            this.lblInfoParcial = new System.Windows.Forms.Label();
            this.lblSinParciales = new System.Windows.Forms.Label();
            this.cmbOrdenesParciales = new System.Windows.Forms.ComboBox();
            this.lblOrdenParcial = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).BeginInit();
            this.grpDatosP.SuspendLayout();
            this.tabParciales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParciales)).BeginInit();
            this.grpDatosParcial.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.lblEncargadoDeInventario);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 52);
            this.panel1.TabIndex = 1;
            // 
            // lblEncargadoDeInventario
            // 
            this.lblEncargadoDeInventario.AutoSize = true;
            this.lblEncargadoDeInventario.BackColor = System.Drawing.Color.Transparent;
            this.lblEncargadoDeInventario.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncargadoDeInventario.ForeColor = System.Drawing.Color.White;
            this.lblEncargadoDeInventario.Location = new System.Drawing.Point(379, 9);
            this.lblEncargadoDeInventario.Name = "lblEncargadoDeInventario";
            this.lblEncargadoDeInventario.Size = new System.Drawing.Size(233, 25);
            this.lblEncargadoDeInventario.TabIndex = 0;
            this.lblEncargadoDeInventario.Text = "Encargado De Inventario";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTitulo.Location = new System.Drawing.Point(12, 64);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(192, 21);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Registrar Entrada de Stock";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(31, 380);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 49);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPendientes);
            this.tabControl.Controls.Add(this.tabParciales);
            this.tabControl.Location = new System.Drawing.Point(190, 88);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(714, 361);
            this.tabControl.TabIndex = 10;
            // 
            // tabPendientes
            // 
            this.tabPendientes.Controls.Add(this.btnConfirmarP);
            this.tabPendientes.Controls.Add(this.dgvPendientes);
            this.tabPendientes.Controls.Add(this.grpDatosP);
            this.tabPendientes.Controls.Add(this.lblSinPendientes);
            this.tabPendientes.Controls.Add(this.cmbOrdenesPendientes);
            this.tabPendientes.Controls.Add(this.lblOrdenP);
            this.tabPendientes.Location = new System.Drawing.Point(4, 22);
            this.tabPendientes.Name = "tabPendientes";
            this.tabPendientes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPendientes.Size = new System.Drawing.Size(706, 335);
            this.tabPendientes.TabIndex = 0;
            this.tabPendientes.Text = "Órdenes Pendientes";
            this.tabPendientes.UseVisualStyleBackColor = true;
            // 
            // btnConfirmarP
            // 
            this.btnConfirmarP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnConfirmarP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarP.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnConfirmarP.ForeColor = System.Drawing.Color.White;
            this.btnConfirmarP.Location = new System.Drawing.Point(535, 280);
            this.btnConfirmarP.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmarP.Name = "btnConfirmarP";
            this.btnConfirmarP.Size = new System.Drawing.Size(150, 49);
            this.btnConfirmarP.TabIndex = 9;
            this.btnConfirmarP.Text = "Confirmar Entrada";
            this.btnConfirmarP.UseVisualStyleBackColor = false;
            this.btnConfirmarP.Click += new System.EventHandler(this.btnConfirmarP_Click);
            // 
            // dgvPendientes
            // 
            this.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendientes.Location = new System.Drawing.Point(13, 154);
            this.dgvPendientes.Name = "dgvPendientes";
            this.dgvPendientes.Size = new System.Drawing.Size(672, 121);
            this.dgvPendientes.TabIndex = 4;
            this.dgvPendientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPendientes_CellContentClick);
            // 
            // grpDatosP
            // 
            this.grpDatosP.Controls.Add(this.lblEstadoValorP);
            this.grpDatosP.Controls.Add(this.lblFechaValorP);
            this.grpDatosP.Controls.Add(this.lblProvValorP);
            this.grpDatosP.Location = new System.Drawing.Point(13, 53);
            this.grpDatosP.Name = "grpDatosP";
            this.grpDatosP.Size = new System.Drawing.Size(672, 94);
            this.grpDatosP.TabIndex = 3;
            this.grpDatosP.TabStop = false;
            this.grpDatosP.Text = "Datos de la orden";
            this.grpDatosP.Enter += new System.EventHandler(this.grpDatosP_Enter);
            // 
            // lblEstadoValorP
            // 
            this.lblEstadoValorP.AutoSize = true;
            this.lblEstadoValorP.Location = new System.Drawing.Point(7, 75);
            this.lblEstadoValorP.Name = "lblEstadoValorP";
            this.lblEstadoValorP.Size = new System.Drawing.Size(0, 13);
            this.lblEstadoValorP.TabIndex = 2;
            // 
            // lblFechaValorP
            // 
            this.lblFechaValorP.AutoSize = true;
            this.lblFechaValorP.Location = new System.Drawing.Point(7, 45);
            this.lblFechaValorP.Name = "lblFechaValorP";
            this.lblFechaValorP.Size = new System.Drawing.Size(0, 13);
            this.lblFechaValorP.TabIndex = 1;
            // 
            // lblProvValorP
            // 
            this.lblProvValorP.AutoSize = true;
            this.lblProvValorP.Location = new System.Drawing.Point(7, 20);
            this.lblProvValorP.Name = "lblProvValorP";
            this.lblProvValorP.Size = new System.Drawing.Size(0, 13);
            this.lblProvValorP.TabIndex = 0;
            // 
            // lblSinPendientes
            // 
            this.lblSinPendientes.AutoSize = true;
            this.lblSinPendientes.ForeColor = System.Drawing.Color.Gray;
            this.lblSinPendientes.Location = new System.Drawing.Point(374, 316);
            this.lblSinPendientes.Name = "lblSinPendientes";
            this.lblSinPendientes.Size = new System.Drawing.Size(137, 13);
            this.lblSinPendientes.TabIndex = 2;
            this.lblSinPendientes.Text = "No hay órdenes pendientes";
            this.lblSinPendientes.Visible = false;
            // 
            // cmbOrdenesPendientes
            // 
            this.cmbOrdenesPendientes.FormattingEnabled = true;
            this.cmbOrdenesPendientes.Location = new System.Drawing.Point(155, 6);
            this.cmbOrdenesPendientes.Name = "cmbOrdenesPendientes";
            this.cmbOrdenesPendientes.Size = new System.Drawing.Size(121, 21);
            this.cmbOrdenesPendientes.TabIndex = 1;
            this.cmbOrdenesPendientes.SelectedIndexChanged += new System.EventHandler(this.cmbOrdenesPendientes_SelectedIndexChanged);
            // 
            // lblOrdenP
            // 
            this.lblOrdenP.AutoSize = true;
            this.lblOrdenP.Location = new System.Drawing.Point(7, 7);
            this.lblOrdenP.Name = "lblOrdenP";
            this.lblOrdenP.Size = new System.Drawing.Size(142, 13);
            this.lblOrdenP.TabIndex = 0;
            this.lblOrdenP.Text = "Orden de compra pendiente:";
            // 
            // tabParciales
            // 
            this.tabParciales.Controls.Add(this.btnConfirmarParcial);
            this.tabParciales.Controls.Add(this.dgvParciales);
            this.tabParciales.Controls.Add(this.grpDatosParcial);
            this.tabParciales.Controls.Add(this.lblInfoParcial);
            this.tabParciales.Controls.Add(this.lblSinParciales);
            this.tabParciales.Controls.Add(this.cmbOrdenesParciales);
            this.tabParciales.Controls.Add(this.lblOrdenParcial);
            this.tabParciales.Location = new System.Drawing.Point(4, 22);
            this.tabParciales.Name = "tabParciales";
            this.tabParciales.Padding = new System.Windows.Forms.Padding(3);
            this.tabParciales.Size = new System.Drawing.Size(706, 335);
            this.tabParciales.TabIndex = 1;
            this.tabParciales.Text = "Recepciones Parciales";
            this.tabParciales.UseVisualStyleBackColor = true;
            this.tabParciales.Click += new System.EventHandler(this.tabParciales_Click);
            // 
            // btnConfirmarParcial
            // 
            this.btnConfirmarParcial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnConfirmarParcial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarParcial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarParcial.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnConfirmarParcial.ForeColor = System.Drawing.Color.White;
            this.btnConfirmarParcial.Location = new System.Drawing.Point(467, 290);
            this.btnConfirmarParcial.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmarParcial.Name = "btnConfirmarParcial";
            this.btnConfirmarParcial.Size = new System.Drawing.Size(218, 40);
            this.btnConfirmarParcial.TabIndex = 10;
            this.btnConfirmarParcial.Text = "Confirmar Recepción Faltante";
            this.btnConfirmarParcial.UseVisualStyleBackColor = false;
            this.btnConfirmarParcial.Click += new System.EventHandler(this.btnConfirmarParcial_Click);
            // 
            // dgvParciales
            // 
            this.dgvParciales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParciales.Location = new System.Drawing.Point(13, 153);
            this.dgvParciales.Name = "dgvParciales";
            this.dgvParciales.Size = new System.Drawing.Size(672, 132);
            this.dgvParciales.TabIndex = 5;
            // 
            // grpDatosParcial
            // 
            this.grpDatosParcial.Controls.Add(this.lblEstadoValorParcial);
            this.grpDatosParcial.Controls.Add(this.lblFechaValorParcial);
            this.grpDatosParcial.Controls.Add(this.lblProvValorParcial);
            this.grpDatosParcial.Location = new System.Drawing.Point(13, 47);
            this.grpDatosParcial.Name = "grpDatosParcial";
            this.grpDatosParcial.Size = new System.Drawing.Size(672, 100);
            this.grpDatosParcial.TabIndex = 4;
            this.grpDatosParcial.TabStop = false;
            this.grpDatosParcial.Text = "Datos de la orden";
            // 
            // lblEstadoValorParcial
            // 
            this.lblEstadoValorParcial.AutoSize = true;
            this.lblEstadoValorParcial.Location = new System.Drawing.Point(7, 81);
            this.lblEstadoValorParcial.Name = "lblEstadoValorParcial";
            this.lblEstadoValorParcial.Size = new System.Drawing.Size(0, 13);
            this.lblEstadoValorParcial.TabIndex = 2;
            // 
            // lblFechaValorParcial
            // 
            this.lblFechaValorParcial.AutoSize = true;
            this.lblFechaValorParcial.Location = new System.Drawing.Point(7, 47);
            this.lblFechaValorParcial.Name = "lblFechaValorParcial";
            this.lblFechaValorParcial.Size = new System.Drawing.Size(0, 13);
            this.lblFechaValorParcial.TabIndex = 1;
            // 
            // lblProvValorParcial
            // 
            this.lblProvValorParcial.AutoSize = true;
            this.lblProvValorParcial.Location = new System.Drawing.Point(7, 20);
            this.lblProvValorParcial.Name = "lblProvValorParcial";
            this.lblProvValorParcial.Size = new System.Drawing.Size(0, 13);
            this.lblProvValorParcial.TabIndex = 0;
            // 
            // lblInfoParcial
            // 
            this.lblInfoParcial.AutoSize = true;
            this.lblInfoParcial.Location = new System.Drawing.Point(7, 31);
            this.lblInfoParcial.Name = "lblInfoParcial";
            this.lblInfoParcial.Size = new System.Drawing.Size(344, 13);
            this.lblInfoParcial.TabIndex = 3;
            this.lblInfoParcial.Text = "Se muestran solo los productos con unidades pendientes de recepción.";
            // 
            // lblSinParciales
            // 
            this.lblSinParciales.AutoSize = true;
            this.lblSinParciales.ForeColor = System.Drawing.Color.Gray;
            this.lblSinParciales.Location = new System.Drawing.Point(269, 317);
            this.lblSinParciales.Name = "lblSinParciales";
            this.lblSinParciales.Size = new System.Drawing.Size(187, 13);
            this.lblSinParciales.TabIndex = 2;
            this.lblSinParciales.Text = "No hay órdenes con recepción parcial";
            this.lblSinParciales.Visible = false;
            // 
            // cmbOrdenesParciales
            // 
            this.cmbOrdenesParciales.FormattingEnabled = true;
            this.cmbOrdenesParciales.Location = new System.Drawing.Point(139, 7);
            this.cmbOrdenesParciales.Name = "cmbOrdenesParciales";
            this.cmbOrdenesParciales.Size = new System.Drawing.Size(121, 21);
            this.cmbOrdenesParciales.TabIndex = 1;
            this.cmbOrdenesParciales.SelectedIndexChanged += new System.EventHandler(this.cmbOrdenesParciales_SelectedIndexChanged);
            // 
            // lblOrdenParcial
            // 
            this.lblOrdenParcial.AutoSize = true;
            this.lblOrdenParcial.Location = new System.Drawing.Point(7, 7);
            this.lblOrdenParcial.Name = "lblOrdenParcial";
            this.lblOrdenParcial.Size = new System.Drawing.Size(126, 13);
            this.lblOrdenParcial.TabIndex = 0;
            this.lblOrdenParcial.Text = "Orden de compra parcial:";
            // 
            // FrmEntradaStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 500);
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "FrmEntradaStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Entrada de Stock";
            this.Load += new System.EventHandler(this.FrmEntradaStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPendientes.ResumeLayout(false);
            this.tabPendientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).EndInit();
            this.grpDatosP.ResumeLayout(false);
            this.grpDatosP.PerformLayout();
            this.tabParciales.ResumeLayout(false);
            this.tabParciales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParciales)).EndInit();
            this.grpDatosParcial.ResumeLayout(false);
            this.grpDatosParcial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEncargadoDeInventario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPendientes;
        private System.Windows.Forms.Label lblOrdenP;
        private System.Windows.Forms.TabPage tabParciales;
        private System.Windows.Forms.GroupBox grpDatosP;
        private System.Windows.Forms.Label lblEstadoValorP;
        private System.Windows.Forms.Label lblFechaValorP;
        private System.Windows.Forms.Label lblProvValorP;
        private System.Windows.Forms.Label lblSinPendientes;
        private System.Windows.Forms.ComboBox cmbOrdenesPendientes;
        private System.Windows.Forms.Button btnConfirmarP;
        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.Label lblSinParciales;
        private System.Windows.Forms.ComboBox cmbOrdenesParciales;
        private System.Windows.Forms.Label lblOrdenParcial;
        private System.Windows.Forms.Button btnConfirmarParcial;
        private System.Windows.Forms.DataGridView dgvParciales;
        private System.Windows.Forms.GroupBox grpDatosParcial;
        private System.Windows.Forms.Label lblEstadoValorParcial;
        private System.Windows.Forms.Label lblFechaValorParcial;
        private System.Windows.Forms.Label lblProvValorParcial;
        private System.Windows.Forms.Label lblInfoParcial;
    }
}