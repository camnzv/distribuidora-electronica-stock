using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{

    public class VentaDetalle
    {
        private int _idVentaDetalle;
        private int _ventaId;
        private int _productoId;
        private int _cantidad;
        private decimal _montoUnitario;
        private string _nombreProducto;

        public int IdVentaDetalle { get => _idVentaDetalle; set => _idVentaDetalle = value; }
        public int VentaId { get => _ventaId; set => _ventaId = value; }
        public int ProductoId { get => _productoId; set => _productoId = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public decimal MontoUnitario { get => _montoUnitario; set => _montoUnitario = value; }
        public string NombreProducto { get => _nombreProducto; set => _nombreProducto = value; }

        // propiedad calculada — no se guarda, se calcula al momento de usarla
        public decimal Subtotal { get => _cantidad * _montoUnitario; }

        public VentaDetalle() { }

        public VentaDetalle(int productoId, string nombreProducto,
                            int cantidad, decimal montoUnitario)
        {
            _productoId = productoId;
            _nombreProducto = nombreProducto;
            _cantidad = cantidad;
            _montoUnitario = montoUnitario;
        }
    }

}
