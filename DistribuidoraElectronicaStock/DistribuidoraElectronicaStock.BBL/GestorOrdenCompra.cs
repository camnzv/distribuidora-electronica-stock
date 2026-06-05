using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistribuidoraElectronicaStock.DAL;

namespace DistribuidoraElectronicaStock.BBL
{
    public class GestorOrdenCompra
    {
        private OrdenCompraDAL _ordenCompraDAL = new OrdenCompraDAL();

        public List<OrdenCompra> ObtenerOrdenesPendientes() => _ordenCompraDAL.ObtenerOrdenesPendientes();

        public List<OrdenCompra> ObtenerOrdenesParciales() => _ordenCompraDAL.ObtenerOrdenesParciales();

        public bool ValidarCantidades(List<OrdenCompraDetalle> detalles, bool esParcial = false)
        {
            foreach (var detalle in detalles)
            {
                int maximo = esParcial
                    ? detalle.Cantidad - detalle.CantidadRecibida  // faltante
                    : detalle.Cantidad;                             // total pedido

                if (detalle.CantidadRecibida < 0 || detalle.CantidadRecibida > maximo)
                    return false;
            }
            return true;
        }

        public bool RegistrarEntrada(OrdenCompra orden, List<OrdenCompraDetalle> detalles, bool esParcial = false)
        {
            if (!ValidarCantidades(detalles, esParcial))
                return false;

            orden.FechaRecepcion = DateTime.Now;

            foreach (var detalle in detalles)
            {
                if (detalle.CantidadRecibida > 0)
                {
                    _ordenCompraDAL.ActualizarStockProducto(detalle.Producto.IdProducto, detalle.CantidadRecibida, 0);
                    _ordenCompraDAL.ActualizarDetalleOrden(detalle);
                }
            }

            // Re-consulta el detalle real desde BD para determinar el estado
            var detallesActualizados = _ordenCompraDAL.ObtenerDetalleOrden(orden.IdOrdenCompra);
            bool quedaParcial = detallesActualizados.Exists(d => d.CantidadRecibida < d.Cantidad);

            orden.Estado = quedaParcial ? EstadoOrdenCompra.Parcial : EstadoOrdenCompra.Completada;

            return _ordenCompraDAL.ActualizarOrden(orden);
        }
    }
}