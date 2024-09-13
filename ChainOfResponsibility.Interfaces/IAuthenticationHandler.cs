
namespace ChainOfResponsibility.Interfaces
{
    public interface IAuthenticationHandler
    {
        void Handle(IUser user);
        IAuthenticationHandler SetNext(IAuthenticationHandler next);
    }
}
