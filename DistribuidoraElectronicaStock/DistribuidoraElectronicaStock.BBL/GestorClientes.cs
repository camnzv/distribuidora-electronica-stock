using DistribuidoraElectronicaStock.DAL;
using DistribuidoraElectronicaStock.Entidades;
using System.Collections.Generic;

namespace DistribuidoraElectronicaStock.BBL
{
    public class GestorClientes
    {
        private ClienteDAL _clienteDAL;

        public GestorClientes()
        {
            _clienteDAL = new ClienteDAL();
        }

        public List<Cliente> ObtenerClientes()
        {
            return _clienteDAL.ObtenerClientes();
        }

        public List<Cliente> BuscarCliente(string busqueda)
        {
            if (string.IsNullOrWhiteSpace(busqueda))
                return _clienteDAL.ObtenerClientes(); // si no escribe nada trae todos

            return _clienteDAL.BuscarCliente(busqueda);
        }

        public int AgregarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Cuit))
                return -1;

            if (string.IsNullOrWhiteSpace(cliente.RazonSocial))
                return -1;

            return _clienteDAL.AgregarCliente(cliente);
        }

        public int EditarCliente(Cliente cliente)
        {
            if (cliente.IdCliente <= 0)
                return -1;

            if (string.IsNullOrWhiteSpace(cliente.Cuit))
                return -1;

            if (string.IsNullOrWhiteSpace(cliente.RazonSocial))
                return -1;

            return _clienteDAL.EditarCliente(cliente);
        }

        public int DesactivarCliente(int idCliente)
        {
            if (idCliente <= 0)
                return -1;

            return _clienteDAL.DesactivarCliente(idCliente);
        }
    }
}