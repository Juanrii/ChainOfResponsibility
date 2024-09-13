
namespace ChainOfResponsibility.Interfaces
{
    public interface IUser
    {
        #region Propiedades
        string Email { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        bool Activo { get; set; }
        #endregion
    }
}
