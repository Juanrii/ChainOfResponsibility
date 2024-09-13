using ChainOfResponsibility.BE;
using ChainOfResponsibility.Interfaces;
using ChainOfResponsibility.MPP;
using System;

namespace ChainOfResponsibility.Services.Authentication.Handlers
{
    public class CredentialVerificationHandler : IAuthenticationHandler
    {
        private IAuthenticationHandler _nextHandler;

        public IAuthenticationHandler SetNext(IAuthenticationHandler next)
        {
            _nextHandler = next;
            return _nextHandler;
        }

        public void Handle(IUser user)
        {
            if (!VerificarCredenciales(user))
            {
                throw new UnauthorizedAccessException("Credenciales incorrectas.");
            }

            _nextHandler?.Handle(user);
        }

        private bool VerificarCredenciales(IUser user)
        {
            user.Password = SecurityManager.Run(user.Password);

            UserBE userExistente = UserMPP.BuscarUsuario((UserBE)user);

            return userExistente != null;
        }
    }
}
