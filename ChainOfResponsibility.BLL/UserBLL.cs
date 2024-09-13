using ChainOfResponsibility.BE;
using System;
using ChainOfResponsibility.Services;
using ChainOfResponsibility.MPP;
using ChainOfResponsibility.Services.Authentication;
using ChainOfResponsibility.Services.Session;

namespace ChainOfResponsibility.BLL
{
    public class UserBLL
    {
        public static void Login(UserBE user)
        {
            try
            {
                AuthService.Run(user);

                Session.Login(user);
            }
            catch (Exception ex) { throw ex; }
        }

        public static void Registrar(UserBE user)
        {
            try
            {
                user.Activo   = true;
                user.Password = SecurityManager.Run(user.Password);

                UserMPP.Registrar(user);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
