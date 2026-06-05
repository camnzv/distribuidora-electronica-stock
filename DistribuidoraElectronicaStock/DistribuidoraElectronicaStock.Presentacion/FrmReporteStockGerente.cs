using DistribuidoraElectronicaStock.BBL;
using System;
using System.Data;
using System.Windows.Forms;

namespace DistribuidoraElectronicaStock.Presentacion
{
    public partial class FrmReporteStockGerente : Form
    {
        private GestorReporteStock gestorStock = new GestorReporteStock();

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

        private void FrmReporteStockGerente_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarStock(null);
        }

        private void CargarCategorias()
        {
            DataTable dt = gestorStock.ObtenerCategorias();

            DataRow todas = dt.NewRow();
            todas["id_categoria_producto"] = DBNull.Value;
            todas["categoria"] = "Todas las categorías";
            dt.Rows.InsertAt(todas, 0);

            cmbCategoria.DataSource = dt;
            cmbCategoria.DisplayMember = "categoria";
            cmbCategoria.ValueMember = "id_categoria_producto";
            cmbCategoria.SelectedIndex = 0;
        }

        private void CargarStock(int? categoriaId)
        {
            dgvStock.DataSource = gestorStock.ObtenerStock(categoriaId);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int? categoriaId = null;

            if (cmbCategoria.SelectedValue != null && cmbCategoria.SelectedValue != DBNull.Value)
                categoriaId = Convert.ToInt32(cmbCategoria.SelectedValue);

            CargarStock(categoriaId);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}