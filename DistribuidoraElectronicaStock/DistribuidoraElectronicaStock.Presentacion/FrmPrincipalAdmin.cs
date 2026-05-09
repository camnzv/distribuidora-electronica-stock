using DistribuidoraElectronicaStock.BBL;
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
    public partial class FrmPrincipalAdmin : Form
    {
        public FrmPrincipalAdmin()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }
        private void ConfigurarFormulario()
        {
            this.Text = "Distribuidora Hardware - Administrador";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // muestra el rol  del usuario que inicio sesion / podria ser el nombre 
            var usuario = GestorSesion.RecuperarInstancia().UsuarioActual;
            lblRol.Text = $"Perfil: {usuario.Rol.Nombre}";
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Agregar Usuario - Próxima entrega.", "Info",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buscar Usuario(editar-eliminar) - Próxima entrega.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

            var confirmar = MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                GestorSesion.RecuperarInstancia().CerrarSesion();
                this.Close();
            }

        }
    }
}
