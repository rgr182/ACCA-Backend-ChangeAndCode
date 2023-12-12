using ACCA_Backend.DataAccess.Entities;

namespace ACCA_Backend.Utils.Interfaces

{
    public interface IAuthUtils
    {
        string GenerateJWT(Users user);
    }
}