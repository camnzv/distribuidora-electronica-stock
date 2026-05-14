using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{
    public class ProveedorTipo
    {
        private int _idProveedorTipo; //atributos privados, propiedades public
        private string _tipo;
        private string _descripcion;


        public int IdProveedorTipo
        {
            get => _idProveedorTipo;
            set => _idProveedorTipo = value;
        }
        public string Tipo
        {
            get => _tipo;
            set => _tipo = value;
        }
        public string Descripcion
        {
            get => _descripcion;
            set => _descripcion = value;
        }

        public ProveedorTipo() { }

        public ProveedorTipo(int idProveedorTipo, string tipo, string descripcion)
        {
            _idProveedorTipo = idProveedorTipo;
            _tipo = tipo;
            _descripcion = descripcion;
        }

        public override string ToString()//DistribuidoraElectronicaStock.Entidades.ProveedorTipo
        {
            return _tipo;
        }
    }

}
