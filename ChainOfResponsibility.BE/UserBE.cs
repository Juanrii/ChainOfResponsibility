using ChainOfResponsibility.Interfaces;

namespace ChainOfResponsibility.BE
{
    public class UserBE : IUser
    {
        #region Propiedades
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        #endregion
    }
}
