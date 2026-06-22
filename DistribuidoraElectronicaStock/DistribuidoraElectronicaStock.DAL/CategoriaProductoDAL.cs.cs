using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.DAL
{
    public class CategoriaProductoDAL
    {


        private Conexion _conexion = new Conexion();

        public List<CategoriaProducto> ObtenerTodas()
        {
            List<CategoriaProducto> categorias = new List<CategoriaProducto>();

            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_OBTENER_CATEGORIAS");

            if (tabla == null) return categorias;

            foreach (DataRow fila in tabla.Rows)
            {
                categorias.Add(new CategoriaProducto(
                    Convert.ToInt32(fila["id_categoria_producto"]),
                    fila["categoria"].ToString()
                ));
            }

            return categorias;
        }
    }


}
