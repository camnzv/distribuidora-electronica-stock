using DistribuidoraElectronicaStock.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DistribuidoraElectronicaStock.DAL
{
    public class VentaDAL
    {
        private Conexion _conexion;

        public VentaDAL()
        {
            _conexion = new Conexion();
        }

        public int RegistrarVenta(Venta venta)
        {
            // inserto la cabecera y obtengo el id generado
            SqlParameter[] parametrosCabecera = new SqlParameter[]
            {
                _conexion.crearParametro("@usuario_id", venta.Usuario.IdUsuario),
                _conexion.crearParametro("@cliente_id", venta.ClienteId),
                _conexion.crearParametro("@fecha", venta.Fecha),
                _conexion.crearParametro("@monto_total", (double)venta.MontoTotal)
            };

            // LeerPorStoreProcedure porque el SP devuelve el id con SELECT SCOPE_IDENTITY()
            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_REGISTRAR_VENTA", parametrosCabecera);

            if (tabla == null || tabla.Rows.Count == 0)
                return -1;

            // obtengo el id de la venta recién creada
            int idVenta = System.Convert.ToInt32(tabla.Rows[0]["id_venta"]);

            // inserto cada línea del detalle
            foreach (VentaDetalle detalle in venta.Detalle)
            {
                SqlParameter[] parametrosDetalle = new SqlParameter[]
                {
                    _conexion.crearParametro("@venta_id", idVenta),
                    _conexion.crearParametro("@producto_id", detalle.ProductoId),
                    _conexion.crearParametro("@cantidad", detalle.Cantidad),
                    _conexion.crearParametro("@monto_unitario", (double)detalle.MontoUnitario)
                };

                _conexion.EscribirPorStoreProcedure("SP_REGISTRAR_VENTA_DETALLE", parametrosDetalle);

                // descuento el stock de cada producto vendido
                SqlParameter[] parametrosStock = new SqlParameter[]
                {
                    _conexion.crearParametro("@producto_id", detalle.ProductoId),
                    _conexion.crearParametro("@cantidad", detalle.Cantidad)
                };

                _conexion.EscribirPorStoreProcedure("SP_DESCONTAR_STOCK", parametrosStock);
            }

            return idVenta;
        }

        public List<Venta> ObtenerVentasPorCliente(string busqueda)
        {
            List<Venta> ventas = new List<Venta>();

            // armo el parámetro con la búsqueda del cliente
            SqlParameter[] parametros = new SqlParameter[]
            {
        _conexion.crearParametro("@busqueda", busqueda)
            };

            // llamo al SP que busca ventas por razon social o CUIT del cliente
            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_OBTENER_VENTAS_POR_CLIENTE", parametros);

            if (tabla == null) return ventas;

            // recorro cada fila y creo un objeto Venta
            foreach (DataRow fila in tabla.Rows)
            {
                Venta v = new Venta();
                v.Id = System.Convert.ToInt32(fila["id_venta"]);
                v.Fecha = System.Convert.ToDateTime(fila["fecha"]);
                v.MontoTotal = System.Convert.ToDecimal(fila["monto_total"]);
                v.NombreCliente = fila["nombre_cliente"].ToString();

                // usuario solo con el nombre para mostrar en la grilla
                Usuario u = new Usuario();
                u.Nombre = fila["nombre_usuario"].ToString();
                v.Usuario = u;

                ventas.Add(v);
            }

            return ventas;
        }

        public List<VentaDetalle> ObtenerDetalleVenta(int ventaId)
        {
            List<VentaDetalle> detalle = new List<VentaDetalle>();

            // armo el parámetro con el id de la venta seleccionada
            SqlParameter[] parametros = new SqlParameter[]
            {
        _conexion.crearParametro("@venta_id", ventaId)
            };

            // llamo al SP que trae el detalle de esa venta
            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_OBTENER_DETALLE_VENTA", parametros);

            if (tabla == null) return detalle;

            // recorro cada fila y creo un objeto VentaDetalle
            foreach (DataRow fila in tabla.Rows)
            {
                VentaDetalle item = new VentaDetalle();
                item.Cantidad = System.Convert.ToInt32(fila["cantidad"]);
                item.MontoUnitario = System.Convert.ToDecimal(fila["monto_unitario"]);
                item.NombreProducto = fila["nombre_producto"].ToString();
                detalle.Add(item);
            }

            return detalle;
        }
    }
}