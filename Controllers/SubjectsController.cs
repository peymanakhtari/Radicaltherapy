using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RadicalTherapy.Data.model;
using RadicalTherapy.Data.Repository;
using RadicalTherapy.Models;
using RadicalTherapy.Utility;
using RadicalTherapy.Utility.Convertor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RadicalTherapy.Controllers
{
    public class SubjectsController : Controller
    {
        public IActionResult Index(string id)
        {
            Subject subject;
            List<Content> content;
            using (UnitOfWork db = new UnitOfWork())
            {
                subject = db.SubjectRepository.Get(c => c.English == id).First();
                content = db.ContentRepository.Get(c => c.SubjectId == subject.Id).ToList();
            }
            List<CommentModel> _Comments = Utility.Utility.Comments(subject.Id);
            ViewBag.type = subject.Tite;
            ViewBag.subjectId = subject.Id;
            ViewBag.contents=content.OrderBy(c=>c.Sequence).ToList();
            ViewBag.titleName=subject.Tite;
            ViewBag.decription = subject.SmallText;
            return View(_Comments);
        }
        [Route("subjects/Index/6")]
        public IActionResult oldurl_radicaltherpay()
        {
            return RedirectToAction("Index", new { id = "radical_therapy" });
        }
        [HttpPost]
        public IActionResult UpdateComment(string newtext, int id)
        {
            try
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    var comment = db.CommentRepository.Get(c => c.Id == id).First();
                    if (comment.Status)
                    {
                        comment.Text += "%" + newtext.Replace("%", "");
                        comment.Status = false;
                        db.CommentRepository.Update(comment);
                        db.Save();
                        return new JsonResult("");
                    }

                }

            }
            catch (Exception e)
            {
                Email.Send("Subjects-UpdateComment", e.ToString());
            }
            return new JsonResult("");
        }
        [HttpPost]
        public IActionResult DeleteComment(int Id)
        {
            string value = "";
            try
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    var comment = db.CommentRepository.Get(c => c.Id == Id).First();
                    if (comment.Text.Contains("%"))
                    {
                        var lastComment = comment.Text.Split("%").Last();
                        var text = comment.Text.Replace("%" + lastComment, "");
                        comment.Text = text;
                        comment.Status = true;
                        db.CommentRepository.Update(comment);
                    }
                    else
                    {
                        db.CommentRepository.Delete(comment);
                        value = "affectLocalStorage";

                    }
                    db.Save();
                }
            }
            catch (Exception e)
            {
                Email.Send("Subjects-DeleteComment", e.ToString());
            }

            return Json(value);
        }
        [HttpPost]
        public IActionResult AddComment(string text, string username, int subjectId, string auth, string p256dh, string endpoint)
        {
            Comment comment = new Comment();
            using (UnitOfWork db = new UnitOfWork())
            {
                Client client = db.ClientRepository.Get(c => c.endpoint == "0").FirstOrDefault();
                if (endpoint != null)
                {
                    db.ClientRepository.Insert(new Client { client = username, auth = auth, p256dh = p256dh, endpoint = endpoint });
                    db.Save();
                    client = db.ClientRepository.Get(c => c.client == username && c.endpoint == endpoint && c.p256dh == p256dh && c.auth == auth).First();
                }
                db.CommentRepository.Insert(new Comment()
                {
                    Status = false,
                    Text = text.Replace("%", ""),
                    subjectId = subjectId,
                    UserName = username,
                    ClientID = client.Id
                });
                db.Save();
                comment = db.CommentRepository.Get(c => c.Text == text && c.subjectId == subjectId && c.UserName == username).First();
            }
            return Json(comment.Id);
        }

        public IActionResult AddClient(string auth, string endpoint, string p256dh, string Id)
        {
            try
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    var comment = db.CommentRepository.GetByID(Convert.ToInt32(Id));
                    db.ClientRepository.Insert(new Client() { auth = auth, endpoint = endpoint, p256dh = p256dh, client = comment.UserName });
                    db.Save();
                    var client = db.ClientRepository.Get(c => c.endpoint == endpoint && c.auth == auth && c.p256dh == p256dh).First();
                    comment.Client = client;
                    db.CommentRepository.Update(comment);
                    db.Save();
                }
            }
            catch (Exception e)
            {
                Email.Send("Subjects-AddClient", e.ToString());
            }

            return Json("");
        }
        [HttpPost]
        public IActionResult EmailError(string text)
        {
            Email.Send("subjects-Addcomment", text);
            return Json("");
        }
        public IActionResult Fix()
        {
            List<Comment> cmts = new List<Comment>();
            using (UnitOfWork db = new UnitOfWork())
            {
                cmts = db.CommentRepository.Get().ToList();
                foreach (var item in cmts)
                {
                    List<string> Answers = new List<string>();
                    List<string> Texts = item.Text.Split("%").ToList();
                    if (item.Answer != null)
                    {
                        Answers = item.Answer.Split("%").ToList();
                    }
                    if (Answers.Count == Texts.Count)
                    {
                        if (!item.Status)
                        {
                            item.Status = true;
                            db.CommentRepository.Update(item);
                            db.Save();
                        }
                    }
                    else if (Texts.Count == (Answers.Count + 1))
                    {
                        if (item.Status)
                        {
                            item.Status = false;
                            db.CommentRepository.Update(item);
                            db.Save();
                        }
                    }
                    else
                    {
                        if (Answers != null)
                        {
                            db.CommentRepository.Delete(item);
                            db.Save();
                        }
                    }

                }
            }
            return new EmptyResult();
        }

    }

}
