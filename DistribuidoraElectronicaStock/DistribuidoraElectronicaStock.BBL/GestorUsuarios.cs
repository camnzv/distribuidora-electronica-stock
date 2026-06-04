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

            public bool AgregarUsuario(Usuario usuario)
            {
                int filasAfectadas = usuarioDAL.AgregarUsuario(usuario);
                return filasAfectadas > 0;
            }

        public List<Usuario> BuscarUsuarios(string nombre = null, string apellido = null,
                                 int? dni = null, int? rolId = null, int? activo = null)
        {
            return usuarioDAL.BuscarUsuarios(nombre, apellido, dni, rolId, activo);
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            return new UsuarioDAL().ActualizarUsuario(usuario);
        }

        public bool EliminarUsuario(int idUsuario)
        {
            return new UsuarioDAL().EliminarUsuario(idUsuario);
        }
    }
    }

