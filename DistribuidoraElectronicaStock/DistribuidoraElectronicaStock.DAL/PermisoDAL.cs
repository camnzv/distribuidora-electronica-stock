using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.DAL
{
    public class PermisoDAL
    {
        private Conexion _conexion = new Conexion();

        /// <summary>
        /// Obtiene todos los permisos asociados a un rol desde la bd.
        /// </summary>
        
        public List<Permiso> ObtenerPermisosPorRol(int idRol)
        {
            List<Permiso> permisos = new List<Permiso>();
            SqlParameter[] parametros =
            {
                _conexion.crearParametro("@id_rol", idRol)
            };

            DataTable tabla = _conexion.LeerPorStoreProcedure(
                "SP_OBTENER_PERMISOS_POR_ROL", parametros);

            if (tabla == null) return permisos;
            foreach (DataRow fila in tabla.Rows)
            {
                permisos.Add(new Permiso(
                    Convert.ToInt32(fila["id_permiso"]),
                    fila["nombre"].ToString(),
                    fila["descripcion"].ToString()
                ));
            }
            return permisos;
        }

    }
}
