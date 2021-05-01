using DOS_DAL;
using DOS_DAL.Models;
using DOS_DAL.Hashing;
using System.Linq;
using System.Threading.Tasks;
using DOS_BL.DataObjects;
using AutoMapper;

namespace DOS_BL.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
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

        public Task<bool> InsertAsync(CreateUserDTO user)
        {
            var item = _mapper.Map<User>(user);
            var role = _dbContext.Roles.FirstOrDefault(role => role.Id == user.RoleId);
            item.Password = PasswordHasher.Hash(user.Password);
            item.Role = role;
            return InsertAsync(item);
        }
    }
}
