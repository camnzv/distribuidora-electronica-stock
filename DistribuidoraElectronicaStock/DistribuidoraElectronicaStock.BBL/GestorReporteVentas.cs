using DistribuidoraElectronicaStock.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DistribuidoraElectronicaStock.BBL
{
    public class GestorReporteVentas
    {
        private ReporteVentasDAL reporteVentasDAL;

        public GestorReporteVentas()
        {
            reporteVentasDAL = new ReporteVentasDAL();
        }

        public DataTable ObtenerVentas()
        {
            return reporteVentasDAL.ObtenerVentas();
        }

        public DataTable FiltrarPorSemanal(DataTable dt)
        {
            DateTime desdeFecha = DateTime.Now.AddDays(-7);
            DataView dv = new DataView(dt);
            dv.RowFilter = $"Fecha >= #{desdeFecha:MM/dd/yyyy}#";
            dv.Sort = "Fecha DESC";
            return dv.ToTable();
        }

        public DataTable FiltrarPorMensual(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) return new DataTable();

            DateTime desde = DateTime.Now.AddDays(-30);
            DataView dv = new DataView(dt);
            dv.RowFilter = $"Fecha >= #{desde:MM/dd/yyyy}#";
            dv.Sort = "Fecha DESC";
            return dv.ToTable();
        }

        public DataTable OrdenarPorVendedor(DataTable dt)
        {
            DataView dv = new DataView(dt);
            dv.Sort = "Vendedor ASC";
            return dv.ToTable();
        }
    }
}