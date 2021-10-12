using FinalASM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalASM.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangeProfile(int id)
        {
            using (var teCtx = new EF.FPTContext())
            {
                var trainer = teCtx.Trainers.FirstOrDefault(c => c.Id == id);

                return View(trainer);
            }
        }
        [HttpPost]
        public ActionResult ChangeProfile(TrainerEntity trainer)
        {
            using (var teCtx = new EF.FPTContext())
            {
                teCtx.Entry<TrainerEntity>(trainer).State = System.Data.Entity.EntityState.Modified;
                teCtx.SaveChanges();
            }

            return RedirectToAction("Index");
        }


       

    }
}