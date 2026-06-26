using DistribuidoraElectronicaStock.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DistribuidoraElectronicaStock.DAL
{
    public class ClienteDAL
    {
        // instancia de Conexion que maneja toda la comunicación con SQL Server
        private Conexion _conexion;

        public ClienteDAL()
        {
            // instancio la conexion al crear el DAL
            _conexion = new Conexion();
        }

        public List<Cliente> ObtenerClientes()
        {
            // lista que voy a devolver con los clientes
            List<Cliente> lista = new List<Cliente>();

            // llamo al stored procedure que trae todos los clientes activos
            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_OBTENER_CLIENTES");

            if (tabla != null)
            {
                // recorro cada fila del resultado y creo un objeto Cliente
                foreach (DataRow fila in tabla.Rows)
                {
                    Cliente c = new Cliente(
                        (int)fila["id_cliente"],
                        fila["cuit"].ToString(),
                        fila["razon_social"].ToString(),
                        fila["email"].ToString(),
                        fila["telefono"].ToString(),
                        (int)fila["activo"] == 1  // convierto 1/0 a true/false
                    );
                    lista.Add(c);
                }
            }

            return lista;
        }

        public List<Cliente> BuscarCliente(string busqueda)
        {
            List<Cliente> lista = new List<Cliente>();

            // armo el parámetro que recibe el stored procedure
            // busca por CUIT o razón social con LIKE
            SqlParameter[] parametros = new SqlParameter[]
            {
                _conexion.crearParametro("@busqueda", busqueda)
            };

            // llamo al stored procedure pasándole el parámetro de búsqueda
            DataTable tabla = _conexion.LeerPorStoreProcedure("SP_BUSCAR_CLIENTE", parametros);

            if (tabla != null)
            {
                // igual que ObtenerClientes — recorro y creo objetos Cliente
                foreach (DataRow fila in tabla.Rows)
                {
                    Cliente c = new Cliente(
                        (int)fila["id_cliente"],
                        fila["cuit"].ToString(),
                        fila["razon_social"].ToString(),
                        fila["email"].ToString(),
                        fila["telefono"].ToString(),
                        (int)fila["activo"] == 1
                    );
                    lista.Add(c);
                }
            }

            return lista;
        }

        public int AgregarCliente(Cliente cliente)
        {
            // armo los parámetros con los datos del cliente nuevo
            // no paso id_cliente porque es IDENTITY — lo genera SQL automáticamente
            SqlParameter[] parametros = new SqlParameter[]
            {
                _conexion.crearParametro("@cuit", cliente.Cuit),
                _conexion.crearParametro("@razon_social", cliente.RazonSocial),
                _conexion.crearParametro("@email", cliente.Email),
                _conexion.crearParametro("@telefono", cliente.Telefono)
            };

            // EscribirPorStoreProcedure devuelve las filas afectadas
            // si devuelve > 0 el insert fue exitoso
            return _conexion.EscribirPorStoreProcedure("SP_AGREGAR_CLIENTE", parametros);
        }

        public int EditarCliente(Cliente cliente)
        {
            // acá sí paso el id_cliente para que SQL sepa qué registro actualizar
            SqlParameter[] parametros = new SqlParameter[]
            {
                _conexion.crearParametro("@id_cliente", cliente.IdCliente),
                _conexion.crearParametro("@cuit", cliente.Cuit),
                _conexion.crearParametro("@razon_social", cliente.RazonSocial),
                _conexion.crearParametro("@email", cliente.Email),
                _conexion.crearParametro("@telefono", cliente.Telefono)
            };

            // devuelve filas afectadas — si devuelve > 0 el update fue exitoso
            return _conexion.EscribirPorStoreProcedure("SP_EDITAR_CLIENTE", parametros);
        }

        public int DesactivarCliente(int idCliente)
        {
            // solo necesito el id para saber qué cliente desactivar
            // el stored procedure hace UPDATE activo = 0
            // no borra el registro — solo lo marca como inactivo
            SqlParameter[] parametros = new SqlParameter[]
            {
                _conexion.crearParametro("@id_cliente", idCliente)
            };

            return _conexion.EscribirPorStoreProcedure("SP_DESACTIVAR_CLIENTE", parametros);
        }



        public bool ExisteCuit(string cuit)
        {
            SqlParameter[] parametros =
            {
        _conexion.crearParametro("@cuit", cuit)
        };

            DataTable tabla = _conexion.LeerPorStoreProcedure(
                "SP_VERIFICAR_CUIT_CLIENTE", parametros);

            return tabla != null && tabla.Rows.Count > 0;
        }
    }
}