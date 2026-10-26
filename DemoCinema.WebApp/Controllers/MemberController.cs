using Microsoft.AspNetCore.Mvc;

namespace DemoCinema.WebApp.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
