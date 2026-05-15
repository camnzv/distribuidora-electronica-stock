using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistribuidoraElectronicaStock.Entidades;


namespace DistribuidoraElectronicaStock.BBL
{
    public class GestorUsuarios
    {
        /// <summary>
        /// devuelve a los usuarios hardcodeados por ahora
        /// </summary>
        private List<Usuario> RecuperarUsuariosMock()   // luego  en lugar de esto se va llamar a una clase en DAL que se conecte a la bd 
        {
            var rolAdmin = new Rol(1, "Administrador", "Gestión de usuarios");
            var rolVendedor = new Rol(2, "Vendedor", "Ventas y clientes");
            var rolStock = new Rol(3, "Encargado de Inventario", "Inventario y logística");
            var rolGerente = new Rol(4, "Gerente", "Reportes y estadísticas");

            return new List<Usuario>
            {
                new Usuario(1, "Admin",  "Sistema",   "admin@distri.com",  "admin123", 11111111, rolAdmin),
                new Usuario(2, "Juan",   "Pérez",     "jperez@distri.com", "pass456",  22222222, rolVendedor),
                new Usuario(3, "María",  "González",  "mgl@distri.com",    "pass789",  33333333, rolStock),
                new Usuario(4, "Carlos", "Rodríguez", "crod@distri.com",   "gerente1", 44444444, rolGerente),
            };
        }

        /// <summary>
        /// busca al uusuario por dni y contraseña
        /// se devuelve null si las credenciales de inicio son erroreneas o  el usuario no esta activo
        /// </summary>
        public Usuario Autenticar(int dni, string password)
        {
            List<Usuario> usuarios = RecuperarUsuariosMock();

            return usuarios.Find(u =>
                u.Dni == dni &&
                u.Password == password &&
                u.Activo);
        }
    }
}
