using Microsoft.AspNetCore.Mvc;

namespace CauseLink.Controllers
{
    public class Main : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
