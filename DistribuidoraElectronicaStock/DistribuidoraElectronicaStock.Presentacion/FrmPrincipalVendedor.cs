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

            lblRol.Text = $"Perfil: {usuario.Rol.Nombre}";
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Buscar Cliente - Próxima entrega.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Editar Cliente - Próxima entrega.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnDesactivarCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Desactivar Cliente - Próxima entrega.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

        private void btnBuscarProductos_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Buscar Productos - Próxima entrega.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
              "Agregar Cliente - Próxima entrega.",
              "Info",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information);
        }
    }
}