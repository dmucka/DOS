using DOS_DAL;
using DOS_DAL.Models;
using DOS_DAL.Hashing;
using System.Linq;

namespace DOS_BL.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(DOSContext dbcontext) : base(dbcontext)
        {
        }

        public (bool Success, User user) AuthenticateUser(string username, string password)
        {
            var foundUser = AsQueryable().FirstOrDefault(user => user.Username == username);
            if (foundUser is null)
                return (false, null);

            return (PasswordHasher.Check(foundUser.Password, password), foundUser);
        }
    }
}
