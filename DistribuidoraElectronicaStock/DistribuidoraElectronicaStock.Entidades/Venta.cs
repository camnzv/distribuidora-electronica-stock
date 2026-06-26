using System;
using System.Collections.Generic;

namespace DistribuidoraElectronicaStock.Entidades
{
    public class Venta : DocumentoComercial
    {
        private int _clienteId;
        private string _nombreCliente;
        private List<VentaDetalle> _detalle;

        public int ClienteId { get => _clienteId; set => _clienteId = value; }
        public string NombreCliente { get => _nombreCliente; set => _nombreCliente = value; }
        public List<VentaDetalle> Detalle { get => _detalle; set => _detalle = value; }

        public Venta()
        {
            _detalle = new List<VentaDetalle>();
        }

        public Venta(int id, Usuario usuario, int clienteId,
                     DateTime fecha, decimal montoTotal) : base(id, usuario, fecha, montoTotal)
        {
            _clienteId = clienteId;
            _detalle = new List<VentaDetalle>();
        }

        public override decimal CalcularTotal()
        {

            if (_detalle == null) return 0;
            decimal total = 0;
            for (int i = 0; i < _detalle.Count; i++)
                total += _detalle[i].Subtotal;
            return total;
        }
    }
}