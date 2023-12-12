using ACCA_Backend.DataAccess.DTO;
using ACCA_Backend.DataAccess.DTO.DTOMapping;
using ACCA_Backend.DataAccess.Entities;
using ACCA_Backend.DataAccess.Repository.Context;
using ACCA_Backend.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ACCA_Backend.DataAccess.Repository
{
    public class UsersRepository : IUsersRepository
    {
        internal AccaSystemContext _context;
        public UsersRepository(AccaSystemContext context)
        {
            _context = context;
        }

        public async Task<Users> GetUser(int userId) =>
              await _context.Users
                 .Where(x => x.UserId == userId)
                 .FirstOrDefaultAsync();

        public async Task<Users> GetUserByEmailAndPassword(string email, string pass) =>
              await _context.Users
                .Where(x => x.Email == email && x.Password == pass)
                .FirstOrDefaultAsync();

        public async Task<List<Users>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task SaveUserAsync(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Users> PostUser(UsersDTO users)
        {
            var user = users.Map();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Users> UpdateUser(UsersDTO user)
        {
            var userUpdated = user.Map();
            _context.Users.Update(userUpdated);
            await _context.SaveChangesAsync();
            return userUpdated;
        }

        public async Task<Users> DeleteUser(int userId)
        {
            Users user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return null;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
