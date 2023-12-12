using ACCA_Backend.DataAccess.Entities;

namespace ACCA_Backend.DataAccess.Repository.Interfaces
{
    public interface ISessionRepository
    {
        public Task<Sessions> GetSession(int UserId);
        public Task AddSession(Sessions session);
    }
}