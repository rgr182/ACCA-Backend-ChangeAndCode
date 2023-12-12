using ACCA_Backend.DataAccess.Repository.Interfaces;
using ACCA_Backend.DataAccess.Repository;
using ACCA_Backend.DataAccess.Services.Interfaces;
using ACCA_Backend.DataAccess.Services;
using ACCA_Backend.Utils.Interfaces;
using ACCA_Backend.Utils.Security;

namespace ACCA_Backend.Infraestructure
{
    public class DependencyRegistry
    {
        public DependencyRegistry(WebApplicationBuilder builder)
        {
            #region Services
            builder.Services.AddScoped<ISessionService, SessionService>();
            builder.Services.AddScoped<IUsersService, UsersService>();
            #endregion

            #region Repositories
            builder.Services.AddScoped<ISessionRepository, SessionRepository>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();

            #endregion

            #region Utils
            builder.Services.AddScoped<IUtils, Utils.Utils>();
            builder.Services.AddScoped<IAuthUtils, AuthUtils>();
            #endregion
        }
    }
}
