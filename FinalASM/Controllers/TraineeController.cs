using FinalASM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalASM.Controllers
{
    public class TraineeController : Controller
    {
        // GET: Trainee
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePass(int id)
        {
            using (var abc = new EF.FPTContext())
            {
                var stix = abc.trainees.FirstOrDefault(b => b.Id == id);
                return View(stix);
            }
        }

        [HttpPost]
        public ActionResult ChangePass(TraineeEntity a)
        {
            using (var abc = new EF.FPTContext())
            {
                abc.Entry<TraineeEntity>(a).State = System.Data.Entity.EntityState.Modified;
                abc.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}