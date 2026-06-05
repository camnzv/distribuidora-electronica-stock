using DistribuidoraElectronicaStock.BBL;
using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Windows.Forms;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmAgregarCliente : Form
    {
        private GestorClientes _gestorClientes;
        private Cliente _clienteAEditar;

        // edicion: si viene un cliente lo edita, si no agrega uno nuevo
        public FrmAgregarCliente(Cliente clienteAEditar = null)
        {
            InitializeComponent();
            _gestorClientes = new GestorClientes();
            _clienteAEditar = clienteAEditar;
        }

        private void FrmAgregarCliente_Load(object sender, EventArgs e)
        {
            if (_clienteAEditar != null)
            {
                // edicion — cargo los datos del cliente
                this.Text = "Editar Cliente";
                txtCuit.Text = _clienteAEditar.Cuit;
                txtRazonSocial.Text = _clienteAEditar.RazonSocial;
                txtEmail.Text = _clienteAEditar.Email;
                txtTelefono.Text = _clienteAEditar.Telefono;
            }
            else
            {
                this.Text = "Agregar Cliente";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_clienteAEditar != null)
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
            Cliente nuevoCliente = new Cliente(
                0,
                txtCuit.Text.Trim(),
                txtRazonSocial.Text.Trim(),
                txtEmail.Text.Trim(),
                txtTelefono.Text.Trim(),
                true
            );

            int resultado = _gestorClientes.AgregarCliente(nuevoCliente);

            if (resultado == -1)
            {
                MessageBox.Show("CUIT y Razón Social son obligatorios.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (resultado > 0)
            {
                MessageBox.Show("Cliente agregado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el cliente.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Editar()
        {
            _clienteAEditar.Cuit = txtCuit.Text.Trim();
            _clienteAEditar.RazonSocial = txtRazonSocial.Text.Trim();
            _clienteAEditar.Email = txtEmail.Text.Trim();
            _clienteAEditar.Telefono = txtTelefono.Text.Trim();

            int resultado = _gestorClientes.EditarCliente(_clienteAEditar);

            if (resultado == -1)
            {
                MessageBox.Show("CUIT y Razón Social son obligatorios.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (resultado > 0)
            {
                MessageBox.Show("Cliente editado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo editar el cliente.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
