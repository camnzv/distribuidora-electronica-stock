using DistribuidoraElectronicaStock.BBL;
using System;
using System.Windows.Forms;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmPrincipalVendedor : Form
    {
        public FrmPrincipalVendedor()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Distribuidora Hardware - Vendedor";

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.StartPosition = FormStartPosition.CenterScreen;

            // Usuario logueado
            var usuario = GestorSesion
                .RecuperarInstancia()
                .UsuarioActual;

            lblRol.Text = $"{usuario.Rol.Nombre}";
        }



        private void btnAdministrarClientes_Click(object sender, EventArgs e)
        {
            FrmGestionClientes frm = new FrmGestionClientes();

            frm.ShowDialog();
        }

        private void btnAdministrarVentas_Click(object sender, EventArgs e)
        {
            FrmGestionVentas frm = new FrmGestionVentas();

            frm.ShowDialog();
        }

        private void btnAdministrarProductos_Click(object sender, EventArgs e)
        {
            FrmGestionProductos frm = new FrmGestionProductos();

            frm.ShowDialog();
        }
   

     

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show(
                "¿Desea cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                GestorSesion
                    .RecuperarInstancia()
                    .CerrarSesion();

                this.Close();
            }
        }

        
    }
}