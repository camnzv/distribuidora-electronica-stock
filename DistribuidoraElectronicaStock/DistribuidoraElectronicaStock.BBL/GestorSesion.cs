using DistribuidoraElectronicaStock.BBL.Excepciones;
using DistribuidoraElectronicaStock.BBL.Helpers;
using DistribuidoraElectronicaStock.BBL.Permisos;
using DistribuidoraElectronicaStock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.BBL
{
    // se añade un resultado al login en lugar de un boolean para dar aviso si la cuenta esta inactiva
    public enum ResultadoLogin
    {
        Exitoso,
        CredencialesInvalidas,
        UsuarioInactivo
    }

    /// <summary>
    /// se hace uso de singleton para gestionar  la sesion activa del sistema
    /// 
    /// </summary>
    public sealed class GestorSesion
    {
        private static GestorSesion _instancia;
        private static readonly object _lock = new object();
        private Usuario _usuarioActual;
        private GrupoPermisos _permisosActuales;


        private GestorSesion() { }

        public static GestorSesion RecuperarInstancia()
        {
            if (_instancia == null)
            {
                lock (_lock)
                {
                    if (_instancia == null)
                        _instancia = new GestorSesion();
                }
            }
            return _instancia;
        }

        public Usuario UsuarioActual => _usuarioActual;
        public bool HaySesionActiva => _usuarioActual != null;
        public GrupoPermisos PermisosActuales => _permisosActuales; //los permios que tiene el usuario

        /// <summary>
        /// Autentica al usuario y devuelve el resultado del intento de login.
        /// </summary>
        public ResultadoLogin IniciarSesion(int dni, string password)
        {
            // Hashea la contraseña  antes de comparar 
            string passwordHash = PasswordHelper.HashPassword(password);

            var gestor = new GestorUsuarios();
            Usuario usuario = gestor.Autenticar(dni, passwordHash);

            if (usuario == null)
                throw new CredencialesInvalidasException();


            if (!usuario.Activo)
                throw new UsuarioInactivoException();


            _usuarioActual = usuario;
            _permisosActuales = new GestorPermisos()
                .RecuperarPermisosPorRol(usuario.Rol.IdRol);

            return ResultadoLogin.Exitoso;
        }

        public void CerrarSesion()
        {
            _usuarioActual = null;
            _permisosActuales = null;
        }
    }
}





