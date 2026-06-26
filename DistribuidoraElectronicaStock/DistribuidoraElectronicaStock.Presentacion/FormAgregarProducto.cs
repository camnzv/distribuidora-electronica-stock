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

    public partial class 
        FrmAgregarProducto : Form
    {
        private Producto _productoEditar; 
        private bool _esEdicion;

        //  para agregar 
        public FrmAgregarProducto()
        {
            InitializeComponent();
            _esEdicion = false;
            ConfigurarFormulario();
        }

        // para editar
        public FrmAgregarProducto(Producto producto)
        {
            InitializeComponent();
            _productoEditar = producto;
            _esEdicion = true;
            ConfigurarFormulario();
            CargarDatosProducto();
        }

        private void ConfigurarFormulario()
        {
            this.Text = _esEdicion ? "Editar Producto" : "Agregar Producto";
            lblTitulo.Text = _esEdicion
              ? "Editar Producto"
              : "Agregar Producto";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Solo numeros 
            txtPrecioCompra.KeyPress += SoloDecimales;
            txtPrecioVenta.KeyPress += SoloDecimales;
            txtIva.KeyPress += SoloDecimales;
            txtStockActual.KeyPress += SoloEnteros;
            txtStockMinimo.KeyPress += SoloEnteros;

            CargarCategorias();

            this.Load += (s, e) => txtNombre.Focus();
        }

        private void SoloDecimales(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
                e.Handled = true;
        }

        private void SoloEnteros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void CargarCategorias()
        {
            try
            {
                cmbCategoria.Items.Clear();
                List<CategoriaProducto> categorias = new GestorCategorias().RecuperarTodas();

                foreach (var c in categorias)
                    cmbCategoria.Items.Add(c);

                cmbCategoria.DisplayMember = "Categoria";

                if (cmbCategoria.Items.Count > 0)
                    cmbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosProducto()
        {
            txtNombre.Text = _productoEditar.Nombre;
            txtCodigo.Text = _productoEditar.Codigo;
            txtPrecioCompra.Text = _productoEditar.PrecioCompra.ToString();
            txtPrecioVenta.Text = _productoEditar.PrecioVenta.ToString();
            txtIva.Text = _productoEditar.Iva.ToString();
            txtStockActual.Text = _productoEditar.StockActual.ToString();
            txtStockMinimo.Text = _productoEditar.StockMinimo.ToString();

            foreach (CategoriaProducto c in cmbCategoria.Items)
            {
                if (c.IdCategoriaProducto == _productoEditar.CategoriaProducto.IdCategoriaProducto)
                {
                    cmbCategoria.SelectedItem = c;
                    break;
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código es obligatorio.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecioCompra.Text) ||
                !decimal.TryParse(txtPrecioCompra.Text, out _))
            {
                MessageBox.Show("Ingrese un precio de compra válido.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioCompra.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecioVenta.Text) ||
                !decimal.TryParse(txtPrecioVenta.Text, out _))
            {
                MessageBox.Show("Ingrese un precio de venta válido.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioVenta.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStockActual.Text) ||
                !int.TryParse(txtStockActual.Text, out _))
            {
                MessageBox.Show("Ingrese un stock actual válido.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockActual.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStockMinimo.Text) ||
                !int.TryParse(txtStockMinimo.Text, out _))
            {
                MessageBox.Show("Ingrese un stock mínimo válido.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockMinimo.Focus();
                return false;
            }

            if (cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una categoría.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!ValidarCampos()) return;

            CategoriaProducto categoriaSeleccionada = (CategoriaProducto)cmbCategoria.SelectedItem;

            try
            {
                GestorProductos gestor = new GestorProductos();
                bool resultado;

                if (_esEdicion)
                {

                    _productoEditar.Nombre = txtNombre.Text.Trim();
                    _productoEditar.Codigo = txtCodigo.Text.Trim();
                    _productoEditar.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);
                    _productoEditar.PrecioVenta = decimal.Parse(txtPrecioVenta.Text);
                    _productoEditar.Iva = float.Parse(txtIva.Text);
                    _productoEditar.StockActual = int.Parse(txtStockActual.Text);
                    _productoEditar.StockMinimo = int.Parse(txtStockMinimo.Text);
                    _productoEditar.CategoriaProducto = categoriaSeleccionada;

                    resultado = gestor.EditarProducto(_productoEditar);
                }
                else
                {
                    // nuevo producto
                    Producto nuevoProducto = new Producto
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Codigo = txtCodigo.Text.Trim(),
                        PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                        PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                        Iva = float.Parse(txtIva.Text),
                        StockActual = int.Parse(txtStockActual.Text),
                        StockMinimo = int.Parse(txtStockMinimo.Text),
                        Activo = true,
                        CategoriaProducto = categoriaSeleccionada
                    };

                    resultado = gestor.AgregarProducto(nuevoProducto);
                }

                if (resultado)
                {
                    string mensaje = _esEdicion ? "Producto actualizado correctamente." : "Producto agregado correctamente.";
                    MessageBox.Show(mensaje, "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el producto.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
