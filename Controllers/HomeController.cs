using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadicalTherapy.Data.model;
using RadicalTherapy.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using UAParser;
using RadicalTherapy.Utility;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using RadicalTherapy.Models;

namespace RadicalTherapy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            List<Subject> subjects = new List<Subject>();
            ViewBag.title = "رادیکال تراپی - علی زارع";
            ViewData["metaDescription"] = "درمان بیماریهای ذهنی روانی به روش حذف بار منفی خاطرات آزاردهنده گذشته";
            try
            {

                using (UnitOfWork db = new UnitOfWork())
                {
                    string LocalIPAddr;
                    LocalIPAddr = HttpContext.Connection.RemoteIpAddress.ToString();
                    var Agent = Request.Headers["User-Agent"].ToString();
                    var uaParser = Parser.GetDefault();
                    ClientInfo clientInfo = uaParser.Parse(Agent);
                    var OS = clientInfo.OS.ToString();

                    var VisitToday = db.StatisticsRepository.Get(s => s.datetime.Date == DateTime.Now.Date);
                    if (!VisitToday.Any(s => s.IP == LocalIPAddr && s.OS == OS))
                    {
                        db.StatisticsRepository.Insert(new Statistics { IP = LocalIPAddr, OS = OS, datetime = DateTime.Now });
                        db.Save();
                    }
                    subjects = db.SubjectRepository.Get(c => c.Sequence != 0).ToList();
                }
            }
            catch (Exception e)
            {
                Email.Send("home-index", e.ToString());
            }
            var orderedSubjects = subjects.OrderBy(c => c.Sequence).ToList();

            return View(orderedSubjects);
        }
       
      
        public IActionResult CustomerVideo()
        {

            ViewData["title"] = "رضایت مراجعین عزیز";
            List<CustomerVideo> Videos = new List<CustomerVideo>();
            List<CommentModel> _Comments;
            using (UnitOfWork db = new UnitOfWork())
            {
                Videos = db.CustomerVideosRepository.Get().OrderBy(c=>c.Sequence).ToList();
                var subjectid = db.SubjectRepository.Get(c => c.English == "rezayat_morajein").First().Id;
                _Comments = Utility.Utility.Comments(subjectid);
                ViewBag.subjectId = subjectid;
            }
            ViewBag.videos = Videos;
            return View(_Comments);
        }

        public IActionResult ActiveNotification()
        {
            ViewData["title"] = "فعالسازی نتیفیکیشن";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["title"] = "راه های ارتباطی";
            return View();
        }
        public IActionResult RadicalTherapyTimes()
        {
            ViewBag.dateList = Utility.Utility.CreateRadicalReserveDateTimes();
            ViewBag.ReservedTimes = Utility.Utility.ReservedTimes();

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoginMethod(bool sms)
        {
            if (sms)
            {
                ViewBag.sms = true;
            }
            else
            {
                ViewBag.sms = false;
            }
            return View();
        }
        [HttpPost]
        public IActionResult LoginMethod(string username, int sms,DateTime datetime )
        {
            HttpContext.Session.SetInt32("smsOrEmail", sms);
            HttpContext.Session.SetString("username", username);
            HttpContext.Session.SetString("ReserveDatetime", datetime.ToString());
            TempData["ReserveDatetime"] = datetime;
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            int code = _rdm.Next(_min, _max);
            HttpContext.Session.SetInt32("code", code);
            MassageToUser.ConfirmationCode(username, code.ToString(), Convert.ToBoolean(sms));
            string Title;
            if (sms == 1)
            {
                Title = $"کد تایید برای شماره      {username}     ارسال شد";
            }
            else
            {
                Title = $"کد تایید برای ایمیل    {username}     ارسال شد";
            }
            return RedirectToAction("ConfirmationCode", new { title = Title });
        }
        public IActionResult ConfirmationCode(string title)
        {
            ViewBag.text = title;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmationCode(string c1, string c2, string c3, string c4)
        {
            string code = c1 + c2 + c3 + c4;
            string verificationcode = HttpContext.Session.GetInt32("code").ToString();
            if (verificationcode == code)
            {
                string userName = HttpContext.Session.GetString("username");
                using (UnitOfWork db = new UnitOfWork())
                {
                    User user = db.UserRepository.Get(c => c.UserName == userName).FirstOrDefault();
                    if (user == null)
                    {
                        if (HttpContext.Session.GetInt32("smsOrEmail") == 1)
                        {
                            db.UserRepository.Insert(new User
                            {
                                UserName = userName,
                                UserNameType = true
                            });
                        }
                        else
                        {
                            db.UserRepository.Insert(new User
                            {
                                UserName = userName,
                                UserNameType = false
                            });
                        }
                        db.Save();

                        var claims = new List<Claim>() {
                       new Claim(ClaimTypes.NameIdentifier, userName )
                      };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                        {
                            IsPersistent = true
                        });

                        return RedirectToAction("UserInfo", "User");

                    }
                    else
                    {
                        var claims = new List<Claim>() {
                       new Claim(ClaimTypes.NameIdentifier, userName )
                      };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                        {
                            IsPersistent = true
                        });
                        return RedirectToAction("Index", "User");

                    }
                }
            }
            else
            {
                ViewBag.wrongCode = true;
                return View();
            }
        }
        public async Task<IActionResult> VerifyByHttpClient(int id)
        {
            string authority = "";
            string amount;
            string merchant = "--------------------------";
            RadicalReserve reserve;
            using (UnitOfWork db = new UnitOfWork())
            {
                amount = db.DataRepository.Get(c => c.Key == "radicalReservePrice").FirstOrDefault().Value.ToString();
                reserve = db.RadicalReserveRepository.GetByID(id);
            }
            try
            {

                if (HttpContext.Request.Query["Authority"] != "")
                {
                    authority = HttpContext.Request.Query["Authority"];
                }

                using (HttpClient client = new HttpClient())
                {
                    string url = "https://api.zarinpal.com/pg/v4/payment/verify.json?";



                    string Reqparameters = $"merchant_id={merchant}&amount={amount}&authority={authority}";

                    HttpContent content = new StringContent(Reqparameters, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url + Reqparameters, content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Newtonsoft.Json.Linq.JObject jodata = Newtonsoft.Json.Linq.JObject.Parse(responseBody);
                    string data = jodata["data"].ToString();

                    Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(responseBody);
                    string errors = jo["errors"].ToString();

                    if (data != "[]")
                    {
                        string refid = jodata["data"]["ref_id"].ToString();
                        ViewBag.code = refid;
                        using (UnitOfWork db = new UnitOfWork())
                        {
                            User user = db.UserRepository.GetByID(reserve.UserId);
                            if (db.RadicalReserveRepository.Get(c => c.Refid == refid).Any())
                            {
                                return View("PaymentNotSuccess");
                            }

                            reserve.PayStatus = 3;
                            reserve.Refid = refid;
                            
                            using (UnitOfWork db1 = new UnitOfWork())
                            {
                                db1.RadicalReserveRepository.Update(reserve);
                                db1.Save();
                                Utility.MassageToUser.RadicalTherapyTime(user.UserName, user.Name, reserve.DateTime, user.UserNameType);
                                Email.SendReserveToAdmin(user.UserName, user.Name, reserve.DateTime, reserve.ID);
                                return View();
                            }

                        }

                    }
                    else if (errors != "[]")
                    {

                        string errorscode = jo["errors"]["code"].ToString();
                        return View("PaymentNotSuccess");

                    }
                }

            }
            catch (Exception ex)
            {
                Email.Send("zarinpal_VerifyByHttpClient", ex.Message);
                return View("PaymentNotSuccess");
            }
            return View("PaymentNotSuccess");
        }
        public IActionResult test()
        {
            return View("VerifyByHttpClient");
        }
       
    }
}

