using DOS_DAL;
using DOS_DAL.Models;
using DOS_DAL.Hashing;
using System.Linq;
using System.Threading.Tasks;
using DOS_BL.DataObjects;
using DOS_BL.Queries;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DOS_BL.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }

        public async Task<(bool Success, User User)> AuthenticateUser(string username, string password)
        {
            var foundUser = await AsQueryable().WithRoles().GetByNameAsync(username);
            if (foundUser is null)
                return (false, null);

            return (PasswordHasher.Check(foundUser.Password, password), foundUser);
        }

        public async Task<bool> InsertAsync(CreateUserDTO dto)
        {
            var item = _mapper.Map<User>(dto);

            item.Password = PasswordHasher.Hash(dto.Password);

            var role = await _dbContext.Roles.FindAsync(dto.RoleId);
            item.Role = role;

            return await InsertAsync(item);
        }

        public async Task<bool> UpdateAsync(EditUserDTO dto)
        {
            var user = await AsQueryable().WithRoles().GetByIdAsync(dto.Id);

            user = _mapper.Map(dto, user);
            
            // do not change the entity when password is null
            if (dto.Password is not null)
                user.Password = PasswordHasher.Hash(dto.Password);

            // do not change the entity if we didnt change the role
            if (dto.RoleId != user.Role.Id)
            {
                var role = await _dbContext.Roles.FindAsync(dto.RoleId);
                user.Role = role;
            }

            return await UpdateAsync(user);
        }

        public async Task<EditUserDTO> GetSafeUserAsync(int id)
        {
            return _mapper.Map<EditUserDTO>(await AsQueryable().WithRoles().GetByIdAsync(id));
        }
    }
}
