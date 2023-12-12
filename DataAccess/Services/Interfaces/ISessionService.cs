using ACCA_Backend.DataAccess.Entities;

namespace ACCA_Backend.DataAccess.Services.Interfaces
{
    public interface ISessionService
    {
        public Task<Sessions> SaveSession(Users user);

        public Task<Sessions> GetSession(int UserId);
    }
}
