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
            this.lblOrden = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grpDatosOrden = new System.Windows.Forms.GroupBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblProveedorValor = new System.Windows.Forms.Label();
            this.lblFechaEmision = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblFechaEmisionValor = new System.Windows.Forms.Label();
            this.lblEstadoValor = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.grpDatosOrden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(784, 52);
            this.panel1.TabIndex = 1;
            // 
            // lblEncargadoDeInventario
            // 
            this.lblEncargadoDeInventario.AutoSize = true;
            this.lblEncargadoDeInventario.BackColor = System.Drawing.Color.Transparent;
            this.lblEncargadoDeInventario.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncargadoDeInventario.ForeColor = System.Drawing.Color.White;
            this.lblEncargadoDeInventario.Location = new System.Drawing.Point(539, 9);
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
            // lblOrden
            // 
            this.lblOrden.AutoSize = true;
            this.lblOrden.Location = new System.Drawing.Point(183, 110);
            this.lblOrden.Name = "lblOrden";
            this.lblOrden.Size = new System.Drawing.Size(93, 13);
            this.lblOrden.TabIndex = 3;
            this.lblOrden.Text = "Orden de Compra:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(282, 107);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(326, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // grpDatosOrden
            // 
            this.grpDatosOrden.Controls.Add(this.lblEstadoValor);
            this.grpDatosOrden.Controls.Add(this.lblFechaEmisionValor);
            this.grpDatosOrden.Controls.Add(this.lblEstado);
            this.grpDatosOrden.Controls.Add(this.lblFechaEmision);
            this.grpDatosOrden.Controls.Add(this.lblProveedorValor);
            this.grpDatosOrden.Controls.Add(this.lblProveedor);
            this.grpDatosOrden.Location = new System.Drawing.Point(186, 152);
            this.grpDatosOrden.Name = "grpDatosOrden";
            this.grpDatosOrden.Size = new System.Drawing.Size(422, 110);
            this.grpDatosOrden.TabIndex = 5;
            this.grpDatosOrden.TabStop = false;
            this.grpDatosOrden.Text = "Datos de la Orden";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(7, 35);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(59, 13);
            this.lblProveedor.TabIndex = 0;
            this.lblProveedor.Text = "Proveedor:";
            this.lblProveedor.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblProveedorValor
            // 
            this.lblProveedorValor.AutoSize = true;
            this.lblProveedorValor.ForeColor = System.Drawing.Color.Black;
            this.lblProveedorValor.Location = new System.Drawing.Point(72, 20);
            this.lblProveedorValor.Name = "lblProveedorValor";
            this.lblProveedorValor.Size = new System.Drawing.Size(0, 13);
            this.lblProveedorValor.TabIndex = 1;
            // 
            // lblFechaEmision
            // 
            this.lblFechaEmision.AutoSize = true;
            this.lblFechaEmision.Location = new System.Drawing.Point(7, 62);
            this.lblFechaEmision.Name = "lblFechaEmision";
            this.lblFechaEmision.Size = new System.Drawing.Size(93, 13);
            this.lblFechaEmision.TabIndex = 2;
            this.lblFechaEmision.Text = "Fecha de emisión:";
            this.lblFechaEmision.Click += new System.EventHandler(this.lblFechaEmision_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(7, 86);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado:";
            this.lblEstado.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblFechaEmisionValor
            // 
            this.lblFechaEmisionValor.AutoSize = true;
            this.lblFechaEmisionValor.Location = new System.Drawing.Point(96, 62);
            this.lblFechaEmisionValor.Name = "lblFechaEmisionValor";
            this.lblFechaEmisionValor.Size = new System.Drawing.Size(0, 13);
            this.lblFechaEmisionValor.TabIndex = 4;
            // 
            // lblEstadoValor
            // 
            this.lblEstadoValor.AutoSize = true;
            this.lblEstadoValor.Location = new System.Drawing.Point(56, 86);
            this.lblEstadoValor.Name = "lblEstadoValor";
            this.lblEstadoValor.Size = new System.Drawing.Size(0, 13);
            this.lblEstadoValor.TabIndex = 5;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(186, 268);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(422, 181);
            this.dgvDetalle.TabIndex = 6;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(31, 310);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(150, 49);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "Confirmar Entrada";
            this.btnConfirmar.UseVisualStyleBackColor = false;
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
            // FrmEntradaStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.grpDatosOrden);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblOrden);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Name = "FrmEntradaStock";
            this.Text = "Encargado de Inventario - Registrar Entrada de Stock";
            this.Load += new System.EventHandler(this.FrmEntradaStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpDatosOrden.ResumeLayout(false);
            this.grpDatosOrden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEncargadoDeInventario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblOrden;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox grpDatosOrden;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblFechaEmision;
        private System.Windows.Forms.Label lblProveedorValor;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblEstadoValor;
        private System.Windows.Forms.Label lblFechaEmisionValor;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
    }
}