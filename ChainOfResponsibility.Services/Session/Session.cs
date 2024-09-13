using ChainOfResponsibility.Interfaces;
using System;

namespace ChainOfResponsibility.Services.Session
{
    public class Session
    {
        #region Propiedades
        static private Session _session;
        private IUser _user { get; set; }
        #endregion

        #region Contructor
        private Session() { }
        #endregion

        #region Metodos
        public static void Login(IUser user)
        {
            try
            {
                if (_session == null)
                {
                    _session        = new Session();
                    _session._user  = user;
                }
                else
                    throw new SessionException("Sesion ya iniciada.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Logout()
        {
            try
            {
                if (_session != null) _session = null;
                else throw new SessionException("La sesion no esta iniciada");
            }
            catch (SessionException ex)
            {
                throw ex;
            }
        }

        public static Session GetSession()
        {
            return _session ?? null;
        }

        public static IUser GetUsuario()
        {
            try
            {
                return _session._user;
            }
            catch (SessionException ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
