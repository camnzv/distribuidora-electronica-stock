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
    public partial class FrmGestionVentas : Form
    {
        public FrmGestionVentas()
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

            lblRol.Text = $"Perfil: {usuario.Rol.Nombre}";
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
              "Registrar Venta - Próxima entrega.",
              "Info",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information);
        }

        private void btnVerVentas_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
             "Ver Ventas - Próxima entrega.",
             "Info",
             MessageBoxButtons.OK,
             MessageBoxIcon.Information);
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {

            Close();

        }
    }
}
