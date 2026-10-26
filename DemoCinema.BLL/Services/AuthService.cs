using DemoCinema.BLL.BusinessExceptions;
using DemoCinema.BLL.Interfaces;
using DemoCinema.BLL.Mappers;
using DemoCinema.BLL.Models;
using DemoCinema.DAL.Interfaces;

namespace DemoCinema.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IHasherHelper _passwordHasher;
        public AuthService(IMemberRepository memberRepository, IHasherHelper passwordHasher)
        {
            _memberRepository = memberRepository;
            _passwordHasher = passwordHasher;
        }

        public MemberModel Login(string email, string password)
        {
            string? hashPassword = _memberRepository.GetHashPwd(email);
            if(hashPassword is null)
            {
                throw new AuthBadCredentialException();
            }

            bool isValid = _passwordHasher.Verify(hashPassword, password);
            if(!isValid)
            {
                throw new AuthBadCredentialException();
            }

            return _memberRepository.GetByEmail(email)!.ToModel();
        }
    }
}
