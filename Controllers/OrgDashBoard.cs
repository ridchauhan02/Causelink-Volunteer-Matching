using CauseLink.Models;
using Microsoft.AspNetCore.Mvc;

namespace CauseLink.Controllers
{
    public class OrgDashBoard : Controller
    {
        addpost empObj = new addpost();
        public IActionResult Index()
        {

            empObj = new addpost();
            List<addpost> lst = empObj.getData();// fetches all the records
            return View(lst);


        }

        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(addpost emp2)
        {
            bool res;



            if (ModelState.IsValid)
            {
                empObj = new addpost();
                res = empObj.insert(emp2);
                if (res)
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    TempData["msg"] = "Not Added .Something went wrong..!!";
                }


            }
            return View();
        }

        [HttpGet]
        public IActionResult Editpost(string id)
        {
            addpost emp = empObj.getData(id);
            return View(emp);
        }

        [HttpGet]
        public IActionResult Deletepost(string id)
        {
            addpost emp = empObj.getData(id);

            return View(emp);
        }


        [HttpPost]
        public IActionResult Editpost(addpost emp)
        {
            bool res;
            if (ModelState.IsValid)
            {
                empObj = new addpost();
                res = empObj.update(emp);

                if (res)
                {
                    TempData["msg"] = "Updated Sucessfully";


                }
                else
                {
                    TempData["msg"] = "Not Updated. something went wrong..!!";
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Deletepost(addpost emp)
        {
            bool res;
            //if (ModelState.IsValid)
            //{
            empObj = new addpost();
            res = empObj.delete(emp);
            if (res)
            {
                TempData["msg"] = "Delete Sucessfully";
            }
            //}
            else
            {
                TempData["msg"] = "Not Deleted. something went wrong..!!";
            }
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
