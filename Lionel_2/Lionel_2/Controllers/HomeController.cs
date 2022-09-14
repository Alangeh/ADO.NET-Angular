using Lionel_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lionel_2.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDB empDB = new EmployeeDB();
        // GET: Home  
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
        public ActionResult Dashbord()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        Database_Access_Layer.db dblayer = new Database_Access_Layer.db();
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            int res = dblayer.User_Login(fc["userid"], fc["password"]);
            if (res == 1)
            {
                return RedirectToAction("Dashbord");
            }
            else
            {
                TempData["msg"] = "User Id or password wrong...";
            }
            return View();
        }

        public JsonResult List()
        {
            return Json(empDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Search(int ID)
        {
            var Employee = empDB.SearchAll().Find(x => x.EmployeeID.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Employee emp)
        {
            return Json(empDB.Add(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = empDB.ListAll().Find(x => x.EmployeeID.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Employee emp)
        {
            return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }









        /* public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        */
    }
}