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
        private string _nombre;
        private string _cuit;
        private string _telefono;
        private bool _activo;

        public int IdCliente
        {
            get => _idCliente;
            set => _idCliente = value;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public string Cuit
        {
            get => _cuit;
            set => _cuit = value;
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

        public Cliente() { }

        public Cliente(int idCliente, string nombre,
                       string cuit, string telefono, bool activo)
        {
            _idCliente = idCliente;
            _nombre = nombre;
            _cuit = cuit;
            _telefono = telefono;
            _activo = activo;
        }
    }
}
