using DemoCinema.BLL.BusinessExceptions;
using DemoCinema.BLL.Interfaces;
using DemoCinema.BLL.Mappers;
using DemoCinema.BLL.Models;
using DemoCinema.DAL.Entities;
using DemoCinema.DAL.Interfaces;

namespace DemoCinema.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IHasherHelper _hasherHelper;
        public AuthService(IMemberRepository memberRepository, IHasherHelper passwordHasher)
        {
            _memberRepository = memberRepository;
            _hasherHelper = passwordHasher;
        }

        public bool CheckAlreadyExists(string email)
        {
            return _memberRepository.GetHashPwd(email) is not null;
        }

        public MemberModel Login(string email, string password)
        {
            string? hashPassword = _memberRepository.GetHashPwd(email);
            if(hashPassword is null)
            {
                throw new AuthBadCredentialException();
            }

            bool isValid = _hasherHelper.Verify(hashPassword, password);
            if(!isValid)
            {
                throw new AuthBadCredentialException();
            }

            return _memberRepository.GetByEmail(email)!.ToModel();
        }

        public void Register(string email, string username, string password)
        {
            string hashPassword = _hasherHelper.Hash(password);

            int memberId = _memberRepository.Insert(new MemberEntity
            {
                Email = email,
                Username = username,
                FirstName = null,
                LastName = null,
                BirthDate = null,
                Role = "User",
                HashPassword = hashPassword
            });
        }
    }
}
