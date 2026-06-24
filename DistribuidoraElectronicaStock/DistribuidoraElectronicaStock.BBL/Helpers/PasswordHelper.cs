using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL.Helpers
{
    public static class PasswordHelper
    {


       
        /// Convierte una contraseña en texto plano a su hash SHA256.
       
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder resultado = new StringBuilder();
                foreach (byte b in bytes)
                    resultado.Append(b.ToString("x2"));

                return resultado.ToString();
            }
        }

       
        /// Verifica si una contraseña en texto plano coincide con el hash guardado.
        
        public static bool VerificarPassword(string passwordPlano, string hashGuardado)
        {
            string hashIngresado = HashPassword(passwordPlano);
            return hashIngresado == hashGuardado;
        }
    }
}

