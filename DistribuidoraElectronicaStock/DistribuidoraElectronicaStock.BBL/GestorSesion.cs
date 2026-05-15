using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistribuidoraElectronicaStock.Entidades;

namespace DistribuidoraElectronicaStock.BBL
{
   


        /// <summary>
        /// se hace uso de singleton para gestionar  la sesion activa del sistema
        /// 
        /// </summary>
        public sealed class GestorSesion
        {
            private static GestorSesion _instancia;
            private static readonly object _lock = new object();
            private Usuario _usuarioActual;

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


            /// autenticacion  usando dni y contraseña

            public bool IniciarSesion(int dni, string password)
            {
                var gestor = new GestorUsuarios();
                _usuarioActual = gestor.Autenticar(dni, password);
                return _usuarioActual != null;
            }

            public void CerrarSesion()
            {
                _usuarioActual = null;
            }
        }


    }


