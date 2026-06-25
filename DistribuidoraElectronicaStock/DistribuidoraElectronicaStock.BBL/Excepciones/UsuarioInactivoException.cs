using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL.Excepciones
{
   
    /// Se lanza cuando un usuario intenta iniciar sesión
    /// pero su cuenta fue desactivada por el administrador.
  
    public class UsuarioInactivoException : Exception
    {
        public UsuarioInactivoException()
            : base("El usuario se encuentra inactivo. Contacte al administrador.") { }

        public UsuarioInactivoException(string mensaje)
            : base(mensaje) { }
    }
}
