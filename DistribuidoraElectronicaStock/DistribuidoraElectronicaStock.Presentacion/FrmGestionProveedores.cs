using DistribuidoraElectronicaStock.BBL;
using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmGestionProveedores : Form
    {
        // gestor de la capa BBL que maneja la lógica de proveedores
        private GestorProveedores _gestorProveedores;

        // lista que guarda los proveedores que se muestran en la tabla
        private List<Proveedor> _proveedores;

        public FrmGestionProveedores()
        {
            InitializeComponent();
            ConfigurarFormulario();

            // instancio el gestor para poder llamar sus métodos
            _gestorProveedores = new GestorProveedores();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Distribuidora Hardware - Encargado de Inventario";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // muestro el rol del usuario que inició sesión
            var usuario = GestorSesion.RecuperarInstancia().UsuarioActual;
            lblRol.Text = $"Perfil: {usuario.Rol.Nombre}";
        }

        private void FrmGestionProveedores_Load(object sender, EventArgs e)
        {
            // cuando abre el formulario configuro la tabla y cargo los proveedores
            ConfigurarGrilla();
            CargarProveedores();
        }

        private void ConfigurarGrilla()
        {
            // limpio columnas por si ya había algo
            dgvProveedores.Columns.Clear();

            // desactivo la generación automática de columnas
            // para controlar exactamente qué se muestra
            dgvProveedores.AutoGenerateColumns = false;
            dgvProveedores.RowHeadersVisible = false;
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.ReadOnly = true;

            // cuando el usuario hace clic se selecciona la fila completa
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // agrego las columnas manualmente
            // DataPropertyName vincula la columna con la propiedad del objeto Proveedor
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "ID",
                DataPropertyName = "IdProveedor",
                Width = 50
            });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Tipo",
                DataPropertyName = "ProveedorTipo",
                Width = 120
            });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "CUIT",
                DataPropertyName = "Cuit",
                Width = 150
            });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Razón Social",
                DataPropertyName = "RazonSocial",
                Width = 200
            });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 180
            });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 120
            });
        }

        private void CargarProveedores()
        {
            try
            {
                // le pido al gestor la lista de proveedores activos
                _proveedores = _gestorProveedores.ObtenerProveedores();

                // reseteo el DataSource para forzar que se actualice la tabla
                dgvProveedores.DataSource = null;
                dgvProveedores.DataSource = _proveedores;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Proveedor ObtenerProveedorSeleccionado()
        {
            // verifico que haya una fila seleccionada en la tabla
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un proveedor de la tabla.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // obtengo el objeto Proveedor que está vinculado a la fila seleccionada
            // DataBoundItem devuelve el objeto original de la lista
            return dgvProveedores.SelectedRows[0].DataBoundItem as Proveedor;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                // busco por lo que escribió en el TextBox
                // si está vacío el gestor devuelve todos los proveedores
                _proveedores = _gestorProveedores.BuscarProveedor(txtBuscar.Text.Trim());
                dgvProveedores.DataSource = null;
                dgvProveedores.DataSource = _proveedores;

                if (_proveedores.Count == 0)
                    MessageBox.Show("No se encontraron proveedores.",
                        "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            // abro FrmAgregarProveedor sin pasar proveedor — modo agregar
            FrmAgregarProveedor frm = new FrmAgregarProveedor();

            // si el usuario guardó exitosamente recargo la tabla
            if (frm.ShowDialog() == DialogResult.OK)
                CargarProveedores();
        }

        private void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            // verifico que haya un proveedor seleccionado en la tabla
            Proveedor proveedorSeleccionado = ObtenerProveedorSeleccionado();
            if (proveedorSeleccionado == null) return;

            // abro FrmAgregarProveedor pasando el proveedor — modo editar
            FrmAgregarProveedor frm = new FrmAgregarProveedor(proveedorSeleccionado);

            // si el usuario guardó exitosamente recargo la tabla
            if (frm.ShowDialog() == DialogResult.OK)
                CargarProveedores();
        }

        private void btnDesactivarProveedor_Click(object sender, EventArgs e)
        {
            // verifico que haya un proveedor seleccionado
            Proveedor proveedorSeleccionado = ObtenerProveedorSeleccionado();
            if (proveedorSeleccionado == null) return;

            // pido confirmación antes de desactivar
            DialogResult confirmacion = MessageBox.Show(
                $"¿Desactivar al proveedor {proveedorSeleccionado.RazonSocial}?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    int resultado = _gestorProveedores.DesactivarProveedor(proveedorSeleccionado.IdProveedor);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Proveedor desactivado correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProveedores();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo desactivar el proveedor.",
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

        private void button1_Click(object sender, EventArgs e)
        {
            // cierro el formulario
            Close();
        }
    }
}