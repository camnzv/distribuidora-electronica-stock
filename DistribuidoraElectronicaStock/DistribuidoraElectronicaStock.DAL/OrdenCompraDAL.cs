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
    public class OrdenCompraDAL
    {
        private Conexion conexion = new Conexion();

        //Órdenes pendientes
        public List<OrdenCompra> ObtenerOrdenesPendientes()
        {
            DataTable tabla = conexion.LeerPorStoreProcedure("SP_OBTENER_ORDENES_PENDIENTES");
            return ParsearOrdenes(tabla);
        }

        //Órdenes parciales
        public List<OrdenCompra> ObtenerOrdenesParciales()
        {
            DataTable tabla = conexion.LeerPorStoreProcedure("SP_OBTENER_ORDENES_PARCIALES");
            return ParsearOrdenes(tabla);
        }

        
        private List<OrdenCompra> ParsearOrdenes(DataTable tabla)
        {
            var ordenes = new List<OrdenCompra>();
            if (tabla == null) return ordenes;

            foreach (DataRow fila in tabla.Rows)
            {
                var proveedorTipo = new ProveedorTipo(
                    Convert.ToInt32(fila["id_proveedor_tipo"]),
                    fila["tipo"].ToString(),
                    fila["descripcion"].ToString()
                );

                var proveedor = new Proveedor(
                    Convert.ToInt32(fila["id_proveedor"]),
                    proveedorTipo,
                    fila["cuit"].ToString(),
                    fila["razon_social"].ToString(),
                    fila["email"].ToString(),
                    fila["telefono"].ToString(),
                    Convert.ToInt32(fila["proveedor_activo"]) == 1
                );

                var rol = new Rol(Convert.ToInt32(fila["rol_id"]), "", "");

                var usuario = new Usuario(
                    Convert.ToInt32(fila["id_usuario"]),
                    fila["nombre"].ToString(),
                    fila["apellido"].ToString(),
                    fila["usuario_email"].ToString(),
                    "",
                    Convert.ToInt32(fila["dni"]),
                    rol
                );

                EstadoOrdenCompra estado = fila["estado"].ToString().ToUpper() == "PARCIAL" ? EstadoOrdenCompra.Parcial : EstadoOrdenCompra.Pendiente;

                DateTime? fechaRecepcion = fila["fecha_recepcion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(fila["fecha_recepcion"]);

                var orden = new OrdenCompra(
                    Convert.ToInt32(fila["id_orden_compra"]),
                    proveedor,
                    usuario,
                    Convert.ToDecimal(fila["monto_total"]),
                    Convert.ToDateTime(fila["fecha_emision"]),
                    fechaRecepcion,
                    estado
                );

                orden.Detalle = ObtenerDetalleOrden(orden.IdOrdenCompra);
                ordenes.Add(orden);
            }

            return ordenes;
        }

        //Detalle de orden
        public List<OrdenCompraDetalle> ObtenerDetalleOrden(int idOrdenCompra)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@idOrdenCompra", idOrdenCompra)
            };

            DataTable tabla = conexion.LeerPorStoreProcedure("SP_OBTENER_DETALLE_ORDEN", parametros);

            var detalles = new List<OrdenCompraDetalle>();
            if (tabla == null) return detalles;

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
                    Convert.ToInt32(fila["producto_activo"]) == 1
                );

                int cantRecibida = fila["cantidad_recibida"] == DBNull.Value ? 0 : Convert.ToInt32(fila["cantidad_recibida"]);

                var detalle = new OrdenCompraDetalle(
                    Convert.ToInt32(fila["id_orden_compra_detalle"]),
                    Convert.ToInt32(fila["orden_compra_id"]),
                    producto,
                    Convert.ToInt32(fila["cantidad"]),
                    Convert.ToDecimal(fila["monto_unitario"])
                );

                detalle.CantidadRecibida = cantRecibida;
                detalles.Add(detalle);
            }

            return detalles;
        }

        //Actualizar orden
        public bool ActualizarOrden(OrdenCompra orden)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@estado",          orden.Estado.ToString().ToUpper()),
                conexion.crearParametro("@fecha_recepcion", orden.FechaRecepcion ?? DateTime.Now),
                conexion.crearParametro("@idOrdenCompra",   orden.IdOrdenCompra)
            };

            return conexion.EscribirPorStoreProcedure("SP_ACTUALIZAR_ORDEN_COMPRA", parametros) > 0;
        }

        //Actualizar stock
        public bool ActualizarStockProducto(int idProducto, int cantidadRecibida, int cantidadVendida)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@idProducto",       idProducto),
                conexion.crearParametro("@cantidadRecibida", cantidadRecibida),
                conexion.crearParametro("@cantidadVendida",  cantidadVendida)
            };

            return conexion.EscribirPorStoreProcedure("SP_ACTUALIZAR_PRODUCTO_STOCK", parametros) > 0;
        }

        //Actualizar cantidad recibida en detalle
        public bool ActualizarDetalleOrden(OrdenCompraDetalle detalle)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@CantidadRecibida",     detalle.CantidadRecibida),
                conexion.crearParametro("@IdOrdenCompraDetalle", detalle.IdOrdenCompraDetalle)
            };

            return conexion.EscribirPorStoreProcedure("SP_ACTUALIZAR_ORDENES_COMPRA_DETALLE_CANTIDAD_RECIBIDA", parametros) > 0;
        }
    }
}
