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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }
        private void ConfigurarFormulario()
        {
            this.Text = "Distribuidora Hardware - Iniciar Sesión";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // solo numeros en el campo dni
            txtDni.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            };

            //pasa desde dni a contraseña
            txtDni.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    txtPassword.Focus();
            };

            // al hacer enter en contraseña se dispara el login
            txtPassword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    btnIngresar_Click(s, e);
            };
        }



        private void AbrirFormularioPorRol(Usuario usuario)
        {
            Form formulario;

            switch (usuario.RolId)
            {
                case 1:
                    formulario = new FrmPrincipalAdmin();
                    break;
                case 2:
                    formulario = new FrmPrincipalVendedor();
                    break;
                case 3:
                    formulario = new FrmPrincipalEncargadoInventario();
                    break;
                case 4:
                    formulario = new FrmPrincipalGerente();
                    break;
                default:
                    MessageBox.Show("no reconocido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                    return;
            }

            formulario.FormClosed += (s, args) =>
            {
                txtDni.Clear();
                txtPassword.Clear();
                txtDni.Focus();
                this.Show();
            };

            formulario.Show();

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            // validacion de campos completados
            if (string.IsNullOrEmpty(txtDni.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Por favor ingrese DNI y contraseña.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validacion dni numerico
            if (!int.TryParse(txtDni.Text, out int dni))
            {
                MessageBox.Show("El DNI debe contener solo números.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDni.Clear();
                txtDni.Focus();
                return;
            }

            GestorSesion sesion = GestorSesion.RecuperarInstancia();

            if (sesion.IniciarSesion(dni, txtPassword.Text))
            {
                this.Hide();
                AbrirFormularioPorRol(sesion.UsuarioActual);
            }
            else
            {
                MessageBox.Show("DNI o contraseña incorrectos.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        
    }
    }






}
