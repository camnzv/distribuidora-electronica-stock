using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL.Permisos
{

    /// <summary>
    /// Componente base del patron composite para gestionar los permisos.
    /// </summary>
    public interface IComponentePermiso
    {
        string Nombre { get; }
        bool TienePermiso(string nombrePermiso);
    }
}
