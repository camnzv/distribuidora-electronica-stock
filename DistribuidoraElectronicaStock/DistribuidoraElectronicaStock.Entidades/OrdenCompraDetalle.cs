using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{
    public class OrdenCompraDetalle
    {
        private int _idOrdenCompraDetalle;
        private int _ordenCompraId;
        private Producto _producto;
        private int _cantidad;
        private int _cantidadRecibida;
        private decimal _montoUnitario;
        private decimal _subtotal;

        public int IdOrdenCompraDetalle
        {
            get => _idOrdenCompraDetalle;
            set => _idOrdenCompraDetalle = value;
        }
        public int OrdenCompraId
        {
            get => _ordenCompraId;
            set => _ordenCompraId = value;
        }
        public Producto Producto
        {
            get => _producto;
            set => _producto = value;
        }
        public int Cantidad
        {
            get => _cantidad;
            set => _cantidad = value;
        }
        public int CantidadRecibida  // inicia en 0 hasta registrar la entrada
        {
            get => _cantidadRecibida;
            set => _cantidadRecibida = value;
        }
        public decimal MontoUnitario
        {
            get => _montoUnitario;
            set => _montoUnitario = value;
        }
        public decimal Subtotal
        {
            get => _subtotal;
            set => _subtotal = value;
        }

        public OrdenCompraDetalle() { }

        public OrdenCompraDetalle(int idOrdenCompraDetalle, int ordenCompraId, Producto producto, int cantidad, decimal montoUnitario)
        {
            _idOrdenCompraDetalle = idOrdenCompraDetalle;
            _ordenCompraId = ordenCompraId;
            _producto = producto;
            _cantidad = cantidad;
            _cantidadRecibida = 0;
            _montoUnitario = montoUnitario;
            _subtotal = cantidad * montoUnitario;
        }

        public override string ToString()
        {
            return $"{_producto.Nombre} - Cant pedida: {_cantidad} | Cant recibida: {_cantidadRecibida}";
        }
    }
}
