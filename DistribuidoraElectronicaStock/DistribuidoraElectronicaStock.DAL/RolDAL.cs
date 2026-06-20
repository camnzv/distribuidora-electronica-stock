using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.DAL
{
    public class RolDAL
    {
        private Conexion _conexion = new Conexion();

        public List<Rol> ObtenerTodos()
        {
            List<Rol> roles = new List<Rol>();

            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_OBTENER_ROLES");

            if (tabla == null) return roles;

            foreach (DataRow fila in tabla.Rows)
            {
                Rol rol = new Rol(
                    Convert.ToInt32(fila["id_rol"]),
                    fila["nombre"].ToString(),
                    fila["descripcion"].ToString()
                );
                roles.Add(rol);
            }

            return roles;
        }
    }
}
