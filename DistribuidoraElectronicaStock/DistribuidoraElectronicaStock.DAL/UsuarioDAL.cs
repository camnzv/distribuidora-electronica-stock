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

        /*public Usuario ObtenerPorDniYPassword(int dni, string password)
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
        }*/
        public Usuario ObtenerPorDniYPassword(int dni, string password)
        {
            SqlParameter[] parametros =
            {
        conexion.crearParametro("@dni",      dni),
        conexion.crearParametro("@password", password)
           };

            DataTable tabla = conexion.LeerPorStoreProcedure("SP_LOGIN_USUARIO", parametros);

            if (tabla == null || tabla.Rows.Count == 0)
                return null;

            DataRow fila = tabla.Rows[0];

            Rol rol = new Rol(
                Convert.ToInt32(fila["rol_id"]),
                fila["nombreRol"].ToString(),
                fila["descripcion"].ToString()
            );

            Usuario usuario = new Usuario(
                Convert.ToInt32(fila["id_usuario"]),
                fila["nombre"].ToString(),
                fila["apellido"].ToString(),
                fila["email"].ToString(),
                fila["password"].ToString(),
                Convert.ToInt32(fila["dni"]),
                rol
            );

            usuario.Activo = Convert.ToInt32(fila["activo"]) == 1; 

            return usuario;
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


        public List<Usuario> BuscarUsuarios(string nombre = null, string apellido = null,
                                     int? dni = null, int? rolId = null, int? activo = null)
        {
            List<Usuario> usuarios = new List<Usuario>();

            SqlParameter paramNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 45);
            SqlParameter paramApellido = new SqlParameter("@apellido", SqlDbType.VarChar, 45);
            SqlParameter paramDni = new SqlParameter("@dni", SqlDbType.Int);
            SqlParameter paramRolId = new SqlParameter("@rol_id", SqlDbType.Int);
            SqlParameter paramActivo = new SqlParameter("@activo", SqlDbType.Int);

            paramNombre.Value = (object)nombre ?? DBNull.Value;
            paramApellido.Value = (object)apellido ?? DBNull.Value;
            paramDni.Value = dni.HasValue ? (object)dni.Value : DBNull.Value;
            paramRolId.Value = rolId.HasValue ? (object)rolId.Value : DBNull.Value;
            paramActivo.Value = activo.HasValue ? (object)activo.Value : DBNull.Value;

            SqlParameter[] parametros = { paramNombre, paramApellido, paramDni, paramRolId, paramActivo };

            DataTable tabla = conexion.LeerPorStoreProcedure("SP_BUSCAR_USUARIOS", parametros);

            if (tabla == null) return usuarios;

            foreach (DataRow fila in tabla.Rows)
            {
                Rol rol = new Rol(
                    Convert.ToInt32(fila["rol_id"]),
                    fila["nombreRol"].ToString(),
                    fila["descripcion"].ToString()
                );

                Usuario usuario = new Usuario(
                    Convert.ToInt32(fila["id_usuario"]),
                    fila["nombre"].ToString(),
                    fila["apellido"].ToString(),
                    fila["email"].ToString(),
                    "",
                    Convert.ToInt32(fila["dni"]),
                    rol
                );

                usuario.Activo = Convert.ToInt32(fila["activo"]) == 1;

                usuarios.Add(usuario);
            }

            return usuarios;
        }
        public bool ActualizarUsuario(Usuario usuario)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@id_usuario", usuario.IdUsuario),
                conexion.crearParametro("@rol_id",     usuario.RolId),
                conexion.crearParametro("@nombre",     usuario.Nombre),
                conexion.crearParametro("@apellido",   usuario.Apellido),
                conexion.crearParametro("@email",      usuario.Email),
                conexion.crearParametro("@dni",        usuario.Dni),
                conexion.crearParametro("@activo",     usuario.Activo ? 1 : 0)
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("SP_ACTUALIZAR_USUARIO", parametros);
            return filasAfectadas > 0;
        }

        public bool EliminarUsuario(int idUsuario)
        {
                    SqlParameter[] parametros =
                    {
                conexion.crearParametro("@id_usuario", idUsuario)
               };

                    int filasAfectadas = conexion.EscribirPorStoreProcedure("SP_ELIMINAR_USUARIO", parametros);
                    return filasAfectadas > 0;
        }

        public bool ExisteDni(int dni)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@dni", dni)
            };

            DataTable tabla = conexion.LeerPorStoreProcedure("SP_EXISTE_DNI_USUARIO", parametros);

            return tabla != null && tabla.Rows.Count > 0 && Convert.ToInt32(tabla.Rows[0][0]) > 0;
        }


    }


}

