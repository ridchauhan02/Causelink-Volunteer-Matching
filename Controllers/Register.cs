using Microsoft.AspNetCore.Mvc;

namespace CauseLink.Controllers
{
    public class Register : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
