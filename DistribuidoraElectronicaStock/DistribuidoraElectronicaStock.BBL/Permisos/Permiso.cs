using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL.Permisos
{
    /// <summary>
    /// Hoja del Composite. Representa un permiso individual del sistema.
    /// </summary>
    public class Permiso : IComponentePermiso
    {
        private string _nombre;
        private bool _habilitado;

        public string Nombre => _nombre;

        public Permiso(string nombre, bool habilitado = true)
        {
            _nombre = nombre;
            _habilitado = habilitado;
        }

        public bool TienePermiso(string nombrePermiso)
        {
            return _nombre == nombrePermiso && _habilitado;
        }
    }
}
