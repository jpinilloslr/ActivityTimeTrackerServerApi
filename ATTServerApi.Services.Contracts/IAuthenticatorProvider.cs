

using ATTServerApi.Model;

namespace ATTServerApi.Services.Contracts
{
    public interface IAuthenticatorProvider
    {
        User Login(string username, string password);
        void Logout();
    }
}
