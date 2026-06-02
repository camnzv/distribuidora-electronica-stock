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
    public partial class FrmEntradaStock : Form
    {
        private readonly GestorOrdenCompra _gestorOC;
        private OrdenCompra _ordenSeleccionada;
        public FrmEntradaStock()
        {
            InitializeComponent();
            _gestorOC = new GestorOrdenCompra();
            ConfigurarGrilla();
        }


        private void ConfigurarGrilla()
        {
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.MultiSelect = false;

            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCodigo",
                HeaderText = "Código",
                ReadOnly = true,
                Width = 100
            });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProducto",
                HeaderText = "Producto",
                ReadOnly = true,
                Width = 150
                //AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCantPedida",
                HeaderText = "Cant. Pedida",
                ReadOnly = true,
                Width = 100
            });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCantRecibida",
                HeaderText = "Cant. Recibida",
                ReadOnly = false,
                Width = 110 
            });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrecioUnitario",
                HeaderText = "Precio Unit.",
                ReadOnly = true,
                Width = 110
            });
        }

        private void FrmEntradaStock_Load(object sender, EventArgs e)
        {
            CargarOrdenesPendientes();
        }

        private void CargarOrdenesPendientes()
        {
            var ordenes = _gestorOC.ObtenerOrdenesPendientes();

            if (ordenes.Count == 0)
            {
                MessageBox.Show("No hay órdenes de compra pendientes de recepción.\n" +"Deberá generar una nueva orden de compra.","Sin órdenes pendientes",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnConfirmar.Enabled = false;
                return;
            }

            cmbOrdenes.DataSource = ordenes;
            cmbOrdenes.DisplayMember = "ToString";
            cmbOrdenes.ValueMember = "IdOrdenCompra";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblFechaEmision_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbOrdenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrdenes.SelectedItem is OrdenCompra orden)
            {
                _ordenSeleccionada = orden;
                MostrarDetalleOrden(orden);
            }
        }

        private void MostrarDetalleOrden(OrdenCompra orden)
        {
            lblProveedorValor.Text = orden.Proveedor.RazonSocial;
            lblFechaEmisionValor.Text = orden.FechaEmision.ToString("dd/MM/yyyy");
            lblEstadoValor.Text = orden.Estado.ToString();

            dgvDetalle.Rows.Clear();

            foreach (var detalle in orden.Detalle)
            {
                dgvDetalle.Rows.Add(
                    detalle.Producto.Codigo,
                    detalle.Producto.Nombre,
                    detalle.Cantidad,
                    detalle.Cantidad,
                    detalle.MontoUnitario.ToString("C2")
                );
            }

            btnConfirmar.Enabled = true;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_ordenSeleccionada == null)
            {
                MessageBox.Show("Seleccione una orden de compra.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ObtenerCantidadesIngresadas(out List<OrdenCompraDetalle> detalles))
                return;

            var confirmacion = MessageBox.Show(
                "¿Confirma el registro de la entrada de stock?",
                "Confirmar entrada",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            bool resultado = _gestorOC.RegistrarEntrada(_ordenSeleccionada, detalles);

            if (resultado)
            {
                MessageBox.Show(
                    "Entrada de stock registrada exitosamente.",
                    "Operación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Ocurrió un error al registrar la entrada. Revisá los datos ingresados.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ObtenerCantidadesIngresadas(out List<OrdenCompraDetalle> detallesActualizados)
        {
            detallesActualizados = new List<OrdenCompraDetalle>();

            for (int i = 0; i < dgvDetalle.Rows.Count; i++)
            {
                var detalle = _ordenSeleccionada.Detalle[i];
                string texto = dgvDetalle.Rows[i].Cells["colCantRecibida"].Value?.ToString();

                if (!int.TryParse(texto, out int cantRecibida))
                {
                    MessageBox.Show(
                        $"La cantidad ingresada para '{detalle.Producto.Nombre}' no es válida.\n" +
                        $"Ingresá solo números enteros.",
                        "Error de validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }

                if (cantRecibida < 0 || cantRecibida > detalle.Cantidad)
                {
                    MessageBox.Show(
                        $"La cantidad de '{detalle.Producto.Nombre}' debe estar " +
                        $"entre 0 y {detalle.Cantidad}.",
                        "Error de validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }

                detalle.CantidadRecibida = cantRecibida;
                detallesActualizados.Add(detalle);
            }

            return true;
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
