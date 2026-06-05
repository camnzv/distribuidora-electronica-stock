using DistribuidoraElectronicaStock.BBL;
using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmGestionProductos : Form
    {

        private List<Producto> _productos;
        public FrmGestionProductos()
        {
            InitializeComponent();
            ConfigurarFormulario();

        }

        private void ConfigurarFormulario()
        {
            this.Text = "Consulta de Productos";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

           
            txtNombre.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnBuscar_Click(s, e); };
            txtCodigo.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnBuscar_Click(s, e); };

            // Configurar DataGridView — solo lectura
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.BorderStyle = BorderStyle.None;

            // Estilo header
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.ColorTranslator.FromHtml("#2C3E50");
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            dgvProductos.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.ColorTranslator.FromHtml("#F2F3F4");

            // Cargar todos los productos al abrir
            CargarProductos();

            this.Load += (s, e) => txtNombre.Focus();
        }

        private void CargarProductos()
        {
            try
            {
                string nombre = string.IsNullOrEmpty(txtNombre.Text) ? null : txtNombre.Text.Trim();
                string codigo = string.IsNullOrEmpty(txtCodigo.Text) ? null : txtCodigo.Text.Trim();

                _productos = new GestorProductos().BuscarProductos(nombre, codigo, null, 1);

                dgvProductos.Rows.Clear();
                dgvProductos.Columns.Clear();

                // Columna oculta ID
                dgvProductos.Columns.Add("id_producto", "ID");
                dgvProductos.Columns["id_producto"].Visible = false;

                dgvProductos.Columns.Add("codigo", "Código");
                dgvProductos.Columns.Add("nombre", "Nombre");
                dgvProductos.Columns.Add("categoria", "Categoría");
                dgvProductos.Columns.Add("precio_venta", "Precio Venta");
                dgvProductos.Columns.Add("stock", "Stock");
                dgvProductos.Columns.Add("iva", "IVA %");

                foreach (Producto p in _productos)
                {
                    int indice = dgvProductos.Rows.Add(
                        p.IdProducto,
                        p.Codigo,
                        p.Nombre,
                        p.CategoriaProducto?.Categoria,
                        $"${p.PrecioVenta:N2}",
                        p.StockActual,
                        $"{p.Iva}%"
                    );

                    //si el stock es bajo
                    if (p.StockActual < p.StockMinimo)
                    {
                        dgvProductos.Rows[indice].DefaultCellStyle.ForeColor =
                            System.Drawing.Color.Red;
                        dgvProductos.Rows[indice].Cells["stock"].Style.Font =
                            new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
                    }
                }

                if (_productos.Count == 0)
                    MessageBox.Show("No se encontraron productos.", "Sin resultados",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

  

     

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            txtNombre.Clear();
            txtCodigo.Clear();
            CargarProductos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }



}

