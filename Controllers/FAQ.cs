using Microsoft.AspNetCore.Mvc;

namespace CauseLink.Controllers
{
    public class FAQ : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
