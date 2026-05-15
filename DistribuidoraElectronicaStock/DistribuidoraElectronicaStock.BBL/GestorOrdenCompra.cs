using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DistribuidoraElectronicaStock.Entidades;

namespace DistribuidoraElectronicaStock.BBL
{
    public class GestorOrdenCompra
    {
        private List<OrdenCompra> ObtenerOrdenesMock()
        {
            var tipo1 = new ProveedorTipo(1, "Electrónica", "Componentes electrónicos");
            var tipo2 = new ProveedorTipo(2, "Insumos", "Insumos de computación");

            var prov1 = new Proveedor(1, tipo1, "20-12345678-2", "Provelectric", "info@electro.com", "011-1234-5678", true);
            var prov2 = new Proveedor(2, tipo2, "30-98765432-3", "Proveinsumos", "info@insumos.com", "011-8765-4321", true);

            var rol = new Rol(3, "Encargado de Inventario", "Inventario y logística");
            var usuario = new Usuario(3, "María", "González", "mgl@distri.com", "pass789", 33333333, rol);


            var catPeriferico = new CategoriaProducto(2, "Periféricos");
            var catMonitor = new CategoriaProducto(3, "Monitores");

            var prod1 = new Producto(1, catPeriferico,  "Mouse Gamer Logitech", 1500, 2500, 0.21f, 10, 5, "MOUSE-001", true);
            var prod2 = new Producto(2, catPeriferico,"Teclado Mecánico", 3000, 5000, 0.21f, 5, 3, "TEC-001", true);
            var prod3 = new Producto(3, catMonitor, "Monitor Samsung 27pulgadas", 45000, 75000, 0.21f, 2, 2, "MON-001", true);

            var orden1 = new OrdenCompra(1, prov1, usuario, 17000, DateTime.Now.AddDays(-5), null, EstadoOrdenCompra.Pendiente);
            orden1.Detalle.Add(new OrdenCompraDetalle(1, 1, prod1, 5, 1500));
            orden1.Detalle.Add(new OrdenCompraDetalle(2, 1, prod2, 3, 3000));

            var orden2 = new OrdenCompra(2, prov2, usuario, 90000, DateTime.Now.AddDays(-2), null, EstadoOrdenCompra.Pendiente);
            orden2.Detalle.Add(new OrdenCompraDetalle(3, 2, prod3, 2, 45000));

            return new List<OrdenCompra> { orden1, orden2 };
        }

        public List<OrdenCompra> ObtenerOrdenesPendientes()
        {
            return ObtenerOrdenesMock().FindAll(o => o.Estado == EstadoOrdenCompra.Pendiente || o.Estado == EstadoOrdenCompra.Parcial);
        }

        public bool ValidarCantidades(List<OrdenCompraDetalle> detalles)
        {
            foreach (var detalle in detalles)
            {
                if (detalle.CantidadRecibida < 0 || detalle.CantidadRecibida > detalle.Cantidad)
                    return false;
            }
            return true;
        }

        public bool RegistrarEntrada(OrdenCompra orden, List<OrdenCompraDetalle> detalles)
        {
            if (!ValidarCantidades(detalles))
                return false;

            //Si es recepción parcial o completa
            bool esParcial = detalles.Exists(d => d.CantidadRecibida < d.Cantidad);
            orden.Estado = esParcial ? EstadoOrdenCompra.Parcial : EstadoOrdenCompra.Completada;
            orden.FechaRecepcion = DateTime.Now;

            //Actualiza stock en memoria (luego se conectar al DAL)
            foreach (var detalle in detalles)
            {
                if (detalle.CantidadRecibida > 0) detalle.Producto.StockActual += detalle.CantidadRecibida;
            }

            return true;
        }
    }

}
