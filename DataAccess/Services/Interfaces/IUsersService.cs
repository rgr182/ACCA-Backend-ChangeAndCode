using ACCA_Backend.DataAccess.DTO;
using ACCA_Backend.DataAccess.Entities;

namespace ACCA_Backend.DataAccess.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<Users> GetUserByEmailAndPassword(string email, string password);
        public Task<Users> GetUser(int userId);
        public Task<List<Users>> GetUsers();
        public Task<UsersDTO> PostUser(UsersDTO user);
        public Task<Users> UpdateUser(UsersDTO user);
        public Task<Users> DeleteUser(int UserId);
    }
}
