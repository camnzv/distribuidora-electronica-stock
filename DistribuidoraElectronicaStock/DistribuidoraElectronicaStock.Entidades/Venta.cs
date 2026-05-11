using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{
    public class Venta
    {
        public int IdVenta { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }
    }
}
