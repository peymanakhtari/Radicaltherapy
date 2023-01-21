using MD.PersianDateTime.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RadicalTherapy.Data.model;
using RadicalTherapy.Data.Repository;
using RadicalTherapy.Models;
using RadicalTherapy.Utility.Convertor;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using WebPush;
using RadicalTherapy.Utility;
using System.Text;

namespace RadicalTherapy.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IConfiguration configuration;

        public AdminController(ILogger<AdminController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }
        //====================== Radical Reserve =============================
        public IActionResult ConfirmNewRadicalReserve()
        {
            List<RadicalReserveAdmin> reserves = new List<RadicalReserveAdmin>();
            using (UnitOfWork db = new UnitOfWork())
            {

                Utility.Utility ut = new Utility.Utility();
                foreach (var item in db.RadicalReserveRepository.Get(c => c.PayStatus == 1).ToList())
                {
                    item.User = db.UserRepository.GetByID(item.UserId);
                    reserves.Add(new RadicalReserveAdmin { RadialReserve = item, WhatsAppLink1 = ut.WhatsAppLinkRadicaReserve("", item.User.WhatsApp) });
                }
            }
            return View(reserves);
        }    
        public IActionResult FutureRadicalReserve()
        {
            List<RadicalReserveAdmin> reserves = new List<RadicalReserveAdmin>();
            using (UnitOfWork db = new UnitOfWork())
            {
                Utility.Utility ut = new Utility.Utility();
                string WhatsAppLink2 = db.DataRepository.Get(c => c.Key == "whatsAppRadicalReserve2").FirstOrDefault().Value;
                User admin = db.UserRepository.Get(c => c.UserName == "000").FirstOrDefault();
                foreach (var item in db.RadicalReserveRepository.Get(c => c.PayStatus == 3 && c.DateTime > DateTime.Now.AddDays(-1) && c.UserId != admin.ID).ToList())
                {
                    item.User = db.UserRepository.GetByID(item.UserId);
                    reserves.Add(new RadicalReserveAdmin
                    {
                        RadialReserve = item,
                        WhatsAppLink1 = ut.WhatsAppLinkRadicalReserve(
                        item.User.Name,
                        item.DateTime.ToShamsi1().Minute.ToString(),
                        item.DateTime.ToShamsi1().Day.ToString(),
                        item.DateTime.ToShamsi1().Hour.ToString(),
                        DateTool.MonthOfYear(item.DateTime.ToShamsi1()),
                        DateTool.Dayofweek(item.DateTime),
                        item.User.WhatsApp
                        ),
                        WhatsAppLink2 = ut.WhatsAppLinkRadicaReserve(WhatsAppLink2, item.User.WhatsApp)
                    });
                }
                ViewBag.whatsappText = db.DataRepository.Get(c => c.Key == "whatsAppRadicalReserve").FirstOrDefault().Value;
                ViewBag.whatsappText2 = WhatsAppLink2;
            }
            var reservesOrderByDate = reserves.OrderBy(c => c.RadialReserve.DateTime).ToList();
            return View(reservesOrderByDate);
        }
        public IActionResult RejectedRadicalReserve()
        {

            List<RadicalReserveAdmin> reserves = new List<RadicalReserveAdmin>();
            using (UnitOfWork db = new UnitOfWork())
            {
                foreach (var item in db.RadicalReserveRepository.Get(c => c.PayStatus == 10).ToList())
                {
                    item.User = db.UserRepository.GetByID(item.UserId);
                    reserves.Add(new RadicalReserveAdmin
                    {
                        RadialReserve = item
                    });
                }
            }
            var reservesOrderByDate = reserves.OrderBy(c => c.RadialReserve.DateTime).ToList();
            return View(reservesOrderByDate);
        }
        public IActionResult FilterRadicalReserve()
        {
            return View();
        }
        public IActionResult FilterRadicalReserveByDate(DateTime from, DateTime until)
        {
            List<RadicalReserveAdmin> RaicalReserves = new List<RadicalReserveAdmin>();
            using (UnitOfWork db = new UnitOfWork())
            {
                Utility.Utility ut = new Utility.Utility();
                User admin = db.UserRepository.Get(c => c.UserName == "000").FirstOrDefault();
                foreach (var item in db.RadicalReserveRepository.Get(c => c.PayStatus == 3 && c.DateTime > from && c.DateTime < until && c.UserId != admin.ID).ToList())
                {
                    item.User = db.UserRepository.GetByID(item.UserId);
                    RaicalReserves.Add(new RadicalReserveAdmin
                    {
                        RadialReserve = item,
                        WhatsAppLink1 = ut.WhatsAppLinkRadicalReserve(
                        item.User.Name,
                        item.DateTime.ToShamsi1().Month.ToString(),
                        item.DateTime.ToShamsi1().Day.ToString(),
                        item.DateTime.ToShamsi1().Hour.ToString(),
                        DateTool.MonthOfYear(item.DateTime.ToShamsi1()),
                        DateTool.Dayofweek(item.DateTime),
                        item.User.WhatsApp
                        )
                    });
                }
            }
            var orderedRadicalReserves = RaicalReserves.OrderBy(c => c.RadialReserve.DateTime).ToList();
            ViewBag.RadicalReserves = orderedRadicalReserves;
            return View("FilterRadicalReserve");
        }
        [HttpPost]
        public IActionResult SetWhatsAppURLRadicaReserve(string text)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var data = db.DataRepository.Get(c => c.Key == "whatsAppRadicalReserve").First();
                data.Value = text;
                db.DataRepository.Update(data);
                db.Save();
            }
            return RedirectToAction("FutureRadicalReserve");
        }
        [HttpPost]
        public IActionResult SetWhatsAppURLRadicaReserve2(string text)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var data = db.DataRepository.Get(c => c.Key == "whatsAppRadicalReserve2").First();
                data.Value = text;
                db.DataRepository.Update(data);
                db.Save();
            }
            return RedirectToAction("FutureRadicalReserve");
        }
        [HttpPost]
        public IActionResult RejectBankResept(string reason, int userid)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var reserve = db.RadicalReserveRepository.Get(c => c.UserId == userid && c.PayStatus == 1).FirstOrDefault();
                reserve.PayStatus = 10;
                reserve.RegectionReason = reason;
                db.RadicalReserveRepository.Update(reserve);
                db.Save();
                var user = db.UserRepository.GetByID(userid);
                MassageToUser.ReseptIsRejected(user.UserName, user.Name, reason, user.UserNameType);
            }
            return RedirectToAction("ConfirmNewRadicalReserve");
        }

        public IActionResult ConfirmBankResept(int userid)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var reserve = db.RadicalReserveRepository.Get(c => c.UserId == userid && c.PayStatus == 1).FirstOrDefault();
                reserve.PayStatus = 2;
                db.RadicalReserveRepository.Update(reserve);
                db.Save();
                var user = db.UserRepository.GetByID(userid);
                MassageToUser.ReseptIsAccepted(user.UserName, user.Name, user.UserNameType);
            }
            return RedirectToAction("ConfirmNewRadicalReserve");
        }
        public IActionResult ChangeDate(int reserveId)
        {


            ViewBag.dateList = Utility.Utility.CreateRadicalReserveDateTimes();
            ViewBag.ReservedTimes = Utility.Utility.ReservedTimes();
            ViewBag.reserveId = reserveId;

            return View();
        }
        [HttpPost]
        public IActionResult ChangeDate(int reserveId, DateTime datetime)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var reserve = db.RadicalReserveRepository.GetByID(reserveId);
                reserve.DateTime = datetime;
                db.RadicalReserveRepository.Update(reserve);
                db.Save();
            }
            return RedirectToAction("FutureRadicalReserve");
        }
        public IActionResult FillRadicalReserves()
        {
            List<RadicalReserve> reserves = new List<RadicalReserve>();
            using (UnitOfWork db = new UnitOfWork())
            {
                var _reserves = db.RadicalReserveRepository.Get(c => c.DateTime > DateTime.Now.Date && c.PayStatus == 3).ToList();
                foreach (var item in _reserves)
                {
                    var user = db.UserRepository.GetByID(item.UserId);
                    var Res = item;
                    item.User = user;
                    reserves.Add(item);
                }
            }

            ViewBag.dateList = Utility.Utility.CreateRadicalReserveDateTimes();
            ViewBag.reserves = reserves;
            return View();
        }
        public IActionResult AdminTakeRadicalReserve(DateTime datetime)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                db.RadicalReserveRepository.Insert(new RadicalReserve
                {
                    DateTime = datetime,
                    UserId = db.UserRepository.Get(c => c.UserName == "000").FirstOrDefault().ID,
                    PayStatus = 3,
                    Price = 0,
                    ReseptPic = Encoding.ASCII.GetBytes("")
                });
                db.Save();
            }
            return RedirectToAction("FillRadicalReserves");
        }
        public IActionResult AdminReleaseRadicalReserve(int reserveId)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                db.RadicalReserveRepository.Delete(reserveId);
                db.Save();
            }
            return RedirectToAction("FillRadicalReserves");
        }
        public IActionResult DeleteRadicalReserve(int reserveId, string returnAction)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                db.RadicalReserveRepository.Delete(reserveId);
                db.Save();
                return RedirectToAction(returnAction);
            }
        }
        [HttpPost]
        public IActionResult SendCustomMassageToUser(string massage, int userId)
        {
            User user = new User();
            using (UnitOfWork db = new UnitOfWork())
            {
                user = db.UserRepository.GetByID(userId);
            }
            MassageToUser.CustomMassage(user.UserName, user.Name, massage, user.UserNameType);
            return RedirectToAction("FutureRadicalReserve");
        }
        public IActionResult ChangeUserWhatsappnumber(string whatsApp, int userId)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var user = db.UserRepository.GetByID(userId);
                user.WhatsApp = whatsApp;
                db.UserRepository.Update(user);
                db.Save();
            }
            return RedirectToAction("FutureRadicalReserve");
        }
        //=====================Radical Reserve===========================

        //=====================Customer Video============================
        public IActionResult customerVideo()
        {
            List<CustomerVideo> Videos = new List<CustomerVideo>();
            using (UnitOfWork db = new UnitOfWork())
            {
                Videos = db.CustomerVideosRepository.Get().OrderBy(c=>c.Sequence).ToList();
            }
            return View(Videos);
        }
        public IActionResult AddCustomerVideo(int id)
        {
            if (id == 0)
            {
                return View(new CustomerVideo { Description="", Link="",Sequence=0,Id=0});
            }
            else
            {
                using (UnitOfWork db=new UnitOfWork())
                {
                    return View(db.CustomerVideosRepository.GetByID(id));
                }
             
            }
           
        }
        [HttpPost]
        public IActionResult AddOrEditVideo(string Description, string LinkText, int Sequence,int id)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                CustomerVideo video = new CustomerVideo { Description = Description, Link = LinkText, Sequence = Sequence };
               
                if (id==0)
                {
                    db.CustomerVideosRepository.Insert(video);
                }
                else
                {
                    video.Id = id;
                    db.CustomerVideosRepository.Update(video);
                }
                db.Save();
            }
            return RedirectToAction("customerVideo");
        }
        [HttpPost]
        public IActionResult DeleteVideo(int Id)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                db.CustomerVideosRepository.Delete(Id);
                db.Save();
            }
            return RedirectToAction("customerVideo");
        }
        //===================== Customer Video ============================

        //===================== Pre Reservation ============================
        public IActionResult SelectReserve(DateTime from, DateTime until)
        {

            List<Reserve> Reserves = new List<Reserve>();
            using (UnitOfWork db = new UnitOfWork())
            {
                Reserves = db.ReserveRepository.Get(r => r.Datetime >= from && r.Datetime <= until).ToList();
            }
            return View(Reserves);
        }
        [HttpPost]
        public IActionResult getReserves(DateTime from, DateTime until)
        {
            return RedirectToAction("SelectReserve", new { from = from, until = until });
        }
        public IActionResult Reserves()
        {
            List<Reserve> _reserves = new List<Reserve>();
            List<ReserveAdmin> Reserves = new List<ReserveAdmin>();
            using (UnitOfWork db = new UnitOfWork())
            {
                int questionId = db.QuestionRepository.Get(c => c.q1 == 1000).FirstOrDefault().Id;

                _reserves = db.ReserveRepository.Get(r => r.Datetime.Date >= DateTime.Now.Date ).ToList();
                foreach (var item in _reserves)
                {
                    PersianDateTime datetime = item.Datetime.ToShamsi1();
                    string month = DateTool.MonthOfYear(datetime);
                    string day = DateTool.Dayofweek(item.Datetime);
                    string d = datetime.Day.ToString();
                    string m = datetime.Minute.ToString();
                    string h = datetime.Hour.ToString();
                    string url = WhatsAppLink(item.Name, m, d, h, month, day, item.Mobile);
                    Reserves.Add(new ReserveAdmin { Datetime = item.Datetime, Mobile = item.Mobile, Name = item.Name, Message = url, Id = item.Id, QuestionId = item.QuestionId });
                }

            }
            var newreserves = Reserves.OrderBy(r => r.Datetime).ToList();
            return View(newreserves);
        }

        public string WhatsAppLink(string name, string m, string d, string h, string month, string day, string mobile)
        {
            string URL = null;
            using (UnitOfWork db = new UnitOfWork())
            {
                var data = db.DataRepository.Get(c => c.Key == "whatsApp").First().Value;
                var text = data.Replace("@", name).Replace("#", day).Replace("%", month)
                    .Replace("*", m).Replace("!", h).Replace("~", d).Replace(" ", "%20").Replace("$", "%0a");
                URL = $"https://wa.me/" + mobile + "?text=" + text;
            }
            return URL;
        }

        [HttpPost]
        public IActionResult SetLink(int Id, string number)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var reserve = db.ReserveRepository.GetByID(Id);
                reserve.Mobile = number;
                db.ReserveRepository.Update(reserve);
                db.Save();
            }
            return Json("");
        }
        public IActionResult SetWhatsAppURL(string text)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var data = db.DataRepository.Get(c => c.Key == "whatsApp").First();
                data.Value = text;
                db.DataRepository.Update(data);
                db.Save();
            }
            return RedirectToAction("Reserves");
        }
        public IActionResult DeleteReserve(int Id)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var reserve = db.ReserveRepository.GetByID(Id);
                db.ReserveRepository.Delete(reserve);
                db.Save();
            }
            return RedirectToAction("Reserves");
        }
        //===================== Pre Reservation ============================

        //===================== Comments ===========================

        public IActionResult NewComments()
        {
            List<CommentModel> Comments = new List<CommentModel>();
            dynamic mymodel = new ExpandoObject();
            List<Subject> SubList=new List<Subject>();
            using (UnitOfWork db = new UnitOfWork())
            {
                var _comments = db.CommentRepository.Get(c => c.Status == false && c.Checked == false);
                foreach (var item in _comments)
                {
                    string[] Answers = null;
                    if (item.Answer != null)
                    {
                        Answers = item.Answer.Split("%").ToArray();

                    }
                    var Texts = item.Text.Split("%").ToArray();
                    Comments.Add(new CommentModel { Answer = Answers, Text = Texts, Id = item.Id, subjectId = item.subjectId, UserName = item.UserName });
                }
                foreach (var item in Comments)
                {
                    SubList.Add(db.SubjectRepository.GetByID(item.subjectId));
                }

                mymodel.SubList = SubList.Distinct().ToList();
                mymodel.Comments = Comments;
            }
            return View(mymodel);
        }
        public IActionResult DeleteComment()
        {
            List<Subject> SubList = new List<Subject>();
            using (UnitOfWork db = new UnitOfWork())
            {
                SubList = db.SubjectRepository.Get().ToList();
            }
            return View(SubList);
        }

        public IActionResult DelCmt(int subjectId)
        {
            List<CommentModel> Comments = new List<CommentModel>();
            using (UnitOfWork db = new UnitOfWork())
            {
                var cmts = db.CommentRepository.Get(c => c.subjectId == subjectId);
                foreach (var item in cmts)
                {
                    Comments.Add(new CommentModel { Id = item.Id, UserName = item.UserName, Text = GetCommentTexts(item), Status = item.Status });
                }
            }
            ViewBag.subjectId = subjectId;
            ViewData["comments"] = Comments;
            return View();
        }
        public string[] GetCommentTexts(Comment item)
        {
            var _texts = item.Text.Split("%").ToArray();
            string[] _answers = null;
            if (item.Answer != null)
            {
                _answers = item.Answer.Split("%").ToArray();
            }
            List<string> Text = new List<string>();
            for (int i = 0; i < _texts.Length; i++)
            {
                if (i + 1 != _texts.Length)
                {
                    Text.Add(_texts[i]);
                    if (_answers != null)
                    {
                        Text.Add(_answers[i]);
                    }
                }
                else
                {
                    Text.Add(_texts[i]);
                    if (item.Status)
                    {
                        Text.Add(_answers[i]);
                    }
                }
            }
            return Text.ToArray();
        }
        [HttpPost]
        public IActionResult DeletePartOfCmt(DeleteComment model, int subjectId)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    var item = db.CommentRepository.GetByID(model.Id);
                    if (model.Index == 0)
                    {
                        db.CommentRepository.Delete(item);
                        db.Save();
                        return RedirectToAction("DelCmt", new { subjectId = subjectId });
                    }
                    var texts = GetCommentTexts(item);
                    string Text = "";
                    string Answer = null;
                    for (int i = 0; i < model.Index; i++)
                    {
                        if (model.Index == 1)
                        {
                            item.Text = texts[0];
                            item.Answer = null;
                            item.Status = false;
                            item.Checked = false;
                            db.CommentRepository.Update(item);
                            db.Save();
                            return RedirectToAction("DelCmt", new { subjectId = subjectId });
                        }
                        else
                        {
                            if (i % 2 == 0)
                            {
                                if (i == 0)
                                {
                                    Text = texts[i];
                                }
                                else
                                {
                                    Text += "%" + texts[i];
                                }
                            }
                            else
                            {
                                if (i == 1)
                                {
                                    Answer = texts[i];
                                }
                                else
                                {
                                    Answer += "%" + texts[i];
                                }
                            }
                        }
                    }
                    item.Text = Text;
                    item.Answer = Answer;
                    item.Checked = false;
                    if (model.Index % 2 == 0)
                    {
                        item.Status = true;
                    }
                    else
                    {
                        item.Status = false;
                    }
                    db.CommentRepository.Update(item);
                    db.Save();
                }
                return RedirectToAction("DelCmt", new { subjectId = subjectId });
            }
            return RedirectToAction("DelCmt", new { subjectId = subjectId });
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checked(int Id)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var cmt = db.CommentRepository.GetByID(Id);
                cmt.Checked = true;
                db.CommentRepository.Update(cmt);
                db.Save();
            }
            return Json("");
        }
        [HttpPost]
        public IActionResult Reply(int Id, string text, int subjectId)
        {
            text = text.Replace("%", "");
            using (UnitOfWork db = new UnitOfWork())
            {
                var comment = db.CommentRepository.GetByID(Id);
                string answer = "";
                if (comment.Answer == null)
                {
                    answer = text;
                }
                else
                {
                    answer = comment.Answer + "%" + text;

                }
                comment.Status = true;
                comment.Answer = answer;
                db.CommentRepository.Update(comment);
                db.Save();
                var client = db.ClientRepository.GetByID(comment.ClientID);

                try
                {
                    PushSubscription subscription = new PushSubscription(client.endpoint, client.p256dh, client.auth);
                    var subject = configuration["VAPID:subject"];
                    var publicKey = configuration["VAPID:publicKey"];
                    var privateKey = configuration["VAPID:privateKey"];

                    var vapidDetails = new VapidDetails(subject, publicKey, privateKey);

                    var webPushClient = new WebPushClient();
                    var subjectUrl = db.SubjectRepository.GetByID(subjectId).English;
                    string subjectTitle = db.SubjectRepository.GetByID(subjectId).Tite;
                    string messsge = "";
                    if (subjectTitle== "رضایت مراجعین عزیز")
                    {
                        messsge = text + "%" + "Home" + "/" + "CustomerVideo"  + "?" + "element=" + "TextAns-" + Id + "-Last";
                    }
                    else
                    {
                        messsge = text + "%" + "Subjects" + "/" + "Index" + "/" + subjectUrl + "?" + "element=" + "TextAns-" + Id + "-Last";
                    }
                     
                    webPushClient.SendNotification(subscription, messsge, vapidDetails);

                }
                catch (Exception e)
                {
                    var message = e.Message.ToString();
                }

            }
            return Json(text);
        }
        //===================== Comments ===========================


        public IActionResult Statistics()
        {
            List<string> OS = new List<string>();
            List<OsCount> osCount = new List<OsCount>();
            using (UnitOfWork db = new UnitOfWork())
            {
                var list = db.StatisticsRepository.Get();
                foreach (var item in list)
                {
                    OS.Add(item.OS);
                }
                var OsList = OS.Distinct();

                foreach (var item in OsList)
                {
                    osCount.Add(new OsCount { OS = item, Count = db.StatisticsRepository.Get(s => s.OS == item).Count() });
                }

            }

            return View(osCount);
        }

    }
}









