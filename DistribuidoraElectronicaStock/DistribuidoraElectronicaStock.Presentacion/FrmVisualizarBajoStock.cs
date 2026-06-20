using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DistribuidoraElectronicaStock.BBL;
using DistribuidoraElectronicaStock.Entidades;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmVisualizarBajoStock : Form
    {
        private readonly GestorProductos _gestorProductos;
        private readonly AlertaBajoStockLogger _logger;
        public FrmVisualizarBajoStock()
        {
            InitializeComponent();
            _gestorProductos = new GestorProductos();
            _logger = new AlertaBajoStockLogger();

            //Suscribe el logger como observador
            _gestorProductos.SuscribirObservador(_logger);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmVisualizarBajoStock_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarProductosBajoStock();
        }

        private void ConfigurarGrilla()
        {
            dgvBajoStock.AllowUserToAddRows = false;
            dgvBajoStock.AllowUserToDeleteRows = false;
            dgvBajoStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBajoStock.ReadOnly = true;
            dgvBajoStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBajoStock.Columns.Add("colCodigo", "Código");
            dgvBajoStock.Columns.Add("colNombre", "Producto");
            dgvBajoStock.Columns.Add("colCategoria", "Categoría");
            dgvBajoStock.Columns.Add("colStockActual", "Stock Actual");
            dgvBajoStock.Columns.Add("colStockMinimo", "Stock Mínimo");
            //dgvBajoStock.Columns.Add("colDiferencia", "Faltante");

            
            dgvBajoStock.Columns["colStockActual"].DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
            //dgvBajoStock.Columns["colDiferencia"].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
        }

        private void CargarProductosBajoStock()
        {
            dgvBajoStock.Rows.Clear();

            //Obtiene los productos Y notifica al logger
            var productos = _gestorProductos.ObtenerProductosBajoStock();

            if (productos.Count == 0)
            {
                lblInfo.Text = "Todos los productos tienen stock suficiente.";
                lblInfo.ForeColor = System.Drawing.Color.Green;
                return;
            }

            lblInfo.Text = $"Se encontraron {productos.Count} producto(s) con stock bajo el mínimo.";
            lblInfo.ForeColor = System.Drawing.Color.Red;

            foreach (var p in productos)
            {
                int faltante = p.StockMinimo - p.StockActual;
                dgvBajoStock.Rows.Add(
                    p.Codigo,
                    p.Nombre,
                    p.CategoriaProducto?.Categoria ?? "-",
                    p.StockActual,
                    p.StockMinimo
                );
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
