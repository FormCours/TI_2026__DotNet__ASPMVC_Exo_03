using DemoCinema.BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace DemoCinema.BLL.Helpers
{
    public class HasherHelper : IHasherHelper
    {
        // Exemple d'implémentation basé sur le "PasswordHash<TUser>" du .Net
        // https://learn.microsoft.com/fr-fr/dotnet/api/microsoft.aspnetcore.identity.passwordhasher-1?view=aspnetcore-10.0


        // L'OWASP recommande au moins 220 000 pour du PBKDF2-HMAC-SHA512
        // Autre solution recommander par l'OWASP, utiliser Argon2id ;)
        private const int iterationCount = 300_000;

        // L'implementation du "PasswordHash<TUser>" require un objet pour le hashage, par simplicité, on en fourni un objet neutre.
        private static readonly object noUser = new();


        // Necessite le Nuget "Microsoft.Extensions.Identity.Core"
        private readonly PasswordHasher<object> _passwordHasher;
        public HasherHelper()
        {
            _passwordHasher = new PasswordHasher<object>(Options.Create(new PasswordHasherOptions
            {
                CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3,
                IterationCount = iterationCount
            }));
        }

        public string Hash(string value)
        {
            return _passwordHasher.HashPassword(noUser, value);
        }

        public bool Verify(string hash, string value)
        {
            try
            {
                var check = _passwordHasher.VerifyHashedPassword(noUser, hash, value);
                return check == PasswordVerificationResult.Success;

            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
