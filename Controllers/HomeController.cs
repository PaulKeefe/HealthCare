using System.Linq;
using System.Web.Mvc;
using HealthCare.Models;

namespace HealthCare.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            using (var db = new healthEntities())
            {
                ViewBag.Plans = db.BenefitPlans.ToList();
                ViewBag.Employees = db.EmployeeList();
            }
            return View();
        }

        [HttpPost]
        public JsonResult RetrieveEmployee(int userId, string username, string password)
        {
            using (var db = new healthEntities())
            {
                var employee = db.Employees.FirstOrDefault(
                    i => i.Id == userId && i.Username == username.ToLower() && i.Password == password);
                if (employee != null)
                {
                    return Json(new { success = true, employee = new EmployeeDisplay(employee) });
                }
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public JsonResult UpdatePlan(int employeeId, int planId)
        {
            using (var db = new healthEntities())
            {
                var success = db.UpdatePlan(employeeId, planId);
                return Json(new { success = success });
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Company about page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Company contact page.";

            return View();
        }
    }
}