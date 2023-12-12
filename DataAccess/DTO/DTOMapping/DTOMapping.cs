using ACCA_Backend.DataAccess.Entities;

namespace ACCA_Backend.DataAccess.DTO.DTOMapping
{
    public static class DTOMapping
    {
                public static Users Map(this UsersDTO users) =>
            new Users
            {
                UserId = users.UserId,
                Name = users.Name,
                Email = users.Email,
                Password = users.Password,
                TypeId = users.TypeId,
            };
    }
}
