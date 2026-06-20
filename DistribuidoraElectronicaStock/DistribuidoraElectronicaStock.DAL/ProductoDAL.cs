using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.DAL
{
    public class ProductoDAL
    {
        private Conexion _conexion = new Conexion();

        public List<Producto> BuscarProductos(string nombre = null, string codigo = null,
                                               int? categoria = null, int? activo = null)
        {
            List<Producto> productos = new List<Producto>();

            SqlParameter paramNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 45);
            SqlParameter paramCodigo = new SqlParameter("@codigo", SqlDbType.VarChar, 100);
            SqlParameter paramCategoria = new SqlParameter("@categoria", SqlDbType.Int);
            SqlParameter paramActivo = new SqlParameter("@activo", SqlDbType.Int);

            paramNombre.Value = (object)nombre ?? DBNull.Value;
            paramCodigo.Value = (object)codigo ?? DBNull.Value;
            paramCategoria.Value = categoria.HasValue ? (object)categoria.Value : DBNull.Value;
            paramActivo.Value = activo.HasValue ? (object)activo.Value : DBNull.Value;

            SqlParameter[] parametros = { paramNombre, paramCodigo, paramCategoria, paramActivo };

            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_BUSCAR_PRODUCTOS", parametros);

            if (tabla == null) return productos;

            foreach (DataRow fila in tabla.Rows)
            {
                CategoriaProducto categoria_ = new CategoriaProducto(
                    Convert.ToInt32(fila["categoria_producto_id"]),
                    fila["nombre_categoria"].ToString()
                );

                Producto producto = new Producto
                {
                    IdProducto = Convert.ToInt32(fila["id_producto"]),
                    Nombre = fila["nombre"].ToString(),
                    Codigo = fila["codigo"].ToString(),
                    PrecioCompra = Convert.ToDecimal(fila["precio_compra"]),
                    PrecioVenta = Convert.ToDecimal(fila["precio_venta"]),
                    Iva = Convert.ToSingle(fila["iva"]),
                    StockActual = Convert.ToInt32(fila["stock_actual"]),
                    StockMinimo = Convert.ToInt32(fila["stock_minimo"]),
                    Activo = Convert.ToInt32(fila["activo"]) == 1,
                    CategoriaProducto = categoria_  

                };

                productos.Add(producto);
            }

            return productos;
        }


        public List<Producto> ObtenerBajoStock()
        {
            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_OBTENER_PRODUCTOS_BAJO_STOCK");
            return ParsearProductos(tabla);
        }

        private List<Producto> ParsearProductos(DataTable tabla)
        {
            var lista = new List<Producto>();
            if (tabla == null) return lista;

            foreach (DataRow fila in tabla.Rows)
            {
                var categoria = new CategoriaProducto(
                    Convert.ToInt32(fila["id_categoria_producto"]),
                    fila["categoria"].ToString()
                );

                var producto = new Producto(
                    Convert.ToInt32(fila["id_producto"]),
                    categoria,
                    fila["nombre"].ToString(),
                    Convert.ToDecimal(fila["precio_compra"]),
                    Convert.ToDecimal(fila["precio_venta"]),
                    Convert.ToSingle(fila["iva"]),
                    Convert.ToInt32(fila["stock_actual"]),
                    Convert.ToInt32(fila["stock_minimo"]),
                    fila["codigo"].ToString(),
                    Convert.ToInt32(fila["activo"]) == 1
                );

                lista.Add(producto);
            }

            return lista;
        }


    }

}

