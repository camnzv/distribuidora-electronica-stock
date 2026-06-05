using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.DAL
{
    public class ReporteStockDAL
    {
        private Conexion objConexion = new Conexion();

        public DataTable ObtenerStock(int? categoriaId)
        {
            var parametros = new[]
            {
                objConexion.crearParametro("@categoria_id", categoriaId.HasValue ? (object)categoriaId.Value : DBNull.Value)
            };

            return objConexion.LeerPorStoreProcedure("SP_OBTENER_REPORTE_STOCK", parametros);
        }

        public DataTable ObtenerCategorias()
        {
            return objConexion.LeerPorComando("SELECT id_categoria_producto, categoria FROM CATEGORIAS_PRODUCTOS ORDER BY categoria");
        }
    }
}