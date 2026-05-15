using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{
    public class Proveedor
    {
        private int _idProveedor;
        private ProveedorTipo _proveedorTipo;
        private string _cuit;//modelarlo como string o int mejor?
        private string _razonSocial;
        private string _email;
        private string _telefono;
        private bool _activo;

        public int IdProveedor
        {
            get => _idProveedor;
            set => _idProveedor = value;
        }
        public ProveedorTipo ProveedorTipo
        {
            get => _proveedorTipo;
            set => _proveedorTipo = value;
        }
        public string Cuit
        {
            get => _cuit;
            set => _cuit = value;
        }
        public string RazonSocial
        {
            get => _razonSocial;
            set => _razonSocial = value;
        }
        public string Email
        {
            get => _email;
            set => _email = value;
        }
        public string Telefono
        {
            get => _telefono;
            set => _telefono = value;
        }
        public bool Activo
        {
            get => _activo;
            set => _activo = value;
        }

        public Proveedor() { }

        public Proveedor(int idProveedor, ProveedorTipo proveedorTipo, string cuit, string razonSocial, string email, string telefono, bool activo)
        {
            _idProveedor = idProveedor;
            _proveedorTipo = proveedorTipo;
            _cuit = cuit;
            _razonSocial = razonSocial;
            _email = email;
            _telefono = telefono;
            _activo = activo;
        }

        public override string ToString()
        {
            return _razonSocial;
        }
    }
}
