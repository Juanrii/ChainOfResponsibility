using ChainOfResponsibility.Interfaces;
using ChainOfResponsibility.Services.Email;
using Microsoft.VisualBasic;
using System;

namespace ChainOfResponsibility.Services.Authentication.Handlers
{
    public class TwoFactorAuthenticationHandler : IAuthenticationHandler
    {
        private IAuthenticationHandler _nextHandler;
        private static Random _random = new Random();

        public IAuthenticationHandler SetNext(IAuthenticationHandler next)
        {
            _nextHandler = next;
            return _nextHandler;
        }

        public void Handle(IUser user)
        {
            if (!Verificar2FA(user))
            {
                throw new UnauthorizedAccessException("Autenticación de dos factores fallida.");
            }

            _nextHandler?.Handle(user);
        }

        private bool Verificar2FA(IUser user)
        {
            string codigoVerificacion = GenerarCodigoVerificacion();

            EmailSender.RunMFA(user.Email, codigoVerificacion);

            string codigoIngresado = ObtenerCodigoDelUsuarioDesdeInputBox();

            return codigoVerificacion == codigoIngresado; 
        }

        private string GenerarCodigoVerificacion()
        {
            return _random.Next(100000, 999999).ToString();
        }

        private string ObtenerCodigoDelUsuarioDesdeInputBox()
        {
            string codigoIngresado = Interaction.InputBox(
                "Ingrese el código de verificación enviado a su correo:",
                "Verificación de Dos Factores",
                ""
            );

            if (string.IsNullOrEmpty(codigoIngresado))
            {
                throw new UnauthorizedAccessException("El usuario no ingresó el código de verificación.");
            }

            return codigoIngresado;
        }
    }
}
