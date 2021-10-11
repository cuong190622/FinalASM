using FinalASM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalASM.Controllers
{
    public class ASMController : Controller
    {
        // GET: ASM
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MStaff()
        {
            using (var ASMCtx = new EF.FPTContext())
            {
                var Staff = ASMCtx.Staffs.OrderBy(t => t.Id).ToList();
                return View(Staff);
            }
        }
        [HttpGet]
        public ActionResult CreateStaff()
        {
            return View();
        }

        [HttpPost]
        //public ActionResult Create(FormCollection f)
        public ActionResult CreateStaff(StaffEntity staff, FormCollection fc) //chua co Id
        {
            /*            CustomValidationfClass(classRoom);
                        if (!ModelState.IsValid)
                        {
                            //binding gap loi
                            PrepareViewBag();
                            TempData["TeacherIds"] = fc["TeacherIds[]"];
                            return View(classRoom); // return lai Create.cshtml
                            //di kem voi data ma user da go vao
                        }
                        else*/
            {
                using (var ASMCtx = new EF.FPTContext())
                {
                    staff.Role = "abc";
                    ASMCtx.Staffs.Add(staff);

                    ASMCtx.SaveChanges();
                }

                TempData["message"] = $"Successfully add class {staff.Username} to system!";

                return RedirectToAction("MStaff");
            }

        }

        public ActionResult DStaff(int id)
        {
            using (var FAPCtx = new EF.FPTContext())
            {
                var student = FAPCtx.Staffs.FirstOrDefault(c => c.Id == id);

                if (student != null)
                {
                    TempData["StaffId"] = id;
                    TempData["StaffUN"] = student.Username;
                    return View(student);
                }
                else
                {
                    return RedirectToAction("MStaff");
                }

            }

        }

        [HttpGet]
        public ActionResult EditStaff(int id)
        {
            using (var FAPCtx = new EF.FPTContext())
            {
                var student = FAPCtx.Staffs.FirstOrDefault(c => c.Id == id);

                if (student != null)
                {
                    TempData["StaffId"] = id;
                    return View(student);
                }
                else
                {
                    return RedirectToAction("MStaff");
                }

            }
        }

        [HttpPost]
        public ActionResult EditStaff(int id, StaffEntity staff)
        {

            /*            CustomValidationfStudent(student);

                        if (!ModelState.IsValid)
                        {
                            PrepareViewBag();
                            return View(student);
                        }
                        else*/
            {
                using (var FAPCtx = new EF.FPTContext())
                {
                    FAPCtx.Entry<StaffEntity>(staff).State = System.Data.Entity.EntityState.Modified;

                    FAPCtx.SaveChanges();
                }
                return RedirectToAction("MStaff");
            }
        }

        [HttpPost]
        public ActionResult DeleteStaff(int id)
        {
            using (var FAPCtx = new EF.FPTContext())
            {
                var staff = FAPCtx.Staffs.FirstOrDefault(c => c.Id == id);

                if (staff != null)
                {
                    FAPCtx.Staffs.Remove(staff);
                    FAPCtx.SaveChanges();
                }
                return RedirectToAction("MStaff");
            }


        }














        public ActionResult AMTrainer()
        {
            using (var ASMCtx = new EF.FPTContext())
            {
                var trainer = ASMCtx.Trainers.OrderBy(t => t.Id).ToList();
                return View(trainer);
            }
        }
        [HttpGet]
        public ActionResult ACreateTrainer()
        {
            return View();
        }

        [HttpPost]
        //public ActionResult Create(FormCollection f)
        public ActionResult ACreateTrainer(TrainerEntity trainer, FormCollection fc) //chua co Id
        {
            /*            CustomValidationfClass(classRoom);
                        if (!ModelState.IsValid)
                        {
                            //binding gap loi
                            PrepareViewBag();
                            TempData["TeacherIds"] = fc["TeacherIds[]"];
                            return View(classRoom); // return lai Create.cshtml
                            //di kem voi data ma user da go vao
                        }
                        else*/
            {
                using (var ASMCtx = new EF.FPTContext())
                {
                    trainer.Role = "abc";
                    ASMCtx.Trainers.Add(trainer);

                    ASMCtx.SaveChanges();
                }

                TempData["message"] = $"Successfully add class {trainer.Username} to system!";

                return RedirectToAction("AMTrainer");
            }

        }

        public ActionResult DTrainer(int id)
        {
            using (var FAPCtx = new EF.FPTContext())
            {
                var trainer = FAPCtx.Trainers.FirstOrDefault(c => c.Id == id);

                if (trainer != null)
                {
                    TempData["TrainerId"] = id;
                    TempData["TrainerUN"] = trainer.Username;
                    return View(trainer);
                }
                else
                {
                    return RedirectToAction("AMTrainer");
                }

            }

        }

        [HttpGet]
        public ActionResult EditTrainer(int id)
        {
            using (var FAPCtx = new EF.FPTContext())
            {
                var trainer = FAPCtx.Trainers.FirstOrDefault(c => c.Id == id);

                if (trainer != null)
                {
                    TempData["TrainerId"] = id;
                    return View(trainer);
                }
                else
                {
                    return RedirectToAction("AMTrainer");
                }

            }
        }

        [HttpPost]
        public ActionResult EditTrainer(int id, TrainerEntity trainer)
        {

            /*            CustomValidationfStudent(student);

                        if (!ModelState.IsValid)
                        {
                            PrepareViewBag();
                            return View(student);
                        }
                        else*/
            {
                using (var FAPCtx = new EF.FPTContext())
                {
                    FAPCtx.Entry<TrainerEntity>(trainer).State = System.Data.Entity.EntityState.Modified;

                    FAPCtx.SaveChanges();
                }
                return RedirectToAction("AMTrainer");
            }
        }

        [HttpPost]
        public ActionResult DeleteTrainer(int id)
        {
            using (var FAPCtx = new EF.FPTContext())
            {
                var trainer = FAPCtx.Trainers.FirstOrDefault(c => c.Id == id);

                if (trainer != null)
                {
                    FAPCtx.Trainers.Remove(trainer);
                    FAPCtx.SaveChanges();
                }
                return RedirectToAction("AMTrainer");
            }


        }


    }
}