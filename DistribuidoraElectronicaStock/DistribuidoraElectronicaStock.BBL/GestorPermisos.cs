using DistribuidoraElectronicaStock.BBL.Permisos;
using DistribuidoraElectronicaStock.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL
{

    /// <summary>
    /// Construye el arbol de permisos por rol consultando la base de datp
    /// y usando composite.
    /// </summary>
    public class GestorPermisos
    {
        private PermisoDAL _permisoDAL = new PermisoDAL();

        public GrupoPermisos RecuperarPermisosPorRol(int idRol)
        {
            var grupo = new GrupoPermisos($"Rol_{idRol}");

            List<Entidades.Permiso> permisosDB =
                _permisoDAL.ObtenerPermisosPorRol(idRol);

            foreach (var p in permisosDB)
            {
                // Convierte entidad → hoja del Composite
                grupo.Agregar(new Permisos.Permiso(p.Nombre));
            }

            return grupo;
        }
    }
}
