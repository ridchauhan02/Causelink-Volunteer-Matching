using CauseLink.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace CauseLink.Controllers
{
    public class Signin : Controller
    {
        signin empObj = new signin();

        public IActionResult Index()
        {
            empObj = new signin();
            List<signin> lst = empObj.getData();// fetches all the records
            return View(lst);



        }
        public IActionResult Sign()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sign(signin emp)
        {
            bool res;



            if (ModelState.IsValid)
            {
                empObj = new signin();
                res = empObj.insert(emp);
                if (res)
                {
                    return RedirectToAction("page0");
                }
                else
                {

                    TempData["msg"] = "Not Added .Something went wrong..!!";
                }


            }
            return View();
        }


        public IActionResult page0()
        {
            return View();
        }
        public IActionResult page1()
        {
            return View();
        }

    }
}