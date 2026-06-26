using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DistribuidoraElectronicaStock.BBL;
using DistribuidoraElectronicaStock.Entidades;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmRegistrarVenta : Form
    {
        private GestorClientes _gestorClientes;
        private List<Cliente> _clientes;
        private Cliente _clienteSeleccionado;

        private GestorProductos _gestorProductos;
        private List<Producto> _productos;
        private Producto _productoSeleccionado;

        // lista que acumula los productos que el vendedor va agregando
        private List<VentaDetalle> _detalle = new List<VentaDetalle>();

        // total acumulado de la venta
        private decimal _total = 0;

        public FrmRegistrarVenta()
        {
            InitializeComponent();
            _gestorClientes = new GestorClientes();
            _gestorProductos = new GestorProductos();
        }

        private void FrmRegistarVenta_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
        }

        // ═══════════════════════════════════
        // SECCIÓN CLIENTES
        // ═══════════════════════════════════

        private void CargarClientes()
        {
            try
            {
                string busqueda = txtBuscarCliente.Text.Trim();
                _clientes = _gestorClientes.BuscarCliente(busqueda);

                dgvClientes.Rows.Clear();
                dgvClientes.Columns.Clear();

                dgvClientes.Columns.Add("id", "ID");
                dgvClientes.Columns["id"].Visible = false;
                dgvClientes.Columns.Add("razonSocial", "Razón Social");
                dgvClientes.Columns.Add("cuit", "CUIT");

                foreach (Cliente cliente in _clientes)
                {
                    dgvClientes.Rows.Add(
                        cliente.IdCliente,
                        cliente.RazonSocial,
                        cliente.Cuit
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }

        // cuando el vendedor hace clic en una fila de la tabla de clientes
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _clienteSeleccionado = _clientes[e.RowIndex];
            lblClienteSeleccionado.Text = "Cliente: " + _clienteSeleccionado.RazonSocial;

            // oculto la tabla una vez que eligió el cliente
            dgvClientes.Visible = false;
        }

        // ═══════════════════════════════════
        // SECCIÓN PRODUCTOS
        // ═══════════════════════════════════

        private void CargarProductos()
        {
            try
            {
                string busqueda = string.IsNullOrWhiteSpace(txtBuscarProducto.Text)
                    ? null
                    : txtBuscarProducto.Text.Trim();

                _productos = _gestorProductos.BuscarProductos(busqueda, null, null, 1);

                dgvProductos.Rows.Clear();
                dgvProductos.Columns.Clear();

                dgvProductos.Columns.Add("id_producto", "ID");
                dgvProductos.Columns["id_producto"].Visible = false;
                dgvProductos.Columns.Add("codigo", "Código");
                dgvProductos.Columns.Add("nombre", "Nombre");
                dgvProductos.Columns.Add("precio", "Precio");
                dgvProductos.Columns.Add("stock", "Stock");

                foreach (Producto p in _productos)
                {
                    dgvProductos.Rows.Add(
                        p.IdProducto,
                        p.Codigo,
                        p.Nombre,
                        $"${p.PrecioVenta:N2}",
                        p.StockActual
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos:\n{ex.Message}");
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        // cuando el vendedor hace clic en una fila de la tabla de productos
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _productoSeleccionado = _productos[e.RowIndex];
            lblProductoSeleccionado.Text = "Producto: " + _productoSeleccionado.Nombre;
        }

        // ═══════════════════════════════════
        // SECCIÓN AGREGAR PRODUCTO AL DETALLE
        // ═══════════════════════════════════

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
            {
                MessageBox.Show("Seleccioná un producto de la tabla.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Ingresá una cantidad.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número mayor a 0.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantidad > _productoSeleccionado.StockActual)
            {
                MessageBox.Show($"Stock insuficiente. Stock disponible: {_productoSeleccionado.StockActual}",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // creo el objeto VentaDetalle
            VentaDetalle detalle = new VentaDetalle(
                _productoSeleccionado.IdProducto,
                _productoSeleccionado.Nombre,
                cantidad,
                _productoSeleccionado.PrecioVenta
            );

            // lo agrego a la lista
            _detalle.Add(detalle);

            // actualizo el total
            _total += detalle.Subtotal;

            // limpio para el próximo producto
            txtCantidad.Text = "";
            lblProductoSeleccionado.Text = "Producto: -";
            _productoSeleccionado = null;

            MessageBox.Show($"Producto agregado. Total acumulado: ${_total:N2}",
                "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ═══════════════════════════════════
        // SECCIÓN CONFIRMAR VENTA
        // ═══════════════════════════════════

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccioná un cliente.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_detalle.Count == 0)
            {
                MessageBox.Show("Agregá al menos un producto.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // armo el objeto Venta completo
            Venta venta = new Venta();
            venta.ClienteId = _clienteSeleccionado.IdCliente;
            venta.NombreCliente = _clienteSeleccionado.RazonSocial;
            venta.Fecha = dtpFecha.Value;
            venta.MontoTotal = _total;
            venta.Detalle = _detalle;

            // tomamos el usuario de la sesión activa
            venta.Usuario = GestorSesion.RecuperarInstancia().UsuarioActual;

            // abro FrmConfirmarVenta pasando la venta
            FrmConfirmarVenta frm = new FrmConfirmarVenta(venta);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            _clienteSeleccionado = null;
            _productoSeleccionado = null;
            _detalle = new List<VentaDetalle>();
            _total = 0;
            lblClienteSeleccionado.Text = "Cliente: -";
            lblProductoSeleccionado.Text = "Producto: -";
            dgvClientes.Rows.Clear();
            dgvClientes.Visible = true;
            dgvProductos.Rows.Clear();
            txtBuscarCliente.Text = "";
            txtBuscarProducto.Text = "";
            txtCantidad.Text = "";
        }
    }
}