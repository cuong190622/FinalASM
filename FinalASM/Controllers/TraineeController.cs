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
            using (var teCtx = new EF.FPTContext())
            {
                var trainee = teCtx.trainees.FirstOrDefault(c => c.Id == id);

                return View(trainee);
            }
        }
        [HttpPost]
        public ActionResult ChangePass(TraineeEntity trainee)
        {
            using (var teCtx = new EF.FPTContext())
            {
                teCtx.Entry<TraineeEntity>(trainee).State = System.Data.Entity.EntityState.Modified;
                teCtx.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}