using ChainOfResponsibility.Interfaces;
using ChainOfResponsibility.Services.Authentication.Handlers;
using System;

namespace ChainOfResponsibility.Services.Authentication
{
    public class AuthService
    {
        public static void Run(IUser user)
        {
            try
            {
                IAuthenticationHandler handler = new CredentialVerificationHandler();

                handler
                    .SetNext(new AccountStatusHandler())
                    .SetNext(new TwoFactorAuthenticationHandler());

                handler.Handle(user);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
