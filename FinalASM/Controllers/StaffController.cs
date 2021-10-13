using FinalASM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalASM.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
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
            CustomValidation(trainer);
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







        // Trainee
        public ActionResult TraineeManager()
        {


            using (var teCtx = new EF.FPTContext())
            {
                var trainees = teCtx.trainees
                                     .OrderBy(b => b.Id)
                                     .ToList();
                return View(trainees);
            }
        }


        [HttpGet]
        public ActionResult NewTrainee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewTrainee(TraineeEntity trainee) //Chưa có ID
        {

            if (!ModelState.IsValid)
            {
                //binding gặp lỗi
                return View(trainee); // return NewTeacher.cshtml
                //Đi kèm với data mà user đã gõ vào
            }
            else
            {
                //binding ok
                using (var teCtx = new EF.FPTContext())
                {
                    teCtx.trainees.Add(trainee);
                    teCtx.SaveChanges();
                }


                return RedirectToAction("TraineeManager");


            }

        }

        [HttpGet]
        public ActionResult UpdateTrainee(int id)
        {
            using (var teCxt = new EF.FPTContext())
            {
                var trainee = teCxt.trainees.FirstOrDefault(b => b.Id == id);

                if (trainee != null)
                {
                    return View(trainee);
                }
                else
                {
                    return RedirectToAction("TraineeManager");
                }
            }
        }

        [HttpPost]
        public ActionResult UpdateTrainee(int id, TraineeEntity trainee)
        {


           // CustomValidation(trainee);
            if (!ModelState.IsValid)
            {
                return View(trainee);
            }
            else
            {
                using (var teCxt = new EF.FPTContext())
                {
                    teCxt.Entry<TraineeEntity>(trainee).State
                        = System.Data.Entity.EntityState.Modified;

                    teCxt.SaveChanges();
                }


                return RedirectToAction("TraineeManager");
            }
        }

        [HttpPost]
        public ActionResult DeleteTrainee(int id)
        {
            using (var teCxt = new EF.FPTContext())
            {
                var trainee = teCxt.trainees.FirstOrDefault(b => b.Id == id);
                if (trainee != null)
                {
                    teCxt.trainees.Remove(trainee);
                    teCxt.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }



        
        private void CustomValidation(TrainerEntity trainer)
        {
            if (!string.IsNullOrEmpty(trainer.Password) && trainer.Password.Length < 11)
            {
                ModelState.AddModelError("SSID", "SSID has exactly 11 digits");
            }
        }



    }
}