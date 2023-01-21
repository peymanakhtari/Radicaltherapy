using RestSharp;
using System;
using RadicalTherapy.Utility.Convertor;

namespace RadicalTherapy.Utility
{
    public class MassageToUser
    {
        public static void ConfirmationCode(string username, string code, bool method)
        {
            if (method)
            {
                var client = new RestClient("http://188.0.240.110/api/select");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\"op\" : \"patternV2\"" +
                    ",\"user\" : \"09171898681\"" +
                    ",\"pass\":  \"@13931393Pa\"" +
                    ",\"fromNum\" : \"+983000505\"" +
                    $",\"toNum\": \"{username}\"" +
                    ",\"patternCode\": \"8hpawyxc5a\"" +
                    ",\"inputData\" : {\"code\": \"" + code + "\"}}"
                    , ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            else
            {
                string body = @$"<link rel='stylesheet' href='https://radicaltherapy.ir/css/font-sobhan.css'>
<div style='width: 100%;'>
        <div style='width:100%;max-width:400px;;height: 600px;margin: auto;'>
            <div style='width: 100%;background-color: rgb(189, 151, 197);padding: 1rem;font-family: Shabnam;'>
                <h4 style='float: right;font-size: 1.5rem;margin-right: 1rem; '>مجموعه رادیکال تراپی</h4>
                <img style='width:100px' src='https://radicaltherapy.ir/img/alizare.png' alt=''>
                <p style='text-align: center;width: 100%;font-size: 1.2rem;font-weight: bold;'>کد تایید شما</p>
                <p style='text-align: center;'><span style='letter-spacing: .8rem;background-color: white;padding: 10px 8px 8px 20px;font-size: 1.5rem;border-radius: 4px;'> {code}</span></p>
            </div>
        </div>
    </div>";
                Email.SendEmailWithTemplate(body, username);
            }
        }
        public static void ReseptIsUploaded(string username, string name, bool method)
        {
            if (method)
            {
                var client = new RestClient("http://188.0.240.110/api/select");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\"op\" : \"patternV2\"" +
                    ",\"user\" : \"09171898681\"" +
                    ",\"pass\":  \"@13931393Pa\"" +
                    ",\"fromNum\" : \"+983000505\"" +
                    $",\"toNum\": \"{username}\"" +
                    ",\"patternCode\": \"2s5iflm9fe\"" +
                    ",\"inputData\" : {\"name\": \"" + name + "\"}}"
                    , ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            else
            {
                string body = @$" <link rel='stylesheet' href='https://radicaltherapy.ir/css/font-sobhan.css'>
 <div style='width: 100%;'>
        <div style='width:100%;max-width:400px;;height: 600px;margin: auto;'>
            <div style='width: 100%;background-color: rgb(189, 151, 197);padding: 1rem;font-family: Shabnam;'>
                <h4 style='float: right;font-size: 1.5rem;margin-right: 1rem; '>مجموعه رادیکال تراپی</h4>
                <img style='width:100px' src='https://radicaltherapy.ir/img/alizare.png' alt=''>
                <p dir='rtl' style='text-align: right;width: 100%;font-size: 1.2rem;font-weight: bold;'>کاربر گرامی : {name}</p>
                <p style='text-align: right;'>
                    <div dir='rtl' style='background-color: white;padding: 10px 8px 8px 20px;font-size: 1.2rem;border-radius: 4px;display: block;text-align: justify;'>
                         فیش بانکی شما تا لحظاتی دیگرتوسط ادمین سایت تایید می شود سپس می توانید تایم رادیکال تراپی خود را رزرو کنید </div>
                </p>
            </div>
        </div>
    </div>";
                Email.SendEmailWithTemplate(body, username);
            }
        }
        public static void ReseptIsAccepted(string username, string name, bool method)
        {
            if (method)
            {
                var client = new RestClient("http://188.0.240.110/api/select");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\"op\" : \"patternV2\"" +
                    ",\"user\" : \"09171898681\"" +
                    ",\"pass\":  \"@13931393Pa\"" +
                    ",\"fromNum\" : \"+983000505\"" +
                    $",\"toNum\": \"{username}\"" +
                    ",\"patternCode\": \"oztv3ogbqx\"" +
                    ",\"inputData\" : {\"name\": \"" + name + "\"}}"
                    , ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            else
            {
                string body = $@"   <link rel='stylesheet' href='https://radicaltherapy.ir/css/font-sobhan.css'>
<div style='width: 100%;'>
        <div style='width:100%;max-width:400px;;height: 600px;margin: auto;'>
            <div style='width: 100%;background-color: rgb(189, 151, 197);padding: 1rem;font-family: Shabnam;'>
                <h4 style='float: right;font-size: 1.5rem;margin-right: 1rem; '>مجموعه رادیکال تراپی</h4>
                <img style='width:100px' src='https://radicaltherapy.ir/img/alizare.png' alt=''>
                <p dir='rtl' style='text-align: right;width: 100%;font-size: 1.2rem;font-weight: bold;'>کاربر گرامی : {name}</p>
                <p style='text-align: right;'>
                    <div dir='rtl' style='background-color: white;padding: 10px 8px 8px 20px;font-size: 1.2rem;border-radius: 4px;display: block;text-align: justify;'>
                        فیش بانکی شما تایید شده. اکنون می توانید تایم رادیکال تراپی خود را از طریق لینک زیر انتخاب کنید <br><a href='https://radicaltherapy.ir/user'>رزرو تایم رادیکال تراپی</a></div>
                </ p >
            </ div >
        </ div >
    </ div > ";
                Email.SendEmailWithTemplate(body, username);
            }
        }
        public static void ReseptIsRejected(string username, string name, string reason, bool method)
        {
            if (method)
            {
                var client = new RestClient("http://188.0.240.110/api/select");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\"op\" : \"patternV2\"" +
                    ",\"user\" : \"09171898681\"" +
                    ",\"pass\":  \"@13931393Pa\"" +
                    ",\"fromNum\" : \"+983000505\"" +
                    $",\"toNum\": \"{username}\"" +
                    ",\"patternCode\": \"voekh44qtm\"" +
                    ",\"inputData\" : {\"name\": \"" + name + "\",\"reason\": \"" + reason + "\"}}"
                    , ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            else
            {
                string body = $@"   <link rel='stylesheet' href='https://radicaltherapy.ir/css/font-sobhan.css'>
<div style='width: 100%;'>
        <div style='width:100%;max-width:400px;;height: 600px;margin: auto;'>
            <div style='width: 100%;background-color: rgb(189, 151, 197);padding: 1rem;font-family: Shabnam;'>
                <h4 style='float: right;font-size: 1.5rem;margin-right: 1rem; '>مجموعه رادیکال تراپی</h4>
                <img style='width:100px' src='https://radicaltherapy.ir/img/alizare.png' alt=''>
                <p dir='rtl' style='text-align: right;width: 100%;font-size: 1.2rem;font-weight: bold;'>فیش بانکی شما به دلیل زیر مردود شد :</p>
                <p style='text-align: right;'>
                    <div dir='rtl' style='background-color: white;padding: 10px 8px 8px 20px;font-size: 1.2rem;border-radius: 4px;display: block;'>
                        {reason}</div>
                </p>
            </div>
        </div>
    </div> ";
                Email.SendEmailWithTemplate(body, username);
            }
        }
        public static void RadicalTherapyTime(string username, string name, DateTime dateTime, bool method)
        {
         
            string dateime = Utility.ConvertDatetimeToString(dateTime);

            if (method)
            {
                var client = new RestClient("http://188.0.240.110/api/select");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\"op\" : \"patternV2\"" +
                    ",\"user\" : \"09171898681\"" +
                    ",\"pass\":  \"@13931393Pa\"" +
                    ",\"fromNum\" : \"+983000505\"" +
                    $",\"toNum\": \"{username}\"" +
                    ",\"patternCode\": \"7szhe09tlx\"" +
                    ",\"inputData\" : {\"name\": \"" + name + "\",\"datetime\": \"" + dateime + "\"}}"
                    , ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            else
            {
                string body = $@"   <link rel='stylesheet' href='https://radicaltherapy.ir/css/font-sobhan.css'>
<div style='width: 100%;'>
        <div style='width:100%;max-width:400px;;height: 600px;margin: auto;'>
            <div style='width: 100%;background-color: rgb(189, 151, 197);padding: 1rem;font-family: Shabnam;'>
                <h4 style='float: right;font-size: 1.5rem;margin-right: 1rem; '>مجموعه رادیکال تراپی</h4>
                <img style='width:100px' src='https://radicaltherapy.ir/img/alizare.png' alt=''>
                <p dir='rtl' style='text-align: right;width: 100%;font-size: 1.2rem;font-weight: bold;'>کاربر گرامی : {name}</p>
                <p style='text-align: right;'>
                    <div dir='rtl' style='background-color: white;padding: 10px 8px 8px 20px;font-size: 1.2rem;border-radius: 4px;display: block;text-align: justify;'>
                      شما یک تایم رادیکال تراپی به تاریخ و ساعت<br> {dateime} رزرو کرده اید لطفا قوانین جلسه رادیکال تراپی را به دقت مطالعه و از یک روز قبل آنها را رعایت کنید<br> با تشکر</div>
                </p>
            </div>
        </div>
    </div> ";
                Email.SendEmailWithTemplate(body, username);
            }
        }
        public static void CustomMassage(string username, string name, string text, bool method)
        {
            if (method)
            {
                var client = new RestClient("http://188.0.240.110/api/select");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\"op\" : \"patternV2\"" +
                    ",\"user\" : \"09171898681\"" +
                    ",\"pass\":  \"@13931393Pa\"" +
                    ",\"fromNum\" : \"+983000505\"" +
                    $",\"toNum\": \"{username}\"" +
                    ",\"patternCode\": \"cu7estci26\"" +
                    ",\"inputData\" : {\"name\": \"" + name + "\",\"massage\": \"" + text + "\"}}"
                    , ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            else
            {
                string body = $@"   <link rel='stylesheet' href='https://radicaltherapy.ir/css/font-sobhan.css'>
<div style='width: 100%;'>
        <div style='width:100%;max-width:400px;;height: 600px;margin: auto;'>
            <div style='width: 100%;background-color: rgb(189, 151, 197);padding: 1rem;font-family: Shabnam;'>
                <h4 style='float: right;font-size: 1.5rem;margin-right: 1rem; '>مجموعه رادیکال تراپی</h4>
                <img style='width:100px' src='https://radicaltherapy.ir/img/alizare.png' alt=''>
                <p dir='rtl' style='text-align: right;width: 100%;font-size: 1.2rem;font-weight: bold;'>کاربر گرامی : {name} <br>شما یک پیام جدید از طرف ادمین سایت دارید :</p>
                <p style='text-align: right;'>
                    <div dir='rtl' style='background-color: white;padding: 10px 8px 8px 20px;font-size: 1.2rem;border-radius: 4px;display: block;text-align: justify;'>
                        {text}</div>
                </p>
            </div>
        </div>
    </div>";
                Email.SendEmailWithTemplate(body, username);
            }
        }
    }
}
