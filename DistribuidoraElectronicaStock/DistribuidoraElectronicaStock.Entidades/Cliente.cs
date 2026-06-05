using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{

    public class Cliente
    {
        private int _idCliente;
        private string _cuit;
        private string _razonSocial;
        private string _email;
        private string _telefono;
        private bool _activo;

        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public string Cuit { get => _cuit; set => _cuit = value; }
        public string RazonSocial { get => _razonSocial; set => _razonSocial = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public bool Activo { get => _activo; set => _activo = value; }

        public Cliente() { }

        public Cliente(int idCliente, string cuit, string razonSocial,
                       string email, string telefono, bool activo)
        {
            _idCliente = idCliente;
            _cuit = cuit;
            _razonSocial = razonSocial;
            _email = email;
            _telefono = telefono;
            _activo = activo;
        }
    }
}
