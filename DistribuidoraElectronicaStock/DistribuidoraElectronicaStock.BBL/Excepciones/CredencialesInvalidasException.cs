using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL.Excepciones
{
    // Se lanza cuando el dni o contraseña ingresados no coinciden
    // con ningun registro  en el sistema
    public class CredencialesInvalidasException : Exception
    {
        public CredencialesInvalidasException()
            : base("Las credenciales ingresadas son incorrectas.") { }

        public CredencialesInvalidasException(string mensaje)
            : base(mensaje) { }
    }
}
