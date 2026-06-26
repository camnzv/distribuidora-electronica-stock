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
    public partial class FrmEdicionUsuario : Form
    {

        private readonly Usuario _usuario;

        public FrmEdicionUsuario(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            ConfigurarFormulario();
            CargarDatos();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Editar Usuario";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            
            txtDni.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            };

            CargarRoles();
        }

        private void CargarRoles()
        {
            try
            {
                cmbRol.Items.Clear();
                List<Rol> roles = new GestorRoles().RecuperarTodos();
                foreach (Rol rol in roles)
                    cmbRol.Items.Add(rol);

                cmbRol.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            txtNombre.Text = _usuario.Nombre;
            txtApellido.Text = _usuario.Apellido;
            txtDni.Text = _usuario.Dni.ToString();
            txtEmail.Text = _usuario.Email;
            chkActivo.Checked = _usuario.Activo;

           
            foreach (Rol rol in cmbRol.Items)
            {
                if (rol.IdRol == _usuario.Rol.IdRol)
                {
                    cmbRol.SelectedItem = rol;
                    break;
                }
            }
            // si quiere editar su propio usuario no dejo que manipule su estado 
            Usuario usuarioLogueado = GestorSesion.RecuperarInstancia().UsuarioActual;
            if (_usuario.IdUsuario == usuarioLogueado.IdUsuario)
            {
                chkActivo.Enabled = false;
                chkActivo.Checked = true; 
              
            }
        }

      

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("El DNI es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El correo electrónico es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {


            if (!ValidarCampos()) return;

            try
            {
                // Validación extra: no puede desactivarse a sí mismo
                Usuario usuarioLogueado = GestorSesion.RecuperarInstancia().UsuarioActual;
                if (_usuario.IdUsuario == usuarioLogueado.IdUsuario && !chkActivo.Checked)
                {
                    MessageBox.Show(
                        "No puede desactivar su propio usuario.",
                        "Operación no permitida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chkActivo.Checked = true;
                    return;
                }

                _usuario.Nombre = txtNombre.Text.Trim();
                _usuario.Apellido = txtApellido.Text.Trim();
                _usuario.Dni = int.Parse(txtDni.Text);
                _usuario.Email = txtEmail.Text.Trim();
                _usuario.Rol = (Rol)cmbRol.SelectedItem;
                _usuario.Activo = chkActivo.Checked;

                bool actualizado = new GestorUsuarios().ActualizarUsuario(_usuario);

                if (actualizado)
                {
                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el usuario.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

