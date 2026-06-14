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

        public List<Producto> BuscarProductos(string nombre = null, string codigo = null,
                                               int? categoria = null, int? activo = null)
        {
            return _productoDAL.BuscarProductos(nombre, codigo, categoria, activo);
        }
    }
}
