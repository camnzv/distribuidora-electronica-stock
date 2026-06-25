using System;
using System.Windows.Forms;
using DistribuidoraElectronicaStock.Entidades;
using DistribuidoraElectronicaStock.BBL;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmConfirmarVenta : Form
    {
        // la venta que viene desde FrmRegistrarVenta
        private Venta _venta;
        private GestorVentas _gestorVentas;

        public FrmConfirmarVenta(Venta venta)
        {
            InitializeComponent();
            _venta = venta;
            _gestorVentas = new GestorVentas();
        }

        private void FrmConfirmarVenta_Load(object sender, EventArgs e)
        {
            // muestro los datos de la cabecera
            lblCliente.Text = "Cliente: " + _venta.NombreCliente;
            lblFecha.Text = "Fecha: " + _venta.Fecha.ToString("dd/MM/yyyy");
            lblTotal.Text = "Total: $" + _venta.Total.ToString("N2");

            ConfigurarGrilla();
            CargarDetalle();
        }

        private void ConfigurarGrilla()
        {
            dgvDetalle.Columns.Clear();
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvDetalle.Columns.Add("nombre", "Producto");
            dgvDetalle.Columns.Add("cantidad", "Cantidad");
            dgvDetalle.Columns.Add("precio", "Precio Unit.");
            dgvDetalle.Columns.Add("subtotal", "Subtotal");
        }

        private void CargarDetalle()
        {
            // recorro la lista de detalle que viene en el objeto Venta
            foreach (VentaDetalle item in _venta.Detalle)
            {
                dgvDetalle.Rows.Add(
                    item.NombreProducto,
                    item.Cantidad,
                    $"${item.MontoUnitario:N2}",
                    $"${item.Subtotal:N2}" // se calcula solo — cantidad * montoUnitario
                );
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = _gestorVentas.RegistrarVenta(_venta);

                if (resultado > 0)
                {
                    MessageBox.Show("Venta registrada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la venta.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // cierra sin guardar — vuelve a FrmRegistrarVenta
            this.Close();
        }
    }
}