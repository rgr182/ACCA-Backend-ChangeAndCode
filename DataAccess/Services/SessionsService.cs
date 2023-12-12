using ACCA_Backend.DataAccess.Entities;
using ACCA_Backend.DataAccess.Repository.Interfaces;
using ACCA_Backend.DataAccess.Services.Interfaces;
using ACCA_Backend.Utils.Interfaces;

namespace ACCA_Backend.DataAccess.Services
{
    public class SessionService : ISessionService
    {
        readonly ILogger<UsersService> _logger;
        readonly ISessionRepository _sessionRepository;
        readonly IAuthUtils _authUtils;

        public SessionService(ILogger<UsersService> logger,
                              ISessionRepository securityRepository,
                              IAuthUtils authUtils)
        {
            _logger = logger;
            _sessionRepository = securityRepository;
            _authUtils = authUtils;
        }

        public async Task<Sessions> GetSession(int UserId)
        {
            Sessions result = new Sessions();

            try
            {
                result = await _sessionRepository.GetSession(UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "some error happened on SessionService");
                throw;
            }

            return result;
        }

        public async Task<Sessions> SaveSession(Users user)
        {
            try
            {
                var session = new Sessions()
                {
                    CreationDate = DateTime.UtcNow,
                    ExpirationDate = DateTime.UtcNow.AddDays(1),
                    UserId = user.UserId,
                    UserToken = _authUtils.GenerateJWT(user),
                    TypeId = user.TypeId
                };

                await _sessionRepository
                   .AddSession(session);

                return session;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
