using ACCA_Backend.DataAccess.Entities;
using ACCA_Backend.DataAccess.Repository.Context;
using ACCA_Backend.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ACCA_Backend.DataAccess.Repository
{
    public class SessionRepository : ISessionRepository
    {
        internal AccaSystemContext _context;

        public SessionRepository(AccaSystemContext context)
        {
            _context = context;
        }

        public Task<Sessions> GetSession(int UserId)
        {
            return _context.Sessions
                .Where(u => u.UserId == UserId)
                .OrderBy(x => x.CreationDate)
                .LastAsync();
        }

        public async Task AddSession(Sessions session)
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }
    }
}
