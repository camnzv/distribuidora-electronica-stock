using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{

    public class Permiso
    {
        private int _idPermiso;
        private string _nombre;
        private string _descripcion;

        public int IdPermiso { get => _idPermiso; set => _idPermiso = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        public Permiso() { }
        public Permiso(int id, string nombre, string descripcion)
        {
            _idPermiso = id;
            _nombre = nombre;
            _descripcion = descripcion;
        }
    }
}
