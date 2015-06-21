using ATTServerApi.Model;
using ATTServerApi.Services.Contracts;

namespace ATTServerApi.Services
{
    public class AuthenticatorProvider : IAuthenticatorProvider
    {
        public User Login(string username, string password)
        {
            
            User result = null;
            if (username == "joaquin" && password == "knockers")
            {
                result = new User() {Name = "Joaquin", Firstname = "Pinillos", Lastname = "La Rosa"};
            }
            return result;
        }

        public void Logout()
        {
            
        }
    }
}
