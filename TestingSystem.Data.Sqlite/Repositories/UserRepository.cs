using Microsoft.EntityFrameworkCore;
using TestingSystem.Core.DTOs;
using TestingSystem.Core.Repositories;
using TestingSystem.Data.Sqlite.Entities;

namespace TestingSystem.Data.Sqlite.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDataDto?> GetUserById(int userId)
        {
            return await _context.Users
            .Where(u => u.Id == userId)
            .Select(u => new UserDataDto
            {
                Id = u.Id,
                Name = u.Name,
                PasswordHash = u.PasswordHash,
                PasswordSalt = u.PasswordSalt,
            })
            .AsNoTracking()
            .FirstOrDefaultAsync();
        }

        public async Task<UserDataDto?> GetUserByLogin(string login)
        {
            return await _context.Users
            .Where(u => u.Login == login)
            .Select(u => new UserDataDto
            {
                Id = u.Id,
                Name = u.Name,
                PasswordHash = u.PasswordHash,
                PasswordSalt = u.PasswordSalt,
            })
            .AsNoTracking()
            .FirstOrDefaultAsync();
        }

        public async Task<bool> LoginExists(string login)
        {
            return await _context.Users.AnyAsync(u => u.Login == login);
        }

        public async Task<UserDataDto> CreateUser(UserDataDto userDataDto)
        {
            var userEntity = new UserEntity
            {
                Name = userDataDto.Name,
                Login = userDataDto.Login,
                PasswordHash = userDataDto.PasswordHash,
                PasswordSalt = userDataDto.PasswordSalt,
            };


            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return new UserDataDto
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Login = userEntity.Login,
                PasswordHash = userEntity.PasswordHash,
                PasswordSalt = userEntity.PasswordSalt,
            };
        }

        //public async Task Update(User user)
        //{
        //    _context.Users.Update(user);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task Delete(User user)
        //{
        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();
        //}
    }
}