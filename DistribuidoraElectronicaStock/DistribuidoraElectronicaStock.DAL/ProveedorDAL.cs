using DistribuidoraElectronicaStock.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DistribuidoraElectronicaStock.DAL
{
    public class ProveedorDAL
    {
        // instancia de Conexion que maneja toda la comunicación con SQL Server
        private Conexion _conexion;

        public ProveedorDAL()
        {
            // instancio la conexion al crear el DAL
            _conexion = new Conexion();
        }


        public List<Proveedor> ObtenerProveedores()
        {
            // lista que voy a devolver con los proveedores
            List<Proveedor> lista = new List<Proveedor>();

            // llamo al stored procedure que trae todos los proveedores activos
            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_OBTENER_PROVEEDORES");

            if (tabla != null)
            {
                // recorro cada fila del resultado y creo un objeto Proveedor
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(ParsearProveedor(fila));
                }
            }

            return lista;
        }

        public List<ProveedorTipo> ObtenerTiposProveedor()
        {
            List<ProveedorTipo> lista = new List<ProveedorTipo>();

            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_OBTENER_TIPOS_PROVEEDOR");

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    ProveedorTipo pt = new ProveedorTipo(
                        (int)fila["id_proveedor_tipo"],
                        fila["tipo"].ToString(),
                        fila["descripcion"].ToString()
                    );
                    lista.Add(pt);
                }
            }

            return lista;
        }

        public List<Proveedor> BuscarProveedor(string busqueda)
        {
            List<Proveedor> lista = new List<Proveedor>();

            // busca por CUIT o razon socual con LIKE
            SqlParameter[] parametros = new SqlParameter[]
            {
                _conexion.crearParametro("@busqueda", busqueda)
            };

            // llamo al stored procedure pasandole el parametro de busqueda
            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_BUSCAR_PROVEEDOR", parametros);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(ParsearProveedor(fila));
                }
            }

            return lista;
        }

        public int AgregarProveedor(Proveedor proveedor)
        {
            // no paso id_proveedor porque se autogenera (identity)
            SqlParameter[] parametros = new SqlParameter[]
            {
                _conexion.crearParametro("@proveedor_tipo_id", proveedor.ProveedorTipo.IdProveedorTipo),
                _conexion.crearParametro("@cuit",              proveedor.Cuit),
                _conexion.crearParametro("@razon_social",      proveedor.RazonSocial),
                _conexion.crearParametro("@email",             proveedor.Email),
                _conexion.crearParametro("@telefono",          proveedor.Telefono)
            };

            //  devuelve las filas afectadas
            return _conexion.EscribirPorStoreProcedure("SP_AGREGAR_PROVEEDOR", parametros);
        }

        public int EditarProveedor(Proveedor proveedor)
        {
            // aca paso el id_proveedor para que SQL sepa que registro actualizar
            SqlParameter[] parametros = new SqlParameter[]
            {
                _conexion.crearParametro("@id_proveedor",      proveedor.IdProveedor),
                _conexion.crearParametro("@proveedor_tipo_id", proveedor.ProveedorTipo.IdProveedorTipo),
                _conexion.crearParametro("@cuit",              proveedor.Cuit),
                _conexion.crearParametro("@razon_social",      proveedor.RazonSocial),
                _conexion.crearParametro("@email",             proveedor.Email),
                _conexion.crearParametro("@telefono",          proveedor.Telefono)
            };

            // lo mismo que el de arriba
            return _conexion.EscribirPorStoreProcedure("SP_EDITAR_PROVEEDOR", parametros);
        }

        public int DesactivarProveedor(int idProveedor)
        {
            // solo se necesita el id para saber que proveedor desactivar
            SqlParameter[] parametros = new SqlParameter[]
            {
                _conexion.crearParametro("@id_proveedor", idProveedor)
            };

            return _conexion.EscribirPorStoreProcedure("SP_DESACTIVAR_PROVEEDOR", parametros);
        }

        // metodo para no repetir el parseo en ObtenerProveedores y BuscarProveedor
        public Proveedor ParsearProveedor(DataRow fila)
        {
            ProveedorTipo tipo = new ProveedorTipo(
                (int)fila["id_proveedor_tipo"],
                fila["tipo"].ToString(),
                fila["descripcion"].ToString()
            );

            return new Proveedor(
                (int)fila["id_proveedor"],
                tipo,
                fila["cuit"].ToString(),
                fila["razon_social"].ToString(),
                fila["email"].ToString(),
                fila["telefono"].ToString(),
                (int)fila["activo"] == 1  // convierte 1-0 a true-fdalse
            );
        }
    }
}