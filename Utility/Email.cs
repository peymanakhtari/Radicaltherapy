using RadicalTherapy.Data.Repository;
using System;
using System.Linq;
using System.Net.Mail;


namespace RadicalTherapy.Utility
{
    public class Email
    {
        public static void Send(string subject, string body)
        {
            MailMessage mail = new MailMessage();

            mail.To.Add("peyman.akhtari.73@gmail.com");
            mail.From = new MailAddress("peyman@Radicaltherapy.ir");
            mail.Subject = "رادیکال تراپی_" + subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("mail.Radicaltherapy.ir", 25);

            client.Credentials = new System.Net.NetworkCredential("peyman@Radicaltherapy.ir", "VwGs2807lu");
            client.Send(mail);
        }
     
        public static void SendToUser(string subject, string body,string user)
        {
            MailMessage mail = new MailMessage();

            mail.To.Add(user);
            mail.From = new MailAddress("peyman@Radicaltherapy.ir");
            mail.Subject = "رادیکال تراپی_" + subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("mail.Radicaltherapy.ir", 25);

            client.Credentials = new System.Net.NetworkCredential("peyman@Radicaltherapy.ir", "VwGs2807lu");
            client.Send(mail);
        }
        public static void SendEmailWithTemplate(string body, string username)
        {
            MailMessage mail = new MailMessage();

            mail.To.Add(username);
            mail.From = new MailAddress("admin@Radicaltherapy.ir");
            mail.Subject = "مجموعه تراپی";
            mail.IsBodyHtml = true;
            mail.Body = body;

            SmtpClient client = new SmtpClient("mail.Radicaltherapy.ir", 25);

            client.Credentials = new System.Net.NetworkCredential("admin@Radicaltherapy.ir", "VwGs2807lu");
            client.Send(mail);
        }
       public static void SendReserveToAdmin(string username, string name, DateTime dateTime ,int id)
        {
            string _dateTime = Utility.ConvertDatetimeToString(dateTime);
            string body = $@" <div style='width:100%;max-width:400px;;height: 600px;margin: auto;'>
        <div style='width: 100%;background-color: rgb(189, 151, 197);padding: 1rem;font-family: Shabnam;'>
            <h4 style='float: right;font-size: 1.5rem;margin-right: 1rem; '>رزرو رادیکال تراپی جدید</h4>
            <img style='width:100px' src='https://radicaltherapy.ir/img/alizare.png' alt=''>
            <p dir='rtl' style='text-align: right;width: 100%;font-size: 1.2rem;font-weight: bold;'>نام: {name} <br> واتسآپ {username}</p>
            <p style='text-align: right;'>
                <div dir='rtl' style='background-color: white;padding: 10px 8px 8px 20px;font-size: 1.2rem;border-radius: 4px;display: block;text-align: justify;'>
                 {_dateTime}<br><a href='https://radicaltherapy.ir/admin/FutureRadicalReserve?id={id}'>صفحه رزرو ها</a>
             
</div>
            </p>
        </div>
    </div>";
             // SendEmailWithTemplate(body, "love1love2love7@gmail.com");
            SendEmailWithTemplate(body, "love1love2love7@gmail.com");
        }
   
       
        public static void sendReservePicToaAdmin(int userId)
        {
            string Name;
            string whatsapp;
            string username;
            string pic;
            using (UnitOfWork db = new UnitOfWork())
            {
                var user = db.UserRepository.Get(c => c.ID == userId).FirstOrDefault();
                Name = user.Name;
                whatsapp = user.WhatsApp;
                username = user.UserName;
                pic = "c_" + userId.ToString() + ".jpg";
            }
            string imageLink = $"";
            string body = $"     <div> <a style='background-color: blue; color: white; padding: 3rem; font-size: 2rem; ' href='https://radicaltherapy.ir/Admin/ConfirmNewRadicalReserve'> لینک رزرو تایید نشده</a></div>";
            MailMessage mail = new MailMessage();

            mail.To.Add("love1love2love7@gmail.com");
            mail.From = new MailAddress("peyman@Radicaltherapy.ir");
            mail.Subject = "رسید جدید";
            mail.IsBodyHtml = true;
            mail.Body = body;

            SmtpClient client = new SmtpClient("mail.Radicaltherapy.ir", 25);

            client.Credentials = new System.Net.NetworkCredential("peyman@Radicaltherapy.ir", "VwGs2807lu");
            client.Send(mail);

        }

    }

}
