using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTest.Data;
using WebAppTest.Models;

namespace WebAppTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Index(AppLockViewModel model)
        {

            return Json(new { message = "OK" });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            using (var db = new IsoContext())
            {                
                Schedule schedule = new Schedule { Descricao = "Teste 7" };

                schedule.ScheduleDays.Add(new ScheduleDay { Data = DateTime.Now });

                try
                {
                    db.Schedules.Add(schedule);

                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }                             
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            using (var db = new IsoContext())
            {
                try
                {
                    var result = db.Employees.ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return View();
        }
    }
}