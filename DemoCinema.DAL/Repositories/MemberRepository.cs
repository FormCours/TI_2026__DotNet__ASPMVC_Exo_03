using DemoCinema.DAL.Entities;
using DemoCinema.DAL.Interfaces;

namespace DemoCinema.DAL.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataStaticContext context;
        public MemberRepository(DataStaticContext context)
        {
            this.context = context;
        }

        public MemberEntity? GetByEmail(string email)
        {
            MemberEntity? member = context.Members.SingleOrDefault(m => m.Email == email);
            if (member is null)
                return null;

            return new MemberEntity
            {
                Id = member.Id,
                Email = member.Email,
                Username = member.Username,
                BirthDate = member.BirthDate,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Role = member.Role,
                HashPassword = string.Empty
            };
        }

        public string? GetHashPwd(string email)
        {
            MemberEntity? member = context.Members.SingleOrDefault(m => m.Email == email);
            return member?.HashPassword;
        }
    }
}
