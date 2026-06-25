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

            if (venta.Total <= 0)
                return -1;

            return _ventaDAL.RegistrarVenta(venta);
        }

       
        public List<Producto> BuscarProductos(string nombre)
        {
            ProductoDAL productoDAL = new ProductoDAL();
            return productoDAL.BuscarProductos(nombre);
        }
    }
}