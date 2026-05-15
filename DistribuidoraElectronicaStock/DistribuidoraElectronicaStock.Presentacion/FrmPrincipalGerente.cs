using DistribuidoraElectronicaStock.BBL;
using System;
using System.Windows.Forms;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmPrincipalGerente : Form
    {
        public FrmPrincipalGerente()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }
        private void ConfigurarFormulario()
        {
            this.Text = "Distribuidora Hardware - Gerente";
            this.StartPosition = FormStartPosition.CenterScreen;


            var usuario = GestorSesion.RecuperarInstancia().UsuarioActual;
            lblNombre.Text = $"{usuario.Nombre} {usuario.Apellido}";
            lblRol.Text = $"Perfil: {usuario.Rol.Nombre}";
        }



        private void btnReporteStock_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Reporte de Stock - Próxima entrega.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReporteVentas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reporte de Ventas - Próxima entrega.", "Info",
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

