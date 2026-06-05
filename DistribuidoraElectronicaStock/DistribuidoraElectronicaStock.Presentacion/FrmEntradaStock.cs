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
        private OrdenCompra _ordenPendienteSeleccionada;
        private OrdenCompra _ordenParcialSeleccionada;

        public FrmEntradaStock()
        {
            InitializeComponent();
            _gestorOC = new GestorOrdenCompra();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Registrar Entrada de Stock";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigurarGrillaPendientes();
            ConfigurarGrillaParciales();
        }

        private void FrmEntradaStock_Load(object sender, EventArgs e)
        {
            CargarOrdenesPendientes();
            CargarOrdenesParciales();
        }

       
        //TAB 1 — ÓRDENES PENDIENTEs
        private void ConfigurarGrillaPendientes()
        {
            dgvPendientes.AllowUserToAddRows = false;
            dgvPendientes.AllowUserToDeleteRows = false;
            dgvPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendientes.MultiSelect = false;

            dgvPendientes.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colCodigo", HeaderText = "Código", ReadOnly = true, Width = 100 });
            dgvPendientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProducto",
                HeaderText = "Producto",
                ReadOnly = true,
                Width = 120
            });
            dgvPendientes.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colCategoria", HeaderText = "Categoría", ReadOnly = true, Width = 100 });
            dgvPendientes.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colCantPedida", HeaderText = "Cant. Pedida", ReadOnly = true, Width = 100 });
            dgvPendientes.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colCantRecibida", HeaderText = "Cant. Recibida", ReadOnly = false, Width = 100 });
            dgvPendientes.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colPrecioUnit", HeaderText = "Precio Unit.", ReadOnly = true, Width = 100 });

            dgvPendientes.Columns["colCantRecibida"].DefaultCellStyle.BackColor =
                System.Drawing.Color.LightYellow;
        }

        private void CargarOrdenesPendientes()
        {
            cmbOrdenesPendientes.DataSource = null;
            dgvPendientes.Rows.Clear();

            var ordenes = _gestorOC.ObtenerOrdenesPendientes();

            if (ordenes.Count == 0)
            {
                lblSinPendientes.Visible = true;
                cmbOrdenesPendientes.Enabled = false;
                btnConfirmarP.Enabled = false;
                return;
            }

            lblSinPendientes.Visible = false;
            cmbOrdenesPendientes.Enabled = true;
            btnConfirmarP.Enabled = true;
            cmbOrdenesPendientes.DataSource = ordenes;
            cmbOrdenesPendientes.DisplayMember = "ToString";
            cmbOrdenesPendientes.ValueMember = "IdOrdenCompra";
        }

        private void cmbOrdenesPendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrdenesPendientes.SelectedItem is OrdenCompra orden)
            {
                _ordenPendienteSeleccionada = orden;
                MostrarDatosOrden(orden, lblProvValorP, lblFechaValorP, lblEstadoValorP);
                CargarDetalleEnGrillaPendientes(orden);
            }
        }

        private void CargarDetalleEnGrillaPendientes(OrdenCompra orden)
        {
            dgvPendientes.Rows.Clear();
            foreach (var detalle in orden.Detalle)
            {
                dgvPendientes.Rows.Add(
                    detalle.Producto.Codigo,
                    detalle.Producto.Nombre,
                    detalle.Producto.CategoriaProducto?.Categoria ?? "-",
                    detalle.Cantidad,
                    detalle.Cantidad,   // default = cant. pedida
                    detalle.MontoUnitario.ToString("C2")
                );
            }
        }

        private void btnConfirmarP_Click(object sender, EventArgs e)
        {
            if (_ordenPendienteSeleccionada == null)
            {
                MessageBox.Show("Seleccione una orden de compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ObtenerYValidarCantidadesPendientes(out var detalles)) return;

            if (MessageBox.Show("¿Confirma el registro de la entrada de stock?", "Confirmar entrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) 
                return;

            bool ok = _gestorOC.RegistrarEntrada(_ordenPendienteSeleccionada, detalles);

            if (ok)
            {
                MessageBox.Show("Entrada de stock registrada exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarOrdenesPendientes();
                CargarOrdenesParciales();
            }
            else
            {
                MessageBox.Show("Error al registrar la entrada. Revisá los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarOrdenesPendientes();
                CargarOrdenesParciales();
            }
            this.Close();
        }

        private bool ObtenerYValidarCantidadesPendientes(out List<OrdenCompraDetalle> resultado)
        {
            resultado = new List<OrdenCompraDetalle>();

            for (int i = 0; i < dgvPendientes.Rows.Count; i++)
            {
                var detalle = _ordenPendienteSeleccionada.Detalle[i];
                string texto = dgvPendientes.Rows[i].Cells["colCantRecibida"].Value?.ToString();

                if (!int.TryParse(texto, out int cant))
                {
                    MostrarErrorValidacion(detalle.Producto.Nombre, "El valor ingresado no es un número válido.");
                    return false;
                }
                if (cant < 0 || cant > detalle.Cantidad)
                {
                    MostrarErrorValidacion(detalle.Producto.Nombre, $"La cantidad debe estar entre 0 y {detalle.Cantidad}.");
                    return false;
                }
                detalle.CantidadRecibida = cant;
                resultado.Add(detalle);
            }

            if (resultado.TrueForAll(d => d.CantidadRecibida == 0))
            {
                MessageBox.Show("Debe ingresar al menos una cantidad mayor a 0.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }



        // TAB 2 — RECEPCIONES PARCIALES

        private void ConfigurarGrillaParciales()
        {
            dgvParciales.AllowUserToAddRows = false;
            dgvParciales.AllowUserToDeleteRows = false;
            dgvParciales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParciales.MultiSelect = false;

            dgvParciales.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colCodigoP", HeaderText = "Código", ReadOnly = true, Width = 100 });
            dgvParciales.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProductoP",
                HeaderText = "Producto",
                ReadOnly = true,
                Width = 120
            });
            dgvParciales.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colCategoriaP", HeaderText = "Categoría", ReadOnly = true, Width = 110 });
            dgvParciales.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colPedidoP", HeaderText = "Cant. Pedida", ReadOnly = true, Width = 90 });
            dgvParciales.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colYaRecibP", HeaderText = "Ya recibida", ReadOnly = true, Width = 90 });
            dgvParciales.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colARecibirP", HeaderText = "A recibir ahora", ReadOnly = false, Width = 120 });

            dgvParciales.Columns["colARecibirP"].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            dgvParciales.Columns["colYaRecibP"].DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void CargarOrdenesParciales()
        {
            cmbOrdenesParciales.DataSource = null;
            dgvParciales.Rows.Clear();

            var ordenes = _gestorOC.ObtenerOrdenesParciales();

            if (ordenes.Count == 0)
            {
                lblSinParciales.Visible = true;
                cmbOrdenesParciales.Enabled = false;
                btnConfirmarParcial.Enabled = false;
                return;
            }

            lblSinParciales.Visible = false;
            cmbOrdenesParciales.Enabled = true;
            btnConfirmarParcial.Enabled = true;
            cmbOrdenesParciales.DataSource = ordenes;
            cmbOrdenesParciales.DisplayMember = "ToString";
            cmbOrdenesParciales.ValueMember = "IdOrdenCompra";
        }

        private void cmbOrdenesParciales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrdenesParciales.SelectedItem is OrdenCompra orden)
            {
                _ordenParcialSeleccionada = orden;
                MostrarDatosOrden(orden, lblProvValorParcial, lblFechaValorParcial, lblEstadoValorParcial);
                CargarDetalleEnGrillaParciales(orden);
            }
        }

        private void CargarDetalleEnGrillaParciales(OrdenCompra orden)
        {
            dgvParciales.Rows.Clear();

            // Solo productos con unidades pendientes
            foreach (var detalle in orden.Detalle)
            {
                if (detalle.CantidadRecibida < detalle.Cantidad)
                {
                    int faltante = detalle.Cantidad - detalle.CantidadRecibida;
                    dgvParciales.Rows.Add(
                        detalle.Producto.Codigo,
                        detalle.Producto.Nombre,
                        detalle.Producto.CategoriaProducto?.Categoria ?? "-",
                        detalle.Cantidad,
                        detalle.CantidadRecibida,
                        faltante    // default = todo lo que falta
                    );
                }
            }
        }

        private void btnConfirmarParcial_Click(object sender, EventArgs e)
        {
            if (_ordenParcialSeleccionada == null)
            {
                MessageBox.Show("Seleccione una orden de compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ObtenerYValidarCantidadesParciales(out var detalles)) return;

            if (MessageBox.Show("¿Confirma el registro de la recepción parcial?", "Confirmar recepción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) 
                return;

            bool ok = _gestorOC.RegistrarEntrada(_ordenParcialSeleccionada, detalles, esParcial: true);

            if (ok)
            {
                MessageBox.Show("Recepción registrada exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarOrdenesPendientes();
                CargarOrdenesParciales();
            }
            else
            {
                MessageBox.Show("Error al registrar la recepción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarOrdenesPendientes();
                CargarOrdenesParciales();
            }
            this.Close();
        }

        private bool ObtenerYValidarCantidadesParciales(out List<OrdenCompraDetalle> resultado)
        {
            resultado = new List<OrdenCompraDetalle>();

            // Solo los detalles pendientes (los que están en la grilla)
            var detallesPendientes = _ordenParcialSeleccionada.Detalle.FindAll(d => d.CantidadRecibida < d.Cantidad);

            for (int i = 0; i < dgvParciales.Rows.Count; i++)
            {
                var detalle = detallesPendientes[i];
                int faltante = detalle.Cantidad - detalle.CantidadRecibida;
                string texto = dgvParciales.Rows[i].Cells["colARecibirP"].Value?.ToString();

                if (!int.TryParse(texto, out int cant))
                {
                    MostrarErrorValidacion(detalle.Producto.Nombre, "El valor ingresado no es un número válido.");
                    return false;
                }
                if (cant < 0 || cant > faltante)
                {
                    MostrarErrorValidacion(detalle.Producto.Nombre, $"Solo quedan {faltante} unidades pendientes de recepción.");
                    return false;
                }

                detalle.CantidadRecibida = cant;   // delta a sumar en BD
                resultado.Add(detalle);
            }

            if (resultado.TrueForAll(d => d.CantidadRecibida == 0))
            {
                MessageBox.Show("Debe ingresar al menos una cantidad mayor a 0.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        

        private void MostrarDatosOrden(OrdenCompra orden,
            Label lblProv, Label lblFecha, Label lblEstado)
        {
            lblProv.Text = orden.Proveedor.RazonSocial;
            lblFecha.Text = orden.FechaEmision.ToString("dd/MM/yyyy");
            lblEstado.Text = orden.Estado.ToString();
        }

        private void MostrarErrorValidacion(string producto, string mensaje)
        {
            MessageBox.Show($"Error en '{producto}':\n{mensaje}", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPendientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabParciales_Click(object sender, EventArgs e)
        {

        }

        private void grpDatosP_Enter(object sender, EventArgs e)
        {

        }
    }
}
