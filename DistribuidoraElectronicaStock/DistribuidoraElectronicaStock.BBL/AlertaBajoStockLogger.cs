using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DistribuidoraElectronicaStock.Entidades;

namespace DistribuidoraElectronicaStock.BBL
{
    // OBSERVER: Acumula los productos con bajo stock
    public class AlertaBajoStockLogger : IObservadorStock
    {
        private List<Producto> _alertas = new List<Producto>();

        public void NotificarBajoStock(Producto producto)
        {
            //Evita duplicados
            if (!_alertas.Exists(p => p.IdProducto == producto.IdProducto))
                _alertas.Add(producto);
        }

        public List<Producto> ObtenerAlertas() => _alertas;

        public void LimpiarAlertas() => _alertas.Clear();
    }
}
