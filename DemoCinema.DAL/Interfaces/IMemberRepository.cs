using DemoCinema.DAL.Entities;

namespace DemoCinema.DAL.Interfaces
{
    public interface IMemberRepository
    {
        MemberEntity? GetByEmail(string email);
        string? GetHashPwd(string email);
    }
}
