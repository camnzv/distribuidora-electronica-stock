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

            AplicarPermisos();

            dgvProductos.SelectionChanged += (s, e) =>
            {
                bool haySeleccion = dgvProductos.SelectedRows.Count > 0;
                var permisos = GestorSesion.RecuperarInstancia().PermisosActuales;

                btnEditar.Enabled =
                    haySeleccion && permisos.TienePermiso("EditarProducto");

                btnEliminar.Enabled =
                    haySeleccion && permisos.TienePermiso("EliminarProducto");
            };


            this.Load += (s, e) =>
            {
                txtNombre.Focus();
                CargarProductos();
            };


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




        private void AplicarPermisos()
        {
            var permisos = GestorSesion.RecuperarInstancia().PermisosActuales;

            btnAgregarProducto.Visible = permisos.TienePermiso("AgregarProducto");

            // Si no tiene el permiso no se muestran los botones 
            btnEditar.Visible = permisos.TienePermiso("EditarProducto");
            btnEliminar.Visible = permisos.TienePermiso("EliminarProducto");

            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["id_producto"].Value);
            Producto producto = _productos.Find(p => p.IdProducto == id);

            var confirmar = MessageBox.Show(
                $"¿Está seguro que desea eliminar {producto.Nombre}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    bool eliminado = new GestorProductos().EliminarProducto(id);

                    if (eliminado)
                    {
                        MessageBox.Show(
                            "Producto eliminado correctamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        CargarProductos();
                    }
                    else
                    {
                        MessageBox.Show(
                            "No se pudo eliminar el producto.",
                            "Atención",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error al eliminar el producto:\n{ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            var frm = new FrmAgregarProducto();
            frm.FormClosed += (s, args) => CargarProductos();
            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["id_producto"].Value);
            Producto producto = _productos.Find(p => p.IdProducto == id);

            var frm = new FrmAgregarProducto(producto); 
            frm.FormClosed += (s, args) => CargarProductos();
            frm.ShowDialog();
        }
    }
}

