using DistribuidoraElectronicaStock.DAL;
using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL
{
    public class GestorCategorias
    {

        private CategoriaProductoDAL _categoriaDAL = new CategoriaProductoDAL();

        public List<CategoriaProducto> RecuperarTodas()
        {
            return _categoriaDAL.ObtenerTodas();
        }

    }
}
