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
    public partial class FrmGenerarOrdenCompra : Form
    {
        private readonly GestorOrdenCompra _gestorOC;
        private readonly GestorProveedores _gestorProv;
        private readonly GestorProductos _gestorProd;
        private readonly List<OrdenCompraDetalle> _detalle;
        public FrmGenerarOrdenCompra()
        {
            InitializeComponent();

            _gestorOC = new GestorOrdenCompra();
            _gestorProv = new GestorProveedores();
            _gestorProd = new GestorProductos();
            _detalle = new List<OrdenCompraDetalle>();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmGenerarOrdenCompra_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarProveedores();
            CargarProductos();
            dtpFechaEmision.Value = DateTime.Today;
        }
        private void ConfigurarGrilla()
        {
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDetalle.Columns.Add("colCodigo", "Código");
            dgvDetalle.Columns.Add("colProducto", "Producto");
            dgvDetalle.Columns.Add("colCantidad", "Cantidad");
            dgvDetalle.Columns.Add("colPrecioUnit", "Precio Unit.");
            dgvDetalle.Columns.Add("colSubtotal", "Subtotal");
        }

        private void CargarProveedores()
        {
            var proveedores = _gestorProv.ObtenerProveedores();

            if (proveedores.Count == 0)
            {
                MessageBox.Show("No hay proveedores activos","Sin proveedores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnConfirmar.Enabled = false;
                return;
            }

            cmbProveedores.DataSource = proveedores;
            cmbProveedores.DisplayMember = "RazonSocial";
            cmbProveedores.ValueMember = "IdProveedor";
        }

        private void CargarProductos()
        {
            var productos = _gestorProd.ObtenerTodos();

            if (productos.Count == 0)
            {
                MessageBox.Show("No hay productos activos disponibles.",
                    "Sin productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cmbProductos.DataSource = productos;
            cmbProductos.DisplayMember = "Nombre";
            cmbProductos.ValueMember = "IdProducto";
        }

        // ── Precarga el precio de compra al seleccionar producto ──
        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem is Producto producto)
                txtPrecioUnitario.Text = producto.PrecioCompra.ToString("F2");
        }

        //Agregar producto al detalle
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrecioUnitario.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingrese un precio unitario válido mayor a 0.",
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var producto = cmbProductos.SelectedItem as Producto;
            int cantidad = (int)numCantidad.Value;
            decimal subtotal = precio * cantidad;

            // Verificar duplicados
            if (_detalle.Exists(d => d.Producto.IdProducto == producto.IdProducto))
            {
                MessageBox.Show($"'{producto.Nombre}' ya está en el detalle.\n" +
                    "Quitalo y volvé a agregarlo si querés modificar la cantidad.",
                    "Producto duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var detalle = new OrdenCompraDetalle(0, 0, producto, cantidad, precio);
            _detalle.Add(detalle);

            dgvDetalle.Rows.Add(
                producto.Codigo,
                producto.Nombre,
                cantidad,
                precio.ToString("C2"),
                subtotal.ToString("C2")
            );

            ActualizarTotal();
            numCantidad.Value = 1;
        }

        //Quitar producto del detalle
        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para quitar.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idx = dgvDetalle.SelectedRows[0].Index;
            _detalle.RemoveAt(idx);
            dgvDetalle.Rows.RemoveAt(idx);
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            decimal total = 0;
            foreach (var d in _detalle)
                total += d.Subtotal;
            lblTotal.Text = $"Total: {total:C2}";
        }

        // ── Confirmar orden ───────────────────────────────────────
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbProveedores.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un proveedor.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_detalle.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la orden.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Confirma la generación de la orden de compra?",
                "Confirmar orden", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            var proveedor = cmbProveedores.SelectedItem as Proveedor;
            var usuario = GestorSesion.RecuperarInstancia().UsuarioActual;
            decimal total = 0;
            foreach (var d in _detalle) total += d.Subtotal;

            var orden = new OrdenCompra(
                0,
                proveedor,
                usuario,
                total,
                dtpFechaEmision.Value.Date,
                null,
                EstadoOrdenCompra.Pendiente
            );

            orden.Detalle = _detalle;

            bool ok = _gestorOC.GenerarOrden(orden);

            if (ok)
            {
                MessageBox.Show(
                    $"Orden de compra generada exitosamente.\n" +
                    $"Proveedor: {proveedor.RazonSocial}\n" +
                    $"Total: {total:C2}",
                    "Orden generada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al generar la orden. Intentá nuevamente.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
