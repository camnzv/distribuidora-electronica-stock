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
    public partial class FrmAgregarUsuario : Form
    {
        public FrmAgregarUsuario()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Agregar Usuario";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            txtDni.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            };

            txtPassword.UseSystemPasswordChar = true;

            CargarRoles();

            this.Load += (s, e) => txtNombre.Focus();
        }

        private void CargarRoles()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add(new Rol(1, "Administrador", "Gestión total"));
            cmbRol.Items.Add(new Rol(2, "Vendedor", "Ventas y clientes"));
            cmbRol.Items.Add(new Rol(3, "Encargado Inventario", "Inventario y logística"));
            cmbRol.Items.Add(new Rol(4, "Gerente", "Reportes"));
            cmbRol.DisplayMember = "Nombre";
            cmbRol.SelectedIndex = 0;
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

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("El DNI es obligatorio.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
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

            Rol rolSeleccionado = (Rol)cmbRol.SelectedItem;

            Usuario nuevoUsuario = new Usuario(
                0,
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                txtEmail.Text.Trim(),
                txtPassword.Text,
                int.Parse(txtDni.Text),
                rolSeleccionado
            );

            //  new GestorUsuarios().Agregar(nuevoUsuario)
            MessageBox.Show(
                $"Usuario {nuevoUsuario.Nombre} {nuevoUsuario.Apellido} agregado correctamente",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        
    }








}

