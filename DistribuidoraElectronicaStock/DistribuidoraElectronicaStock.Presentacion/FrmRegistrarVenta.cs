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
using DistribuidoraElectronicaStock.Entidades;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmRegistrarVenta : Form
    {
        private GestorClientes _gestorClientes;

        public FrmRegistrarVenta()

        {
            InitializeComponent();

            _gestorClientes = new GestorClientes();
        }

        private void FrmRegistarVenta_Load(object sender, EventArgs e)
        {
            CargarClientes();
            dtpFecha.Value = DateTime.Now; // carga la fecha de hoy por defecto

        }

        private void CargarClientes() {

            var clientes = _gestorClientes.ObtenerClientes();

            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "RazonSocial"; //esto se ve en el combo
            cmbCliente.ValueMember = "idCliente"; // valor que guarda
        
        }
    }
}
