using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DistribuidoraElectronicaStock.DAL
{
    public class ReporteVentasDAL
    {
        private Conexion objConexion = new Conexion();

        public DataTable ObtenerVentas()
        {
            return objConexion.LeerPorStoreProcedure("SP_OBTENER_REPORTE_VENTAS", null);
        }
    }
}