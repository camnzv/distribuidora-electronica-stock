using DistribuidoraElectronicaStock.DAL;
using DistribuidoraElectronicaStock.Entidades;
using System.Collections.Generic;

namespace DistribuidoraElectronicaStock.BBL
{
    public class GestorVentas
    {
        private VentaDAL _ventaDAL;

        public GestorVentas()
        {
            _ventaDAL = new VentaDAL();
        }

       
        public List<Venta> ObtenerVentas()
        {
            return new List<Venta>();
        }

       
        public int RegistrarVenta(Venta venta)
        {
           
            if (venta.ClienteId <= 0)
                return -1;

            if (venta.Detalle == null || venta.Detalle.Count == 0)
                return -1;

            if (venta.MontoTotal <= 0)
                return -1;

            return _ventaDAL.RegistrarVenta(venta);
        }

       
        public List<Producto> BuscarProductos(string nombre)
        {
            ProductoDAL productoDAL = new ProductoDAL();
            return productoDAL.BuscarProductos(nombre);
        }


        public List<Venta> ObtenerVentasPorCliente(string busqueda)
        {
            // valida si está vacio no busca
            if (string.IsNullOrWhiteSpace(busqueda))
                return new List<Venta>();

            return _ventaDAL.ObtenerVentasPorCliente(busqueda);
        }

        public List<VentaDetalle> ObtenerDetalleVenta(int ventaId)
        {
            
            if (ventaId <= 0)
                return new List<VentaDetalle>();

            return _ventaDAL.ObtenerDetalleVenta(ventaId);
        }
    }
}