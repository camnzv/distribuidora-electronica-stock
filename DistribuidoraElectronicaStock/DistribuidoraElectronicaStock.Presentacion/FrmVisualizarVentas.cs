using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DistribuidoraElectronicaStock.BBL;
using DistribuidoraElectronicaStock.Entidades;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmVisualizarVentas : Form
    {
        private GestorVentas _gestorVentas;

        // lista de ventas que se muestran en la tabla
        private List<Venta> _ventas;

        public FrmVisualizarVentas()
        {
            InitializeComponent();
            _gestorVentas = new GestorVentas();
        }

        private void FrmVisualizarVentas_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaVentas();
            ConfigurarGrillaDetalle();

            // oculto el detalle hasta que el usuario haga clic en una venta
            dgvDetalle.Visible = false;
            lblDetalle.Visible = false;
        }

        private void ConfigurarGrillaVentas()
        {
            dgvVentas.Columns.Clear();
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersVisible = false;

            // selecciona la fila completa al hacer clic
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // columna oculta para guardar el id de la venta
            dgvVentas.Columns.Add("id", "ID");
            dgvVentas.Columns["id"].Visible = false;

            dgvVentas.Columns.Add("fecha", "Fecha");
            dgvVentas.Columns.Add("cliente", "Cliente");
            dgvVentas.Columns.Add("usuario", "Vendedor");
            dgvVentas.Columns.Add("total", "Total");
        }

        private void ConfigurarGrillaDetalle()
        {
            dgvDetalle.Columns.Clear();
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;

            dgvDetalle.Columns.Add("producto", "Producto");
            dgvDetalle.Columns.Add("cantidad", "Cantidad");
            dgvDetalle.Columns.Add("precio", "Precio Unit.");
            dgvDetalle.Columns.Add("subtotal", "Subtotal");
        }

        private void btnBuscarVentas_Click(object sender, EventArgs e)
        {
            try
            {
                // verifico que haya algo escrito
                if (string.IsNullOrWhiteSpace(txtBuscarCliente.Text))
                {
                    MessageBox.Show("Ingresá el nombre o CUIT del cliente.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // busco las ventas del cliente
                _ventas = _gestorVentas.ObtenerVentasPorCliente(txtBuscarCliente.Text.Trim());

                dgvVentas.Rows.Clear();

                if (_ventas.Count == 0)
                {
                    MessageBox.Show("No se encontraron ventas para ese cliente.",
                        "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // cargo las ventas en la tabla
                foreach (Venta v in _ventas)
                {
                    dgvVentas.Rows.Add(
                        v.Id,
                        v.Fecha.ToString("dd/MM/yyyy"),
                        v.NombreCliente,
                        v.Usuario?.Nombre,
                        $"${v.MontoTotal:N2}"
                    );
                }

                // oculto el detalle hasta que elija una venta
                dgvDetalle.Visible = false;
                lblDetalle.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // verifico que sea una fila válida
            if (e.RowIndex < 0) return;

            try
            {
                // obtengo el id de la venta de la columna oculta
                int idVenta = System.Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["id"].Value);

                // pido el detalle de esa venta
                List<VentaDetalle> detalle = _gestorVentas.ObtenerDetalleVenta(idVenta);

                dgvDetalle.Rows.Clear();

                // cargo el detalle en la tabla
                foreach (VentaDetalle item in detalle)
                {
                    dgvDetalle.Rows.Add(
                        item.NombreProducto,
                        item.Cantidad,
                        $"${item.MontoUnitario:N2}",
                        $"${item.Subtotal:N2}"
                    );
                }

                // muestro la tabla de detalle recién cuando hay datos
                dgvDetalle.Visible = true;
                lblDetalle.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            // si el textbox queda vacío limpio las tablas
            if (string.IsNullOrWhiteSpace(txtBuscarCliente.Text))
            {
                dgvVentas.Rows.Clear();
                dgvDetalle.Rows.Clear();
                dgvDetalle.Visible = false;
                lblDetalle.Visible = false;
            }
        }
    }
}