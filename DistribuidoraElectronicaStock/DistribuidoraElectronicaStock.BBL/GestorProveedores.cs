using DistribuidoraElectronicaStock.DAL;
using DistribuidoraElectronicaStock.Entidades;
using System.Collections.Generic;

namespace DistribuidoraElectronicaStock.BBL
{
    public class GestorProveedores
    {
        private ProveedorDAL _proveedorDAL;

        public GestorProveedores()
        {
            _proveedorDAL = new ProveedorDAL();
        }

        public List<ProveedorTipo> ObtenerTiposProveedor()
        {
            return _proveedorDAL.ObtenerTiposProveedor();
        }

        public List<Proveedor> ObtenerProveedores()
        {
            return _proveedorDAL.ObtenerProveedores();
        }

        public List<Proveedor> BuscarProveedor(string busqueda)
        {
            if (string.IsNullOrWhiteSpace(busqueda))
                return _proveedorDAL.ObtenerProveedores(); // si no escribe nada trae todos

            return _proveedorDAL.BuscarProveedor(busqueda);
        }

        public int AgregarProveedor(Proveedor proveedor)
        {
            if (string.IsNullOrWhiteSpace(proveedor.Cuit))
                return -1;

            if (string.IsNullOrWhiteSpace(proveedor.RazonSocial))
                return -1;

            if (proveedor.ProveedorTipo == null)
                return -1;

            return _proveedorDAL.AgregarProveedor(proveedor);
        }

        public int EditarProveedor(Proveedor proveedor)
        {
            if (proveedor.IdProveedor <= 0)
                return -1;

            if (string.IsNullOrWhiteSpace(proveedor.Cuit))
                return -1;

            if (string.IsNullOrWhiteSpace(proveedor.RazonSocial))
                return -1;

            if (proveedor.ProveedorTipo == null)
                return -1;

            return _proveedorDAL.EditarProveedor(proveedor);
        }

        public int DesactivarProveedor(int idProveedor)
        {
            if (idProveedor <= 0)
                return -1;

            return _proveedorDAL.DesactivarProveedor(idProveedor);
        }
    }
}