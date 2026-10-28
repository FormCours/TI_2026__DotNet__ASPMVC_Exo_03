using DemoCinema.BLL.Interfaces;
using DemoCinema.BLL.Models;
using DemoCinema.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace DemoCinema.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] AuthLoginFrom loginFrom, [FromQuery] string? returnUrl)
        {
            if(!ModelState.IsValid) {
                return View();
            }

            MemberModel member = _authService.Login(loginFrom.Email, loginFrom.Password);
            if(member is null)
            {
                ModelState.AddModelError(string.Empty, "Crédentials invalide");
                return View();
            }

            // Authentification de l'utilisateur
            List<Claim> claims = [
                new Claim(ClaimTypes.NameIdentifier, member.Id.ToString()),
                new Claim(ClaimTypes.Role, member.Role),
            ];
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // SignIn
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity)
            );

            // Redirection
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] AuthRegisterFrom registerFrom)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if(_authService.CheckAlreadyExists(registerFrom.Email))
            {
                ModelState.AddModelError(string.Empty, "Un compte existe déjà pour ce couriel");
                return View();
            }

            _authService.Register(registerFrom.Email, registerFrom.Username, registerFrom.Password);

            // Redirection
            TempData["Message"] = "Compte créé avec succès. Veuillez procéder à une authentification immédiate pour confirmer que les identifiants stockés correspondent à vos intentions réelles de saisie. Merci.";
            return RedirectToAction(nameof(Login));
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // SignIn
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            // Redirection
            return RedirectToAction("Index", "Home");
        }
    }
}
