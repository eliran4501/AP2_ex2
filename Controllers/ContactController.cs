using Microsoft.AspNetCore.Mvc;

namespace AP2_ex2.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
