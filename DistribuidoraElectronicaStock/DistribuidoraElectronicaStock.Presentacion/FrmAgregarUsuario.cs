using DistribuidoraElectronicaStock.BBL;
using DistribuidoraElectronicaStock.BBL.Factories;
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
            txtConfirmarPassword.UseSystemPasswordChar = true;
            // mensaje para la constraseña,se muestra mientras se van llenando los campos 
            txtPassword.TextChanged += ValidarCoincidenciaVisual;
            txtConfirmarPassword.TextChanged += ValidarCoincidenciaVisual;


            CargarRoles();

            this.Load += (s, e) => txtNombre.Focus();
        }

        private void CargarRoles()
        {
            try
            {
                GestorRoles gestorRoles = new GestorRoles();
                List<Rol> roles = gestorRoles.RecuperarTodos();

                cmbRol.Items.Clear();

                foreach (Rol rol in roles)
                {
                    cmbRol.Items.Add(rol);
                }

                cmbRol.DisplayMember = "Nombre";

                if (cmbRol.Items.Count > 0)
                    cmbRol.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los roles:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ValidarCoincidenciaVisual(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtConfirmarPassword.Text))
            {
                txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F3F4");
                txtConfirmarPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F3F4");
                lblEstadoPassword.Text = "";
                lblEstadoPassword.Visible = false;
                return;
            }

            if (txtPassword.Text == txtConfirmarPassword.Text)
            {
                txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#EAFAF1");
                txtConfirmarPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#EAFAF1");
                lblEstadoPassword.Text = "Las contraseñas coinciden";
                lblEstadoPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E8449");
                lblEstadoPassword.Visible = true;
            }
            else
            {
                txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#FDEDEC");
                txtConfirmarPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#FDEDEC");
                lblEstadoPassword.Text = "Las contraseñas no coinciden";
                lblEstadoPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E74C3C");
                lblEstadoPassword.Visible = true;
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

            try
            {
                GestorUsuarios gestor = new GestorUsuarios();
                if (gestor.ExisteDni(int.Parse(txtDni.Text)))
                {
                    MessageBox.Show(
                        $"Ya existe un usuario registrado con el DNI {txtDni.Text}.",
                        "DNI duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDni.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al verificar el DNI:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtConfirmarPassword.Text))
            {
                MessageBox.Show("Debe confirmar la contraseña.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarPassword.Focus();
                return false;
            }
            if (txtPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtConfirmarPassword.Clear();
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

            Usuario nuevoUsuario = UsuarioFactory.CrearUsuario(
             txtNombre.Text,
             txtApellido.Text,
             txtEmail.Text,
             txtPassword.Text,        // hasheado con el factory
             int.Parse(txtDni.Text),
             rolSeleccionado
         );

            try
            {
                GestorUsuarios gestor = new GestorUsuarios();

                if (gestor.AgregarUsuario(nuevoUsuario))
                {
                    MessageBox.Show(
                        $"Usuario {nuevoUsuario.Nombre} {nuevoUsuario.Apellido} agregado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo agregar el usuario. Intente nuevamente.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al conectar con la base de datos:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }








}

