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
    public partial class FrmReporteVentasGerente : Form
    {
        private GestorReporteVentas gestorVentas = new GestorReporteVentas();
        private DataTable _todasLasVentas;

        public FrmReporteVentasGerente()
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

        private void FrmReporteVentasGerente_Load(object sender, EventArgs e)
        {
            _todasLasVentas = gestorVentas.ObtenerVentas();
            dgvVentas.DataSource = _todasLasVentas;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (_todasLasVentas == null) return;

            if (rbSemanal.Checked)
                dgvVentas.DataSource = gestorVentas.FiltrarPorSemanal(_todasLasVentas.Copy());
            else if (rbMensual.Checked)
                dgvVentas.DataSource = gestorVentas.FiltrarPorMensual(_todasLasVentas.Copy());
            else if (rbVendedor.Checked)
                dgvVentas.DataSource = gestorVentas.OrdenarPorVendedor(_todasLasVentas.Copy());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReporteVentasGerente_Load_1(object sender, EventArgs e)
        {
            _todasLasVentas = gestorVentas.ObtenerVentas();
            dgvVentas.DataSource = _todasLasVentas.Copy();
        }
    }
}