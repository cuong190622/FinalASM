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


            using (var trCtx = new EF.FPTContext())
            {
                var trainers = trCtx.Trainers
                                     .OrderBy(b => b.Id)
                                     .ToList();
                return View(trainers);
            }
        }

        [HttpGet]
        public ActionResult NewTrainer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewTrainer(TrainerEntity trainer) //Chưa có ID
        {

            if (!ModelState.IsValid)
            {
                //binding gặp lỗi
                return View(trainer); // return NewTeacher.cshtml
                //Đi kèm với data mà user đã gõ vào
            }
            else
            {
                //binding ok
                using (var trCtx = new EF.FPTContext())
                {
                    trCtx.Trainers.Add(trainer);
                    trCtx.SaveChanges();
                }


                return RedirectToAction("Index");


            }

        }

        [HttpGet]
        public ActionResult UpdateTrainer(int id)
        {
            using (var trCxt = new EF.FPTContext())
            {
                var trainer = trCxt.Trainers.FirstOrDefault(b => b.Id == id);

                if (trainer != null)
                {
                    return View(trainer);
                }
                else
                {
                    return RedirectToAction("index");
                }
            }
        }

        [HttpPost]
        public ActionResult UpdateTrainer(int id, TrainerEntity trainer)
        {


            CustomValidation(trainer);
            if (!ModelState.IsValid)
            {
                return View(trainer);
            }
            else
            {
                using (var trCxt = new EF.FPTContext())
                {
                    trCxt.Entry<TrainerEntity>(trainer).State
                        = System.Data.Entity.EntityState.Modified;

                    trCxt.SaveChanges();
                }


                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var trCxt = new EF.FPTContext())
            {
                var trainer = trCxt.Trainers.FirstOrDefault(b => b.Id == id);
                if (trainer != null)
                {
                    trCxt.Trainers.Remove(trainer);
                    trCxt.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }



        [HttpGet]
        public ActionResult UpdateTrainerAccount(int id)
        {
            using (var trCxt = new EF.FPTContext())
            {
                var trainer = trCxt.Trainers.FirstOrDefault(b => b.Id == id);

                if (trainer != null)
                {
                    return View(trainer);
                }
                else
                {
                    return RedirectToAction("index");
                }
            }
        }

        [HttpPost]
        public ActionResult UpdateTrainerAccount(int id, TrainerEntity trainer)
        {

            CustomValidation(trainer);
            if (!ModelState.IsValid)
            {
                return View(trainer);
            }
            else
            {
                using (var trCxt = new EF.FPTContext())
                {
                    trCxt.Entry<TrainerEntity>(trainer).State
                        = System.Data.Entity.EntityState.Modified;

                    trCxt.SaveChanges();
                }


                return RedirectToAction("Index");
            }
        }

        private void CustomValidation(TrainerEntity trainer)
        {
            if (!string.IsNullOrEmpty(trainer.Password) &&  trainer.Password.Length < 11)
            {
                ModelState.AddModelError("SSID", "SSID has exactly 11 digits");
            }
        }
    }
}