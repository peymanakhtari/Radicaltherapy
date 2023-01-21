using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadicalTherapy.Data.model;
using RadicalTherapy.Data.Repository;
using RadicalTherapy.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RadicalTherapy.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public UserController()
        {

        }
        public IActionResult Index()
        {
            var UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = new User();
            List<RadicalReserve> RadicalTherapyTimes;
            List<DateTime> reservedTimes = new List<DateTime>();

            using (UnitOfWork db = new UnitOfWork())
            {
                user = db.UserRepository.Get(c => c.UserName == UserName).FirstOrDefault();
                if (db.UserRepository.Get(c => c.UserName == UserName).FirstOrDefault().WhatsApp == null)
                {
                    return RedirectToAction("UserInfo");
                }
                if (TempData["ReserveDatetime"] != null)
                {
                    var dt = TempData["ReserveDatetime"];
                    TempData["ReserveDatetime"]=null;
                    return RedirectToAction("ConfirmRules", "RadicalTherapyTime", new { datetime = dt });
                }

                RadicalTherapyTimes = db.RadicalReserveRepository.Get(c => c.PayStatus == 3 && c.UserId == user.ID && c.DateTime > new DateTime(2019, 1, 1)).ToList();
                var reserves = db.RadicalReserveRepository.Get(c => c.DateTime > DateTime.Now && c.PayStatus == 3);
                foreach (var item in reserves)
                {
                    if (item.DateTime > DateTime.Now)
                    {
                        reservedTimes.Add(item.DateTime);
                    }
                }

            }

            ViewBag.dateList = Utility.Utility.CreateRadicalReserveDateTimes();
            ViewBag.Name = user.Name;
            ViewBag.WhatsApp = user.WhatsApp.Replace("+", "00");
            ViewBag.UserName = UserName;
            ViewBag.RadicalTherapyTimes = RadicalTherapyTimes.OrderByDescending(c => c.DateTime).ToList();
            ViewBag.ReservedTimes = reservedTimes.OrderByDescending(c => c).ToList();
            return View();

        }
        public IActionResult UserInfo()
        {
            var UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            using (UnitOfWork db = new UnitOfWork())
            {
                string name = db.UserRepository.Get(c => c.UserName == UserName).FirstOrDefault().Name;
                if (name != null)
                {
                    ViewBag.name = name;
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult UserInfo(string c1, string c2, string c3, string c4, string c5, string c6, string c7, string c8, string c9, string c10, string c11, string c12, string c13, string name)
        {
            var UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string code = c1 + c2 + c3;
            string number = c4 + c5 + c6 + c7 + c8 + c9 + c10 + c11 + c12 + c13;
            string whatsapp = "+" + code + number;
            string finalWhatsapp = Utility.Utility.changePersianNumbersToEnglish(whatsapp);
            using (UnitOfWork db = new UnitOfWork())
            {
                User user = db.UserRepository.Get(c => c.UserName == UserName).FirstOrDefault();
                user.WhatsApp = whatsapp;
                user.Name = name;
                db.UserRepository.Update(user);
                db.Save();
            }

            return RedirectToAction("Index");
        }
        public IActionResult UploadResept()
        {
            var UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId;

            using (UnitOfWork db = new UnitOfWork())
            {
                userId = db.UserRepository.Get(c => c.UserName == UserName).FirstOrDefault().ID;
                if (db.RadicalReserveRepository.Get(c => c.UserId == userId).Where(c => c.PayStatus == 1 || c.PayStatus == 2 || c.PayStatus == 10).Any())
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        [HttpPost]
        public IActionResult SubmitRadicalReserve(string img)
        {
            try
            {
                int userId = getUserIdByUserName();
                using (UnitOfWork db = new UnitOfWork())
                {
                    if (db.RadicalReserveRepository.Get(c => c.UserId == userId).Where(c => c.PayStatus == 1 || c.PayStatus == 2 || c.PayStatus == 10).Any())
                    {
                        return RedirectToAction("Index");
                    }
                    db.RadicalReserveRepository.Insert(new RadicalReserve()
                    {
                        PayStatus = 1,
                        UserId = userId,
                        Price = 500000,
                        ReseptPic = Encoding.ASCII.GetBytes(img)
                    });
                    db.Save();

                    User user = db.UserRepository.GetByID(userId);
                    MassageToUser.ReseptIsUploaded(User.FindFirstValue(ClaimTypes.NameIdentifier), user.Name, user.UserNameType);
                    Email.sendReservePicToaAdmin(userId);
                }
            }
            catch (Exception e)
            {
                Email.Send("SubmitRadicalReserve", e.ToString());
            }
            return Json(new { redirectToUrl = Url.Action("Index", "User") });
        }
        [HttpPost]
        public IActionResult DeclareReserveTime(DateTime datetime)
        {
            int userId;
            var UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            using (UnitOfWork db = new UnitOfWork())
            {

                userId = db.UserRepository.Get(c => c.UserName == UserName).FirstOrDefault().ID;
                if (!db.RadicalReserveRepository.Get(c => c.UserId == userId && c.PayStatus == 2).Any())
                {
                    return RedirectToAction("index");
                }
                RadicalReserve reserve = db.RadicalReserveRepository.Get(c => c.UserId == userId && c.PayStatus == 2).FirstOrDefault();
                reserve.DateTime = datetime;
                reserve.PayStatus = 3;
                db.RadicalReserveRepository.Update(reserve);
                db.Save();
                var user = db.UserRepository.GetByID(userId);
                MassageToUser.RadicalTherapyTime(user.UserName, user.Name, datetime, user.UserNameType);
                Email.SendReserveToAdmin(user.WhatsApp, user.Name, datetime, reserve.ID);

            }
            return RedirectToAction("index");
        }


        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("RadicalTherapyTimes", "Home");
        }

        public IActionResult RejectionReasonSeen()
        {
            var userid = getUserIdByUserName();
            using (UnitOfWork db = new UnitOfWork())
            {
                var RadicalReserve = db.RadicalReserveRepository.Get(c => c.UserId == userid && c.PayStatus == 10).FirstOrDefault();
                RadicalReserve.PayStatus = 0;
                db.RadicalReserveRepository.Update(RadicalReserve);
                db.Save();
            }
            return RedirectToAction("Index");
        }

        public int getUserIdByUserName()
        {
            int userId;
            var UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            using (UnitOfWork db = new UnitOfWork())
            {
                return userId = db.UserRepository.Get(c => c.UserName == UserName).FirstOrDefault().ID;
            }

        }
    }
}
