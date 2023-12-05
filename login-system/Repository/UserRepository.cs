using login_system.Data;
using login_system.Models;

namespace login_system.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public UserModel RegisterUser(UserModel user)
        {
            user.SetPasswordHash();
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool DeleteUser(int id)
        {
            UserModel user = SearchById(id);

            if (user == null) throw new Exception("Houve um erro na exclusão do cadastro.");

            _context.Users.Remove(user);
            _context.SaveChanges();

            return true;
        }

        public UserModel SearchUser(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public UserModel SearchById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public UserModel ChangePassword(ChangePasswordModel changePasswordModel)
        {
            UserModel user = SearchById(changePasswordModel.Id);

            if (user == null) throw new Exception("Houve um erro na alteração de senha.");

            if (!user.ValidatePassword(changePasswordModel.CurrentPassword)) throw new Exception("Senha atual não confere.");

            if (user.ValidatePassword(changePasswordModel.NewPassword)) throw new Exception("Nova senha deve ser diferente da atual.");

            user.SetNewSenha(changePasswordModel.NewPassword);

            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }
    }
}
