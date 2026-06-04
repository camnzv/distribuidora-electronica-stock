using DistribuidoraElectronicaStock.DAL;
using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DistribuidoraElectronicaStock.BBL
{
    public class GestorRoles
    {

        private RolDAL rolDAL = new RolDAL();

        public List<Rol> RecuperarTodos()
        {
            return rolDAL.ObtenerTodos();
        }
    }
}

