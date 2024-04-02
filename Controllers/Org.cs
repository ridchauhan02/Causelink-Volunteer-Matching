using CauseLink.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;


namespace CauseLink.Controllers
{
    public class Org : Controller
    {
        details empObj = new details();
        public IActionResult Index()
        {
            empObj = new details();
            List<details> lst = empObj.getData();// fetches all the records
            return View(lst);


        }
        public IActionResult find()
        {
            return View();
        }
        public IActionResult confirm()
        {
            return View();
        }
        public IActionResult verify()
        {
            return View();
        }

        public IActionResult OrgIndex()
        {
            return View();
        }
        public IActionResult details()
        {
            return View();
        }
        [HttpPost]
        public IActionResult details(details emp1)
        {
            bool res;



            if (ModelState.IsValid)
            {
                empObj = new details();
                res = empObj.insert(emp1);
                if (res)
                {
                    return RedirectToAction("Index", "OrgDashBoard");
                }
                else
                {

                    TempData["msg"] = "Not Added .Something went wrong..!!";
                }


            }
            return View();
        }

    }
}
