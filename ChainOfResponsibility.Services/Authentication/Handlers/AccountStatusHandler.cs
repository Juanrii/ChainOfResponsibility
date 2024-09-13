using ChainOfResponsibility.BE;
using ChainOfResponsibility.Interfaces;
using ChainOfResponsibility.MPP;
using System;

namespace ChainOfResponsibility.Services.Authentication.Handlers
{
    public class AccountStatusHandler : IAuthenticationHandler
    {
        private IAuthenticationHandler _nextHandler;

        public IAuthenticationHandler SetNext(IAuthenticationHandler next)
        {
            _nextHandler = next;
            return _nextHandler;
        }

        public void Handle(IUser user)
        {
            if (!UsuarioActivo(user))
            {
                _nextHandler = null;
                throw new UnauthorizedAccessException($"La cuenta del usuario {user.Username} esta inactiva.");
            } 
           
            _nextHandler?.Handle(user);
        }

        private bool UsuarioActivo(IUser user)
        {
            return UserMPP.UsuarioActivo((UserBE)user);
        }
    }

}
