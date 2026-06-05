using DistribuidoraElectronicaStock.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DistribuidoraElectronicaStock.BBL
{
    public class GestorReporteStock
    {
        private ReporteStockDAL reporteStockDAL;

        public GestorReporteStock()
        {
            reporteStockDAL = new ReporteStockDAL();
        }

        public DataTable ObtenerStock(int? categoriaId)
        {
            return reporteStockDAL.ObtenerStock(categoriaId);
        }

        public DataTable ObtenerCategorias()
        {
            return reporteStockDAL.ObtenerCategorias();
        }
    }
}
