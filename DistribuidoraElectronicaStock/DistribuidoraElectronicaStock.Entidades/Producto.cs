using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{
    public class Producto
    {
        private int _idProducto;
        private string _nombre;
        private decimal _precio;
        private int _stock;

        public int IdProducto
        {
            get => _idProducto;
            set => _idProducto = value;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public decimal Precio
        {
            get => _precio;
            set => _precio = value;
        }

        public int Stock
        {
            get => _stock;
            set => _stock = value;
        }
    }
}
