using login_system.Models;

namespace login_system.Repository
{
    public interface IUserRepository
    {
        UserModel RegisterUser(UserModel user);

        UserModel SearchUser(string email);

        UserModel SearchById(int id);

        UserModel ChangePassword(ChangePasswordModel changePasswordModel);

        bool DeleteUser(int id);
    }
}
