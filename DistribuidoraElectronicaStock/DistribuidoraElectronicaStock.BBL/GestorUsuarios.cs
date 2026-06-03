using DistribuidoraElectronicaStock.DAL;
using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DistribuidoraElectronicaStock.BBL
{
    public class GestorUsuarios
    {
        private UsuarioDAL usuarioDAL;

        public GestorUsuarios()
        {
            usuarioDAL = new UsuarioDAL();
        }

        public Usuario Autenticar(int dni, string password)
        {
            return usuarioDAL.ObtenerPorDniYPassword(dni, password);
        }
       
    }
}
