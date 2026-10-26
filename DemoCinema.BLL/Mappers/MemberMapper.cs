using DemoCinema.BLL.Models;
using DemoCinema.DAL.Entities;

namespace DemoCinema.BLL.Mappers
{
    internal static class MemberMapper
    {
        public static MemberModel ToModel(this MemberEntity data)
        {
            return new MemberModel()
            {
                Id = data.Id,
                Username = data.Username,
                Email = data.Email,
                Role = data.Role,
                FirstName = data.FirstName,
                LastName = data.LastName,
                BirthDate = data.BirthDate
            };
        }

        public static MemberEntity ToEntity(this MemberModel data)
        {
            return new MemberEntity()
            {
                Id = data.Id,
                Username = data.Username,
                Email = data.Email,
                Role = data.Role,
                FirstName = data.FirstName,
                LastName = data.LastName,
                BirthDate = data.BirthDate,
                HashPassword = string.Empty
            };
        }
    }
}
