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
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public UserModel SearchUser(string email)
        { 
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }
    }
}
