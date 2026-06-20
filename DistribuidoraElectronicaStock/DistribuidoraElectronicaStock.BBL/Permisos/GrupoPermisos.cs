using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL.Permisos
{
    /// <summary>
    /// Nodo compuesto del Composite. Agrupa permisos de un rol.
    /// Permite tratar permisos individuales y grupos.
    /// </summary>
    public class GrupoPermisos : IComponentePermiso
    {
        private string _nombre;
        private List<IComponentePermiso> _componentes;

        public string Nombre => _nombre;

        public GrupoPermisos(string nombre)
        {
            _nombre = nombre;
            _componentes = new List<IComponentePermiso>();
        }

        public void Agregar(IComponentePermiso componente)
        {
            _componentes.Add(componente);
        }

        public void Eliminar(IComponentePermiso componente)
        {
            _componentes.Remove(componente);
        }

        public bool TienePermiso(string nombrePermiso)
        {
            foreach (var componente in _componentes)
            {
                if (componente.TienePermiso(nombrePermiso))
                    return true;
            }
            return false;
        }

        public List<IComponentePermiso> RecuperarComponentes()
        {
            return _componentes;
        }
    }
}
