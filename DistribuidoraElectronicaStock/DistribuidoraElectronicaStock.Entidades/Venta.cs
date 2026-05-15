using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{
    public class Venta
    {
        private int _idVenta;
        private DateTime _fecha;
        private decimal _total;

        public int IdVenta
        {
            get => _idVenta;
            set => _idVenta = value;
        }

        public DateTime Fecha
        {
            get => _fecha;
            set => _fecha = value;
        }

        public decimal Total
        {
            get => _total;
            set => _total = value;
        }

        public Venta() { }

        public Venta(int idVenta, DateTime fecha, decimal total)
        {
            _idVenta = idVenta;
            _fecha = fecha;
            _total = total;
        }
    }
}
