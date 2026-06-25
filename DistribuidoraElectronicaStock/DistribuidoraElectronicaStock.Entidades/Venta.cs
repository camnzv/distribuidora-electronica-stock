using System;
using System.Collections.Generic;

namespace DistribuidoraElectronicaStock.Entidades
{
    public class Venta
    {
        private int _idVenta;
        private int _usuarioId;
        private int _clienteId;
        private DateTime _fecha;
        private decimal _total;
        private List<VentaDetalle> _detalle;
        private string _nombreCliente;

        public int IdVenta { get => _idVenta; set => _idVenta = value; }
        public int UsuarioId { get => _usuarioId; set => _usuarioId = value; }
        public int ClienteId { get => _clienteId; set => _clienteId = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public decimal Total { get => _total; set => _total = value; }
        public List<VentaDetalle> Detalle { get => _detalle; set => _detalle = value; }
        public string NombreCliente { get => _nombreCliente; set => _nombreCliente = value; }

        public Venta()
        {
            _detalle = new List<VentaDetalle>();
            _fecha = DateTime.Now;
        }

        public Venta(int idVenta, int usuarioId, int clienteId,
                     DateTime fecha, decimal montoTotal)
        {
            _idVenta = idVenta;
            _usuarioId = usuarioId;
            _clienteId = clienteId;
            _fecha = fecha;
            _total = montoTotal;
            _detalle = new List<VentaDetalle>();
        }
    }
}