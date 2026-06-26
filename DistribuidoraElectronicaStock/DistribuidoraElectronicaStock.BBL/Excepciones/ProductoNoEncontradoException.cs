using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL.Excepciones
{
   
    /// Se lanza cuando se busca un producto que no existe
    /// o fue dado de baja del sistema.
    public class ProductoNoEncontradoException : Exception
    {
        public ProductoNoEncontradoException()
            : base("El producto no fue encontrado en el sistema.") { }

        public ProductoNoEncontradoException(string codigo)
            : base($"No se encontró ningún producto con el código '{codigo}'.") { }
    }
}
