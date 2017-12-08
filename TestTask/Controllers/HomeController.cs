using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new DBEntities())
            {
                ViewBag.Positions = db.Positions.ToList().Select(z => new SelectListItem() { Text = z.Position, Value = z.id.ToString() });
                ViewBag.Departmentments = db.Departments.ToList().Select(z => new SelectListItem() { Text = z.Department, Value = z.id.ToString() });
            }
            return View();
        }
    }
}