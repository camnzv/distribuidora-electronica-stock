namespace DistribuidoraElectronicaStock.Presentacion
{
    partial class FrmPrincipalVendedor
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
            this.lblRol = new System.Windows.Forms.Label();
            this.btnAdministrarClientes = new System.Windows.Forms.Button();
            this.btnAdministrarVentas = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.Panel();
            this.btnAdministrarProductos = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.BackColor = System.Drawing.Color.Transparent;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.ForeColor = System.Drawing.Color.White;
            this.lblRol.Location = new System.Drawing.Point(737, 47);
            this.lblRol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(0, 32);
            this.lblRol.TabIndex = 2;
            // 
            // btnAdministrarClientes
            // 
            this.btnAdministrarClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAdministrarClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdministrarClientes.FlatAppearance.BorderSize = 0;
            this.btnAdministrarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrarClientes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrarClientes.ForeColor = System.Drawing.Color.White;
            this.btnAdministrarClientes.Location = new System.Drawing.Point(47, 195);
            this.btnAdministrarClientes.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdministrarClientes.Name = "btnAdministrarClientes";
            this.btnAdministrarClientes.Size = new System.Drawing.Size(200, 60);
            this.btnAdministrarClientes.TabIndex = 10;
            this.btnAdministrarClientes.Text = "Gestion de Clientes";
            this.btnAdministrarClientes.UseVisualStyleBackColor = false;
            this.btnAdministrarClientes.Click += new System.EventHandler(this.btnAdministrarClientes_Click);
            // 
            // btnAdministrarVentas
            // 
            this.btnAdministrarVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnAdministrarVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdministrarVentas.FlatAppearance.BorderSize = 0;
            this.btnAdministrarVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrarVentas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrarVentas.ForeColor = System.Drawing.Color.White;
            this.btnAdministrarVentas.Location = new System.Drawing.Point(359, 195);
            this.btnAdministrarVentas.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdministrarVentas.Name = "btnAdministrarVentas";
            this.btnAdministrarVentas.Size = new System.Drawing.Size(200, 60);
            this.btnAdministrarVentas.TabIndex = 4;
            this.btnAdministrarVentas.Text = "Gestion de Ventas";
            this.btnAdministrarVentas.UseVisualStyleBackColor = false;
            this.btnAdministrarVentas.Click += new System.EventHandler(this.btnAdministrarVentas_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.menu.Controls.Add(this.lblRol);
            this.menu.Location = new System.Drawing.Point(-1, -1);
            this.menu.Margin = new System.Windows.Forms.Padding(4);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1048, 95);
            this.menu.TabIndex = 5;
            // 
            // btnAdministrarProductos
            // 
            this.btnAdministrarProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnAdministrarProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdministrarProductos.FlatAppearance.BorderSize = 0;
            this.btnAdministrarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrarProductos.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrarProductos.ForeColor = System.Drawing.Color.White;
            this.btnAdministrarProductos.Location = new System.Drawing.Point(660, 195);
            this.btnAdministrarProductos.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdministrarProductos.Name = "btnAdministrarProductos";
            this.btnAdministrarProductos.Size = new System.Drawing.Size(200, 60);
            this.btnAdministrarProductos.TabIndex = 1;
            this.btnAdministrarProductos.Text = "Gestion de Productos";
            this.btnAdministrarProductos.UseVisualStyleBackColor = false;
            this.btnAdministrarProductos.Click += new System.EventHandler(this.btnAdministrarProductos_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(819, 464);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 43);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cerrar Sesion";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FrmPrincipalVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1043, 558);
            this.Controls.Add(this.btnAdministrarProductos);
            this.Controls.Add(this.btnAdministrarVentas);
            this.Controls.Add(this.btnAdministrarClientes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipalVendedor";
            this.Text = "Distribuidora Hardware - Vendedor";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Button btnAdministrarProductos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAdministrarClientes;
        private System.Windows.Forms.Button btnAdministrarVentas;
    }
}