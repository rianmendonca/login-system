using login_system.Models;

namespace login_system.Helper
{
    public interface IUserSession
    {
        void CreateSession(UserModel user);
        void RemoveSession();
        UserModel SearchSession();
    }
}
