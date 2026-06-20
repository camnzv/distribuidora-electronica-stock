namespace DistribuidoraElectronicaStock.Presentacion
{
    partial class FrmPrincipalEncargadoInventario
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEncargadoDeInventario = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.btnGestionProductos = new System.Windows.Forms.Button();
            this.lblGestionProveedores = new System.Windows.Forms.Label();
            this.btnGestionProveedores = new System.Windows.Forms.Button();
            this.lblOrdenCompra = new System.Windows.Forms.Label();
            this.btnGenerarOrdenCompra = new System.Windows.Forms.Button();
            this.btnRegistrarEntradaStock = new System.Windows.Forms.Button();
            this.btnVisualizarBajoStock = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.lblEncargadoDeInventario);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 52);
            this.panel1.TabIndex = 0;
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
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.Color.Gray;
            this.lblStock.Location = new System.Drawing.Point(21, 73);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(69, 21);
            this.lblStock.TabIndex = 1;
            this.lblStock.Text = "Mi Stock";
            this.lblStock.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnGestionProductos
            // 
            this.btnGestionProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnGestionProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionProductos.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnGestionProductos.ForeColor = System.Drawing.Color.White;
            this.btnGestionProductos.Location = new System.Drawing.Point(25, 133);
            this.btnGestionProductos.Margin = new System.Windows.Forms.Padding(2);
            this.btnGestionProductos.Name = "btnGestionProductos";
            this.btnGestionProductos.Size = new System.Drawing.Size(150, 49);
            this.btnGestionProductos.TabIndex = 2;
            this.btnGestionProductos.Text = "Gestión de Productos";
            this.btnGestionProductos.UseVisualStyleBackColor = false;
            // 
            // lblGestionProveedores
            // 
            this.lblGestionProveedores.AutoSize = true;
            this.lblGestionProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGestionProveedores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionProveedores.ForeColor = System.Drawing.Color.Gray;
            this.lblGestionProveedores.Location = new System.Drawing.Point(21, 267);
            this.lblGestionProveedores.Name = "lblGestionProveedores";
            this.lblGestionProveedores.Size = new System.Drawing.Size(126, 21);
            this.lblGestionProveedores.TabIndex = 3;
            this.lblGestionProveedores.Text = "Mis Proveedores";
            // 
            // btnGestionProveedores
            // 
            this.btnGestionProveedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnGestionProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionProveedores.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnGestionProveedores.ForeColor = System.Drawing.Color.White;
            this.btnGestionProveedores.Location = new System.Drawing.Point(25, 319);
            this.btnGestionProveedores.Margin = new System.Windows.Forms.Padding(2);
            this.btnGestionProveedores.Name = "btnGestionProveedores";
            this.btnGestionProveedores.Size = new System.Drawing.Size(150, 49);
            this.btnGestionProveedores.TabIndex = 4;
            this.btnGestionProveedores.Text = "Gestión de Proveedores";
            this.btnGestionProveedores.UseVisualStyleBackColor = false;
            // 
            // lblOrdenCompra
            // 
            this.lblOrdenCompra.AutoSize = true;
            this.lblOrdenCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOrdenCompra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenCompra.ForeColor = System.Drawing.Color.Gray;
            this.lblOrdenCompra.Location = new System.Drawing.Point(430, 73);
            this.lblOrdenCompra.Name = "lblOrdenCompra";
            this.lblOrdenCompra.Size = new System.Drawing.Size(179, 21);
            this.lblOrdenCompra.TabIndex = 5;
            this.lblOrdenCompra.Text = "Mis Órdenes de Compra";
            // 
            // btnGenerarOrdenCompra
            // 
            this.btnGenerarOrdenCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnGenerarOrdenCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarOrdenCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarOrdenCompra.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnGenerarOrdenCompra.ForeColor = System.Drawing.Color.White;
            this.btnGenerarOrdenCompra.Location = new System.Drawing.Point(434, 133);
            this.btnGenerarOrdenCompra.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerarOrdenCompra.Name = "btnGenerarOrdenCompra";
            this.btnGenerarOrdenCompra.Size = new System.Drawing.Size(150, 49);
            this.btnGenerarOrdenCompra.TabIndex = 6;
            this.btnGenerarOrdenCompra.Text = "Generar Orden de Compra";
            this.btnGenerarOrdenCompra.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarEntradaStock
            // 
            this.btnRegistrarEntradaStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnRegistrarEntradaStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarEntradaStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarEntradaStock.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnRegistrarEntradaStock.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarEntradaStock.Location = new System.Drawing.Point(434, 200);
            this.btnRegistrarEntradaStock.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrarEntradaStock.Name = "btnRegistrarEntradaStock";
            this.btnRegistrarEntradaStock.Size = new System.Drawing.Size(150, 49);
            this.btnRegistrarEntradaStock.TabIndex = 7;
            this.btnRegistrarEntradaStock.Text = "Registrar Entrada de Stock";
            this.btnRegistrarEntradaStock.UseVisualStyleBackColor = false;
            this.btnRegistrarEntradaStock.Click += new System.EventHandler(this.btnRegistrarEntradaStock_Click);
            // 
            // btnVisualizarBajoStock
            // 
            this.btnVisualizarBajoStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnVisualizarBajoStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVisualizarBajoStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizarBajoStock.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnVisualizarBajoStock.ForeColor = System.Drawing.Color.White;
            this.btnVisualizarBajoStock.Location = new System.Drawing.Point(434, 267);
            this.btnVisualizarBajoStock.Margin = new System.Windows.Forms.Padding(2);
            this.btnVisualizarBajoStock.Name = "btnVisualizarBajoStock";
            this.btnVisualizarBajoStock.Size = new System.Drawing.Size(150, 49);
            this.btnVisualizarBajoStock.TabIndex = 8;
            this.btnVisualizarBajoStock.Text = "Ver Bajo Stock";
            this.btnVisualizarBajoStock.UseVisualStyleBackColor = false;
            this.btnVisualizarBajoStock.Click += new System.EventHandler(this.btnVisualizarBajoStock_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(623, 401);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(150, 49);
            this.btnCerrarSesion.TabIndex = 9;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FrmPrincipalEncargadoInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnVisualizarBajoStock);
            this.Controls.Add(this.btnRegistrarEntradaStock);
            this.Controls.Add(this.btnGenerarOrdenCompra);
            this.Controls.Add(this.lblOrdenCompra);
            this.Controls.Add(this.btnGestionProveedores);
            this.Controls.Add(this.lblGestionProveedores);
            this.Controls.Add(this.btnGestionProductos);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FrmPrincipalEncargadoInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distribuidora Hardware - Encargado de Inventario";
            this.Load += new System.EventHandler(this.FrmPrincipalEncargadoInventario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Button btnGestionProductos;
        private System.Windows.Forms.Label lblGestionProveedores;
        private System.Windows.Forms.Button btnGestionProveedores;
        private System.Windows.Forms.Label lblOrdenCompra;
        private System.Windows.Forms.Button btnGenerarOrdenCompra;
        private System.Windows.Forms.Button btnRegistrarEntradaStock;
        private System.Windows.Forms.Button btnVisualizarBajoStock;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblEncargadoDeInventario;
    }
}