using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace ChainOfResponsibility.Services
{
    public class SecurityManager
    {
        private static UnicodeEncoding _ue;
        private static byte[] _bytes;
        private static MD5CryptoServiceProvider _md5;
        private static byte[] _hash;

        static public string Run(string str)
        {
            try
            {
                _ue = new UnicodeEncoding();

                _bytes = _ue.GetBytes(str);

                _md5 = new MD5CryptoServiceProvider();

                _hash = _md5.ComputeHash(_bytes);

                return Convert.ToBase64String(_hash);
            }
            catch (SecurityException)
            {
                throw new SecurityException("Ha ocurrido un error al encrirptar la contraseña.");
            }
        }
    }
}
