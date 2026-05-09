using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{
    public class Rol
    {
        private int _idRol;
        private string _nombre;
        private string _descripcion;

        public int IdRol { get => _idRol; set => _idRol = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        public Rol() { }
        public Rol(int id, string nombre, string descripcion)
        {
            _idRol = id;
            _nombre = nombre;
            _descripcion = descripcion;
        }
    }
}
