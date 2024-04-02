using Microsoft.AspNetCore.Mvc;

namespace CauseLink.Controllers
{
    public class admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
