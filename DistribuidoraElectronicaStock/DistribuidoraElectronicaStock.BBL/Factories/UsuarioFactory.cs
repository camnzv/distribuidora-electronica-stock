using DistribuidoraElectronicaStock.BBL.Helpers;
using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL.Factories
{
    /// Factory Method para la creación de usuarios.
    public static class UsuarioFactory
    {

        public static Usuario CrearUsuario(
            string nombre,
            string apellido,
            string email,
            string password,
            int dni,
            Rol rol)
        {
            // Validaciones de negocio centralizadas
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");

            // Hashea la contraseña antes de crear el usuario
            string passwordHash = PasswordHelper.HashPassword(password);

            return new Usuario(
                0,
                nombre.Trim(),
                apellido.Trim(),
                email.Trim(),
                passwordHash,
                dni,
                rol
            );
        }
    }
}

