using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RadicalTherapy.Data.model;
using RadicalTherapy.Data.Repository;
using RadicalTherapy.Models;
using RadicalTherapy.Utility;

namespace RadicalTherapy.Controllers
{
    public class Admin2Controller : Controller
    {
        public IActionResult ReserveQuestions(int questionId)
        {
            Question question = new Question();
            using (UnitOfWork db = new UnitOfWork())
            {
                question = db.QuestionRepository.GetByID(questionId);
            }

            return View(question);
        }
        public IActionResult FillpreReservation()
        {
            List<ReserveAdmin2> Reserves = new List<ReserveAdmin2>();

            using (UnitOfWork db = new UnitOfWork())
            {
                DateTime date = DateTime.Now.AddDays(15);
                var value = db.ReserveRepository.Get(c => c.Datetime >= DateTime.Now && c.Datetime <= date).ToList();
                foreach (var item in value)
                {
                    var question = db.QuestionRepository.GetByID(item.QuestionId);
                    Reserves.Add(new ReserveAdmin2 { Reserve = item, Question = question });
                }

                ViewBag.DateTemplates = Reserves;
            }
            return View();
        }
        public IActionResult AdminFillpreReservation(DateTime datetime)
        {

            using (UnitOfWork db = new UnitOfWork())
            {
                int questionId = db.QuestionRepository.Get(c => c.q1 == 1000).FirstOrDefault().Id;
                db.ReserveRepository.Insert(new Reserve { Datetime = datetime, Mobile = "0", Name = "admin", QuestionId = questionId });
                db.Save();
            }
            return RedirectToAction("FillpreReservation");
        }
        public IActionResult FreePreReservation(DateTime datetime)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var reserveId = db.ReserveRepository.Get(c => c.Datetime == datetime).FirstOrDefault().Id;
                db.ReserveRepository.Delete(reserveId);
                db.Save();
            }
            return RedirectToAction("FillpreReservation");
        }
        public IActionResult SendError(string error)
        {
            var subject = "مشکل لود نشدن عکس";
            Email.Send(subject, error);
            return Json("");
        }

    }
}
