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
        private CategoriaProducto _categoriaProducto;
        private string _nombre;
        private decimal _precioCompra;
        private decimal _precioVenta;
        private float _iva;
        private int _stockActual;
        private int _stockMinimo;
        private string _codigo;
        private bool _activo;

        public int IdProducto
        {
            get => _idProducto;
            set => _idProducto = value;
        }

        public CategoriaProducto CategoriaProducto 
        {
            get => _categoriaProducto;
            set => _categoriaProducto = value;
        }
        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }
        public decimal PrecioCompra
        {
            get => _precioCompra;
            set => _precioCompra = value;
        }
        public decimal PrecioVenta
        {
            get => _precioVenta;
            set => _precioVenta = value;
        }
        public float Iva
        {
            get => _iva;
            set => _iva = value;
        }
        public int StockActual
        {
            get => _stockActual;
            set => _stockActual = value;
        }
        public int StockMinimo
        {
            get => _stockMinimo;
            set => _stockMinimo = value;
        }
        public string Codigo
        {
            get => _codigo;
            set => _codigo = value;
        }
        public bool Activo
        {
            get => _activo;
            set => _activo = value;
        }

        public Producto() { }
        public Producto(int idProducto, CategoriaProducto categoriaProducto ,string nombre, decimal precioCompra, decimal precioVenta, float iva, int stockActual, int stockMinimo, string codigo, bool activo)
        {
            _idProducto = idProducto;
            _categoriaProducto = categoriaProducto;
            _nombre = nombre;
            _precioCompra = precioCompra;
            _precioVenta = precioVenta;
            _iva = iva;
            _stockActual = stockActual;
            _stockMinimo = stockMinimo;
            _codigo = codigo;
            _activo = activo;
        }

        public override string ToString()
        {
            return $"[{_codigo}] {_nombre}";
        }
    }
}
