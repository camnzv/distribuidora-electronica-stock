using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL.Excepciones
{
    /// Se lanza cuando se intenta agregar un cliente
    /// con un CUIT que ya esta registrado.
  
    public class ClienteYaExisteException : Exception
    {
        public ClienteYaExisteException()
            : base("Ya existe un cliente registrado con ese CUIT.") { }

        public ClienteYaExisteException(string cuit)
            : base($"Ya existe un cliente registrado con el CUIT {cuit}.") { }
    }
}
