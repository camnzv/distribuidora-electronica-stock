using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DistribuidoraElectronicaStock.BBL;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmPrincipalEncargadoInventario : Form
    {
        public FrmPrincipalEncargadoInventario()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show("Estás seguro que querés cerrar la sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                GestorSesion.RecuperarInstancia().CerrarSesion();
                this.Close();
            }
        }

        private void btnRegistrarEntradaStock_Click(object sender, EventArgs e)
        {
            var frm = new FrmEntradaStock();
            frm.ShowDialog();
        }

        private void FrmPrincipalEncargadoInventario_Load(object sender, EventArgs e)
        {

        }
    }
}
