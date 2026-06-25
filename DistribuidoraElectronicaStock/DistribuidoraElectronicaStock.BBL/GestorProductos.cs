using DistribuidoraElectronicaStock.DAL;
using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL
{
    public class GestorProductos
    {
        private ProductoDAL _productoDAL = new ProductoDAL();

        private List<IObservadorStock> _observadores = new List<IObservadorStock>();

        public List<Producto> BuscarProductos(string nombre = null, string codigo = null,
                                               int? categoria = null, int? activo = null)
        {
            return _productoDAL.BuscarProductos(nombre, codigo, categoria, activo);
        }

             public bool AgregarProducto(Producto producto)
        {
            int filasAfectadas = _productoDAL.AgregarProducto(producto);

            if (filasAfectadas > 0)
            {
                NotificarSiCorresponde(producto);
                return true;
            }
            return false;
        }

        public bool EditarProducto(Producto producto)
        {
            int filasAfectadas = _productoDAL.EditarProducto(producto);

            if (filasAfectadas > 0)
            {
                NotificarSiCorresponde(producto);
                return true;
            }
            return false;
        }

        public bool EliminarProducto(int idProducto)
        {
            int filasAfectadas = _productoDAL.EliminarProducto(idProducto);
            return filasAfectadas > 0;
        }



        //Gestion de observadores
        public void SuscribirObservador(IObservadorStock observador) => _observadores.Add(observador);

        public void DesuscribirObservador(IObservadorStock observador) => _observadores.Remove(observador);

        private void NotificarSiCorresponde(Producto producto)
        {
            if (producto.StockActual <= producto.StockMinimo)
                foreach (var obs in _observadores)
                    obs.NotificarBajoStock(producto);
        }

        
        public List<Producto> ObtenerProductosBajoStock()
        {
            var productos = _productoDAL.ObtenerBajoStock();

            //Notifica a todos los observadores suscritos
            foreach (var producto in productos)
                NotificarSiCorresponde(producto);

            return productos;
        }
    }
}
