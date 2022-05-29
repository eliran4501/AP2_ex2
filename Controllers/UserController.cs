using Microsoft.AspNetCore.Mvc;

namespace AP2_ex2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("login");
        }
    }
}
