using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistribuidoraElectronicaStock.Entidades;

namespace DistribuidoraElectronicaStock.BBL
{
    public interface IObservadorStock
    {
        void NotificarBajoStock(Producto producto);
    }
}
