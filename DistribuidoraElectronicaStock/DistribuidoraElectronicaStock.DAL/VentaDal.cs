using DistribuidoraElectronicaStock.Entidades;
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
            // paso 1 — inserto la cabecera y obtengo el id generado
            SqlParameter[] parametrosCabecera = new SqlParameter[]
            {
                _conexion.crearParametro("@usuario_id", venta.UsuarioId),
                _conexion.crearParametro("@cliente_id", venta.ClienteId),
                _conexion.crearParametro("@fecha", venta.Fecha),
                _conexion.crearParametro("@monto_total", (double)venta.Total)
            };

            // LeerPorStoreProcedure porque el SP devuelve el id con SELECT SCOPE_IDENTITY()
            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_REGISTRAR_VENTA", parametrosCabecera);

            if (tabla == null || tabla.Rows.Count == 0)
                return -1;

            // obtengo el id de la venta recién creada
            int idVenta = System.Convert.ToInt32(tabla.Rows[0]["id_venta"]);

            // paso 2 — inserto cada línea del detalle
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

                // paso 3 — descuento el stock de cada producto vendido
                SqlParameter[] parametrosStock = new SqlParameter[]
                {
                    _conexion.crearParametro("@producto_id", detalle.ProductoId),
                    _conexion.crearParametro("@cantidad", detalle.Cantidad)
                };

                _conexion.EscribirPorStoreProcedure("SP_DESCONTAR_STOCK", parametrosStock);
            }

            return idVenta;
        }
    }
}