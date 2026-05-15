using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{
    public class Usuario
    {
        private int _idUsuario;
        private int _rolId;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _password;
        private int _dni;
        private bool _activo;
        private Rol _rol;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int RolId { get => _rolId; set => _rolId = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public int Dni { get => _dni; set => _dni = value; }
        public bool Activo { get => _activo; set => _activo = value; }
        public Rol Rol { get => _rol; set => _rol = value; }

        public Usuario() { }

        public Usuario(int id, string nombre, string apellido,
                       string email, string password, int dni, Rol rol)
        {
            _idUsuario = id;
            _nombre = nombre;
            _apellido = apellido;
            _email = email;
            _password = password;
            _dni = dni;
            _rol = rol;
            _rolId = rol.IdRol;
            _activo = true;
        }

    }
}
