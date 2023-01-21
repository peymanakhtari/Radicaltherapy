using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadicalTherapy.Data.model;
using RadicalTherapy.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadicalTherapy.Controllers
{
    public class AdminMainPageController : Controller
    {
        public IActionResult Index()
        {
            List<Subject> subs;
            using (UnitOfWork db = new UnitOfWork())
            {
                subs = db.SubjectRepository.Get(c => c.Sequence != 0).ToList();

            }
            var orderedSubjects = subs.OrderByDescending(c => c.Sequence).ToList();
            return View(orderedSubjects);
        }
        public IActionResult Subject(int subjectId)
        {
            Subject subject;
            using (UnitOfWork db = new UnitOfWork())
            {
                subject = db.SubjectRepository.GetByID(subjectId);
            }
            return View(subject);
        }
        [HttpPost]
        public IActionResult Subject(Subject subject, IFormFile img)
        {
            Subject subject1;
            using (UnitOfWork db = new UnitOfWork())
            {
                subject1 = db.SubjectRepository.GetByID(subject.Id);
                if (img != null)
                {
                    subject.CoverPic = Utility.Utility.uploadImage(img, "UploadImage//subject",subject1.CoverPic);
                }
                else
                {
                    subject.CoverPic = subject1.CoverPic;
                }
            }
            using (UnitOfWork db = new UnitOfWork())
            {
                db.SubjectRepository.Update(subject);
                db.Save();

            }
            return RedirectToAction("Index");
        }
        public IActionResult AddNewSubject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewSubject(Subject subject, IFormFile img)
        {
            subject.CoverPic = Utility.Utility.uploadImage(img, "UploadImage//subject");
            using (UnitOfWork db = new UnitOfWork())
            {
                db.SubjectRepository.Insert(subject);
                db.Save();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Content(int contentId)
        {
            Content content;
            using (UnitOfWork db = new UnitOfWork())
            {
                content = db.ContentRepository.GetByID(contentId);
            }
            return View(content);
        }
        [HttpPost]
        public IActionResult Content(Content content, string base64Coverpic)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var cnt = db.ContentRepository.GetByID(content.Id);
                if (base64Coverpic != null)
                {
                    content.Img = Encoding.ASCII.GetBytes(base64Coverpic);
                }
                else
                {
                    content.Img = cnt.Img;
                }
            }
            using (UnitOfWork db = new UnitOfWork())
            {
                db.ContentRepository.Update(content);
                db.Save();

            }
            return RedirectToAction("ContentList", new { subjectId = content.SubjectId });
        }
        public IActionResult AddNewContent(int subjectId)
        {
            ViewBag.subjectId = subjectId;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewContent(Content content, string base64Coverpic)
        {
            if (base64Coverpic != null)
            {
                content.Img =Encoding.ASCII.GetBytes(base64Coverpic);
            }

            using (UnitOfWork db = new UnitOfWork())
            {
                db.ContentRepository.Insert(content);
                db.Save();
            }
            return RedirectToAction("ContentList", new { subjectId = content.SubjectId });
        }
        public IActionResult ContentList(int subjectId)
        {
            List<Content> contentList = new List<Content>();
            using (UnitOfWork db = new UnitOfWork())
            {
                contentList = db.ContentRepository.Get(c => c.SubjectId == subjectId).ToList();
                ViewBag.subjectTitle = db.SubjectRepository.GetByID(subjectId).Tite;
            }
            ViewBag.subjectId = subjectId;
            var orderedContentList = contentList.OrderBy(c => c.Sequence).ToList();
            return View(orderedContentList);
        }
        [HttpPost]
        public IActionResult DeleteContent(int contentId, int subjectId)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                db.ContentRepository.Delete(contentId);
                db.Save();
            }
            return RedirectToAction("ContentList", new { subjectId = subjectId });
        }
    }
}
