using DOS_DAL;
using DOS_DAL.Models;
using DOS_DAL.Hashing;
using System.Linq;
using System.Threading.Tasks;

namespace DOS_BL.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(DOSContext dbcontext) : base(dbcontext)
        {
        }

        public User GetByName(string username)
        {
            return AsQueryable().FirstOrDefault(user => user.Username == username);
        }

        public (bool Success, User User) AuthenticateUser(string username, string password)
        {
            var foundUser = GetByName(username);
            if (foundUser is null)
                return (false, null);

            return (PasswordHasher.Check(foundUser.Password, password), foundUser);
        }

        public Task<bool> CreateNewUser(User user)
        {
            //TODO: Add DTO mapping
        }
    }
}
