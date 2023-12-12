using ACCA_Backend.DataAccess.DTO;
using ACCA_Backend.DataAccess.Entities;

namespace ACCA_Backend.DataAccess.Repository.Interfaces
{
public interface IUsersRepository
{
    public Task<Users> GetUserByEmailAndPassword(string email, string pass);
    public Task<Users> GetUser(int UserId);
    public Task SaveUserAsync(Users user);
    public Task<List<Users>> GetUsers();
    public Task<Users> PostUser(UsersDTO userDTO);
    public Task<Users> UpdateUser(UsersDTO userDTO);
    public Task<Users> DeleteUser(int UserId);
}

}
