using DistribuidoraElectronicaStock.BBL;
using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmGestionClientes : Form
    {
        // gestor de la capa BBL que maneja la lógica de clientes
        private GestorClientes _gestorClientes;

        // lista que guarda los clientes que se muestran en la tabla
        private List<Cliente> _clientes;

        public FrmGestionClientes()
        {
            InitializeComponent();
            ConfigurarFormulario();

            // instancio el gestor para poder llamar sus métodos
            _gestorClientes = new GestorClientes();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Distribuidora Hardware - Vendedor";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // muestro el rol del usuario que inició sesión
            var usuario = GestorSesion.RecuperarInstancia().UsuarioActual;
            lblRol.Text = $"Perfil: {usuario.Rol.Nombre}";
        }

        private void FrmGestionClientes_Load(object sender, EventArgs e)
        {
            // cuando abre el formulario configuro la tabla y cargo los clientes
            ConfigurarGrilla();
            CargarClientes();
        }

        private void ConfigurarGrilla()
        {
            // limpio columnas por si ya había algo
            dgvClientes.Columns.Clear();

            // desactivo la generación automática de columnas
            // para controlar exactamente qué se muestra
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.ReadOnly = true;

            // cuando el usuario hace clic se selecciona la fila completa
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // agrego las columnas manualmente
            // DataPropertyName vincula la columna con la propiedad del objeto Cliente
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "ID",
                DataPropertyName = "IdCliente",
                Width = 50
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "CUIT",
                DataPropertyName = "Cuit",
                Width = 150
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Razón Social",
                DataPropertyName = "RazonSocial",
                Width = 200
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 180
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 120
            });
        }

        private void CargarClientes()
        {
            try
            {
                // le pido al gestor la lista de clientes activos
                _clientes = _gestorClientes.ObtenerClientes();

                // reseteo el DataSource para forzar que se actualice la tabla
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = _clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Cliente ObtenerClienteSeleccionado()
        {
            // verifico que haya una fila seleccionada en la tabla
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un cliente de la tabla.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // obtengo el objeto Cliente que está vinculado a la fila seleccionada
            // DataBoundItem devuelve el objeto original de la lista
            return dgvClientes.SelectedRows[0].DataBoundItem as Cliente;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // busco por lo que escribió en el TextBox
                // si está vacío el gestor devuelve todos los clientes
                _clientes = _gestorClientes.BuscarCliente(txtBuscar.Text.Trim());
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = _clientes;

                if (_clientes.Count == 0)
                    MessageBox.Show("No se encontraron clientes.",
                        "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            // abro FrmAgregarCliente sin pasar cliente — modo agregar
            FrmAgregarCliente frm = new FrmAgregarCliente();

            // si el usuario guardó exitosamente recargo la tabla
            if (frm.ShowDialog() == DialogResult.OK)
                CargarClientes();
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            // verifico que haya un cliente seleccionado en la tabla
            Cliente clienteSeleccionado = ObtenerClienteSeleccionado();
            if (clienteSeleccionado == null) return;

            // abro FrmAgregarCliente pasando el cliente — modo editar
            // el formulario detecta que viene un cliente y carga sus datos
            FrmAgregarCliente frm = new FrmAgregarCliente(clienteSeleccionado);

            // si el usuario guardó exitosamente recargo la tabla
            if (frm.ShowDialog() == DialogResult.OK)
                CargarClientes();
        }

        private void btnDesactivarCliente_Click(object sender, EventArgs e)
        {
            // verifico que haya un cliente seleccionado
            Cliente clienteSeleccionado = ObtenerClienteSeleccionado();
            if (clienteSeleccionado == null) return;

            // pido confirmación antes de desactivar
            DialogResult confirmacion = MessageBox.Show(
                $"¿Desactivar al cliente {clienteSeleccionado.RazonSocial}?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // llamo al gestor con el id del cliente seleccionado
                    int resultado = _gestorClientes.DesactivarCliente(clienteSeleccionado.IdCliente);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Cliente desactivado correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // recargo la tabla — el cliente desactivado ya no aparece
                        CargarClientes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo desactivar el cliente.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // cierro el formulario
            Close();
        }
    }
}