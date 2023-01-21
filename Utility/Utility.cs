using Microsoft.AspNetCore.Http;
using RadicalTherapy.Data.Repository;
using RadicalTherapy.Models;
using RadicalTherapy.Utility.Convertor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RadicalTherapy.Utility
{
    public class Utility
    {
        public string WhatsAppLinkRadicaReserve(string massage, string whatsapp)
        {
            return $"https://wa.me/" + whatsapp + "?text=" + massage;
        }
        public string WhatsAppLinkRadicalReserve(string name, string m, string d, string h, string mounth, string day, string mobile)
        {
            string URL = null;
            using (UnitOfWork db = new UnitOfWork())
            {
                var data = db.DataRepository.Get(c => c.Key == "whatsAppRadicalReserve").First().Value;
                var text = data.Replace("@", name).Replace("#", day).Replace("%", mounth)
                    .Replace("*", m).Replace("!", h).Replace("~", d).Replace(" ", "%20").Replace("$", "%0a").Replace("+","%2b");
                URL = $"https://wa.me/" + mobile + "?text=" + text;
            }
            return URL;
        }
        public static List<RadicaReserveDatetimes> CreateRadicalReserveDateTimes()
        {
            List<RadicaReserveDatetimes> datesInfo = new List<RadicaReserveDatetimes>();
            List<DateTime> dates = new List<DateTime>();
            List<DateTime> times = new List<DateTime>();
            using (UnitOfWork db = new UnitOfWork())
            {
                var list = db.DataRepository.Get(c => c.Key == "time").ToList();
               
                for (int i = 0; i < 70; i++)
                {
                    dates.Add(DateTime.Now.AddDays(i + 1));
                }
                foreach (DateTime item in dates)
                {
                    List<DateTime> datelist= new List<DateTime>();
                    foreach (var time in list)
                    {
                        char[] spearator = { '@' };
                        int hour = Convert.ToInt32(time.Value.Split(spearator)[0]);
                        int minute = Convert.ToInt32(time.Value.Split(spearator)[1]);
                        datelist.Add(new DateTime(item.Year, item.Month, item.Day, hour, minute,0));
                    }
                    datesInfo.Add(new RadicaReserveDatetimes
                    {
                        
                        Times = datelist.OrderBy(c=>c).ToList(),
                        DayOfWeek = DateTool.Dayofweek(item.ToShamsi1()),
                        MounthOfYear = DateTool.MonthOfYear(item.ToShamsi1())
                    });
                }
                return datesInfo;
            }
        }
        public static List<DateTime> ReservedTimes()
        {
            List<DateTime> reservedTimes = new List<DateTime>();
            using (UnitOfWork db = new UnitOfWork())
            {
                var reserves = db.RadicalReserveRepository.Get(c => c.DateTime > DateTime.Now.Date && c.PayStatus == 3);
                foreach (var item in reserves)
                {
                    if (item.DateTime > DateTime.Now)
                    {
                        reservedTimes.Add(item.DateTime);
                    }
                }
            }
            return reservedTimes;
        }
        public static string ConvertDatetimeToString(DateTime dateTime)
        {
            string weekDay = DateTool.Dayofweek(dateTime);
            string mounthOfYear = DateTool.MonthOfYear(dateTime.ToShamsi1());
            string day = dateTime.ToShamsi1().Day.ToString();
            string minute = dateTime.Minute.ToString();
            if (dateTime.Minute == 0)
            {
                minute = "00";
            }
            string dateime = $"{weekDay} {day} {mounthOfYear} ، ساعت  {minute} : {dateTime.Hour} ";
            return dateime;
        }
        public static byte[] convertImage(IFormFile picture)
        {
            using (var ms = new MemoryStream())
            {
                picture.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);
                return Encoding.ASCII.GetBytes(s);

            }
        }
        public static List<CommentModel> Comments(int subjectId)
        {
            List<CommentModel> comments = new List<CommentModel>();

            try
            {
                using (UnitOfWork db = new UnitOfWork())
                {

                    var _Comments = db.CommentRepository.Get(c => c.subjectId == subjectId);
                    string[] Answers = null;

                    foreach (var item in _Comments)
                    {
                        if (item.Answer != null)
                        {
                            Answers = item.Answer.Split("%").ToArray();

                        }
                        var Texts = item.Text.Split("%").ToArray();
                        comments.Add(new CommentModel { Answer = Answers, Text = Texts, Id = item.Id, UserName = item.UserName, Status = item.Status });
                    }
                }
            }
            catch (Exception e)
            {
                Email.Send("subjects-comments", e.ToString());
            }

            return comments;
        }
        public static string changePersianNumbersToEnglish(string input)
        {
            string[] persian = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

            for (int j = 0; j < persian.Length; j++)
                input = input.Replace(persian[j], j.ToString());

            return input;
        }

        public static string uploadImage(IFormFile img, string path)
        {
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\" + path);
            var fileName = Guid.NewGuid().ToString() + ".jpg";
            string filePath = Path.Combine(uploadsFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                img.CopyTo(fileStream);
            }
            return fileName;
        }
        public static string uploadImage(IFormFile img, string path, string fileName)
        {
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\" + path);
            string filePath = Path.Combine(uploadsFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                img.CopyTo(fileStream);
            }
            return fileName;
        }
    }

}
