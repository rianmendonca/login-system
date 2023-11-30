using login_system.Models;

namespace login_system.Repository
{
    public interface IUserRepository
    {
        UserModel RegisterUser(UserModel user);
    }
}
