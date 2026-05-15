using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{
    public class CategoriaProducto
    {
        private int _idCategoriaProducto;
        private string _categoria;

        public int IdCategoriaProducto
        {
            get => _idCategoriaProducto;
            set => _idCategoriaProducto = value;
        }
        public string Categoria
        {
            get => _categoria;
            set => _categoria = value;
        }

        public CategoriaProducto() { }

        public CategoriaProducto(int idCategoriaProducto, string categoria)
        {
            _idCategoriaProducto = idCategoriaProducto;
            _categoria = categoria;
        }

        public override string ToString()
        {
            return _categoria;
        }
    }
}
