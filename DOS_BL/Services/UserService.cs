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

        public Task<bool> InsertAsync(CreateUserDTO dto)
        {
            var item = _mapper.Map<User>(dto);
            var role = _dbContext.Roles.FirstOrDefault(role => role.Id == dto.RoleId);
            item.Password = PasswordHasher.Hash(dto.Password);
            item.Role = role;
            return InsertAsync(item);
        }

        public async Task<bool> UpdateAsync(EditUserDTO dto)
        {
            var user = await GetAsync(dto.Id);

            user = _mapper.Map(dto, user);
            
            // do not change the entity when password is null
            if (dto.Password is not null)
                user.Password = PasswordHasher.Hash(dto.Password);

            // do not change the entity if we didnt change the role
            if (dto.RoleId != user.Role.Id)
            {
                var role = _dbContext.Roles.FirstOrDefault(role => role.Id == dto.RoleId);
                user.Role = role;
            }

            return await UpdateAsync(user);
        }

        public async Task<EditUserDTO> GetSafeUserAsync(int id)
        {
            return _mapper.Map<EditUserDTO>(await GetAsync(id));
        }
    }
}
