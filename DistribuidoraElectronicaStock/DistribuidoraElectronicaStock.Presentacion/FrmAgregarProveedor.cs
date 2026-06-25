using DistribuidoraElectronicaStock.BBL;
using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Windows.Forms;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmAgregarProveedor : Form
    {
        private GestorProveedores _gestorProveedores;
        private Proveedor _proveedorAEditar;

        // si viene un proveedor lo edita, si no agrega uno nuevo
        public FrmAgregarProveedor(Proveedor proveedorAEditar = null)
        {
            InitializeComponent();
            _gestorProveedores = new GestorProveedores();
            _proveedorAEditar = proveedorAEditar;
        }

        private void FrmAgregarProveedor_Load_1(object sender, EventArgs e)
        {
            // cargo el combo de tipos de proveedor
            var tipos = _gestorProveedores.ObtenerTiposProveedor();
            cmbTipo.DataSource = tipos;
            cmbTipo.DisplayMember = "Tipo";
            cmbTipo.ValueMember = "IdProveedorTipo";

            if (_proveedorAEditar != null)
            {
                // cargo los datos del proveedor
                this.Text = "Editar Proveedor";
                label5.Text = "Editar proveedor";
                txtCuit.Text = _proveedorAEditar.Cuit;
                txtRazonSocial.Text = _proveedorAEditar.RazonSocial;
                txtEmail.Text = _proveedorAEditar.Email;
                txtTelefono.Text = _proveedorAEditar.Telefono;
                cmbTipo.SelectedValue = _proveedorAEditar.ProveedorTipo.IdProveedorTipo;
            }
            else
            {
                this.Text = "Agregar Proveedor";
                label5.Text = "Agregar un nuevo proveedor";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_proveedorAEditar != null)
                    Editar();
                else
                    Agregar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Agregar()
        {
            Proveedor nuevoProveedor = new Proveedor(
                0,
                cmbTipo.SelectedItem as ProveedorTipo,
                txtCuit.Text.Trim(),
                txtRazonSocial.Text.Trim(),
                txtEmail.Text.Trim(),
                txtTelefono.Text.Trim(),
                true
            );

            int resultado = _gestorProveedores.AgregarProveedor(nuevoProveedor);

            if (resultado == -1)
            {
                MessageBox.Show("CUIT, Razón Social y Tipo son obligatorios.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (resultado > 0)
            {
                MessageBox.Show("Proveedor agregado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el proveedor.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Editar()
        {
            _proveedorAEditar.ProveedorTipo = cmbTipo.SelectedItem as ProveedorTipo;
            _proveedorAEditar.Cuit = txtCuit.Text.Trim();
            _proveedorAEditar.RazonSocial = txtRazonSocial.Text.Trim();
            _proveedorAEditar.Email = txtEmail.Text.Trim();
            _proveedorAEditar.Telefono = txtTelefono.Text.Trim();

            int resultado = _gestorProveedores.EditarProveedor(_proveedorAEditar);

            if (resultado == -1)
            {
                MessageBox.Show("CUIT, Razón Social y Tipo son obligatorios.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (resultado > 0)
            {
                MessageBox.Show("Proveedor editado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo editar el proveedor.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}