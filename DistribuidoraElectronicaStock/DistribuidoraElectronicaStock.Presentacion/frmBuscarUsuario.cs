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
    public partial class FrmBuscarUsuario : Form
    {
        private List<Usuario> _usuarios;
        public FrmBuscarUsuario()
        {
            InitializeComponent();

            ConfigurarFormulario();

        }

        private void ConfigurarFormulario()
        {

            this.Text = "Buscar Usuario";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;


            txtDni.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            };

            // el enter en los filtros dispara la busqueda
            txtNombre.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnBuscar_Click(s, e); };
            txtApellido.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnBuscar_Click(s, e); };
            txtDni.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnBuscar_Click(s, e); };

            //  opciones para el estado
            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbEstado.SelectedIndex = 0;

            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsuarios.SelectionChanged += (s, e) =>
            {
                bool haySeleccion = dgvUsuarios.SelectedRows.Count > 0;
                btnEditar.Enabled = haySeleccion;
                btnEliminar.Enabled = haySeleccion;
            };

            CargarRoles();
            CargarUsuarios();
        }

        private void CargarRoles()
        {
            try
            {
                cmbRol.Items.Clear();
                cmbRol.Items.Add(new Rol(0, "Todos", ""));

                List<Rol> roles = new GestorRoles().RecuperarTodos();
                foreach (Rol rol in roles)
                    cmbRol.Items.Add(rol);

                cmbRol.DisplayMember = "Nombre";
                cmbRol.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                string nombre = string.IsNullOrEmpty(txtNombre.Text) ? null : txtNombre.Text.Trim();
                string apellido = string.IsNullOrEmpty(txtApellido.Text) ? null : txtApellido.Text.Trim();
                int? dni = string.IsNullOrEmpty(txtDni.Text) ? (int?)null : int.Parse(txtDni.Text);

                Rol rolSeleccionado = (Rol)cmbRol.SelectedItem;
                int? rolId = rolSeleccionado.IdRol == 0 ? (int?)null : rolSeleccionado.IdRol;

                int? activo = null;
                if (cmbEstado.SelectedItem.ToString() == "Activo") activo = 1;
                if (cmbEstado.SelectedItem.ToString() == "Inactivo") activo = 0;

                _usuarios = new GestorUsuarios().BuscarUsuarios(nombre, apellido, dni, rolId, activo);

                dgvUsuarios.Rows.Clear();
                dgvUsuarios.Columns.Clear();

                
                dgvUsuarios.Columns.Add("id_usuario", "ID");
                dgvUsuarios.Columns["id_usuario"].Visible = false;

                dgvUsuarios.Columns.Add("nombre_completo", "Nombre Completo");
                dgvUsuarios.Columns.Add("email", "Correo Electrónico");
                dgvUsuarios.Columns.Add("rol", "Rol Asignado");
                dgvUsuarios.Columns.Add("estado", "Estado");

                foreach (Usuario u in _usuarios)
                {
                    int indice = dgvUsuarios.Rows.Add(
                        u.IdUsuario,
                        $"{u.Nombre} {u.Apellido}",
                        u.Email,
                        u.Rol.Nombre,
                        u.Activo ? "Activo" : "Inactivo"
                    );

                  
                    if (!u.Activo)
                        dgvUsuarios.Rows[indice].DefaultCellStyle.ForeColor =
                            System.Drawing.Color.Gray;
                }

                if (_usuarios.Count == 0)
                    MessageBox.Show("No se encontraron usuarios.", "Sin resultados",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar usuarios:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Usuario RecuperarUsuarioSeleccionado()
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return null;

            int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["id_usuario"].Value);
            return _usuarios.Find(u => u.IdUsuario == id);
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            cmbRol.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            CargarUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Usuario usuario = RecuperarUsuarioSeleccionado();
            if (usuario == null) return;

            var frm = new FrmEdicionUsuario(usuario);
            if (frm.ShowDialog() == DialogResult.OK)
                CargarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuario usuario = RecuperarUsuarioSeleccionado();
            if (usuario == null) return;

            // Verificar que no se esté desactivando a sí mismo
            Usuario usuarioLogueado = GestorSesion.RecuperarInstancia().UsuarioActual;
            if (usuario.IdUsuario == usuarioLogueado.IdUsuario)
            {
                MessageBox.Show(
                    "No puede desactivar su propio usuario mientras tiene la sesión iniciada.",
                    "Operación no permitida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si el usuario ya está inactivo
            if (!usuario.Activo)
            {
                MessageBox.Show("El usuario ya se encuentra inactivo.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmar = MessageBox.Show(
                $"¿Está seguro que desea desactivar a {usuario.Nombre} {usuario.Apellido}?\n" +
                "El usuario no podrá ingresar al sistema.",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    bool desactivado = new GestorUsuarios().EliminarUsuario(usuario.IdUsuario);

                    if (desactivado)
                    {
                        MessageBox.Show("Usuario desactivado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo desactivar el usuario.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al desactivar:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}









