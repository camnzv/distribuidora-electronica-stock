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
    public partial class FrmReporteStockGerente : Form
    {
        public FrmReporteStockGerente()
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
