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
    public class UsuarioDAL
    {
        private Conexion conexion = new Conexion();

        public Usuario ObtenerPorDniYPassword(int dni, string password)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@dni", dni),
                conexion.crearParametro("@password", password)
            };

            DataTable tabla =
                conexion.LeerPorStoreProcedure(
                    "SP_LOGIN_USUARIO",
                    parametros);

            if (tabla.Rows.Count == 0)
                return null;

            DataRow fila = tabla.Rows[0];

            Rol rol = new Rol(
                Convert.ToInt32(fila["rol_id"]),
                fila["nombreRol"].ToString(),
                fila["descripcion"].ToString()
            );

            return new Usuario(
                Convert.ToInt32(fila["id_usuario"]),
                fila["nombre"].ToString(),
                fila["apellido"].ToString(),
                fila["email"].ToString(),
                fila["password"].ToString(),
                Convert.ToInt32(fila["dni"]),
                rol
            );
        }

        public int AgregarUsuario(Usuario usuario)
        {
            SqlParameter[] parametros =
                    {
                conexion.crearParametro("@rol_id",   usuario.RolId),
                conexion.crearParametro("@nombre",   usuario.Nombre),
                conexion.crearParametro("@apellido", usuario.Apellido),
                conexion.crearParametro("@email",    usuario.Email),
                conexion.crearParametro("@password", usuario.Password),
                conexion.crearParametro("@dni",      usuario.Dni),
                conexion.crearParametro("@activo",   1)
                   };

            return conexion.EscribirPorStoreProcedure("SP_AGREGAR_USUARIO", parametros);
        }
    }


}

