using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadicalTherapy.Data.model;
using RadicalTherapy.Data.Repository;
using RadicalTherapy.Utility;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RadicalTherapy.Controllers
{
    [Authorize]
    public class RadicalTherapyTimeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ConfirmRules(DateTime datetime)
        {
            string username = User.FindFirstValue(ClaimTypes.NameIdentifier);

            string datetimeString = Utility.Utility.ConvertDatetimeToString(datetime);
            string morning = "";
            if (datetime.Hour<12)
            {
                morning = "صبح";
            }
            ViewBag.datetimeString = datetimeString ;
            ViewBag.morning = morning;
            using (UnitOfWork db = new UnitOfWork())
            {
                int Price = Int32.Parse(db.DataRepository.Get(c => c.Key == "radicalReservePrice").FirstOrDefault().Value);
                User user = db.UserRepository.Get(c => c.UserName == username).FirstOrDefault();
                RadicalReserve reserve = db.RadicalReserveRepository.Get(c => c.UserId == user.ID && c.PayStatus == 2).FirstOrDefault();
                if (reserve == null)
                {
                    reserve = new RadicalReserve() { DateTime = datetime, Price = Price, PayStatus = 2, UserId = user.ID };
                    db.RadicalReserveRepository.Insert(reserve);

                }
                else
                {
                    reserve.DateTime = datetime;
                    db.RadicalReserveRepository.Update(reserve);
                }
                db.Save();
                ViewBag.price = (Convert.ToInt32(db.DataRepository.Get(c => c.Key == "radicalReservePrice").FirstOrDefault().Value))/10000;
                ViewBag.duration=db.DataRepository.Get(c => c.Key == "radicalReserveDuration").FirstOrDefault().Value;
            }
            return View();
        }
        public async Task<IActionResult> Payment()
        {
            string authority;
            try
            {
                using (var client = new HttpClient())
                {
                    string UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    string requesturl = "https://api.zarinpal.com/pg/v4/payment/request.json?";
                    User user;
                    string id ;
                    string amount;
                    string description;
                    using (UnitOfWork db = new UnitOfWork())
                    {
                        user = db.UserRepository.Get(c => c.UserName == UserName).FirstOrDefault();
                        amount = db.DataRepository.Get(c => c.Key == "radicalReservePrice").FirstOrDefault().Value.ToString();
                        string name = db.UserRepository.Get(c => c.UserName == UserName).FirstOrDefault().Name;
                        description = name + " " + UserName;
                        RadicalReserve UserReserve = db.RadicalReserveRepository.Get(c => c.UserId == user.ID && c.PayStatus == 2).FirstOrDefault();
                     
                        if (UserReserve == null)
                        {
                            return RedirectToAction("Index", "User");
                        }
                        else if (db.RadicalReserveRepository.Get(c=>c.DateTime==UserReserve.DateTime && c.PayStatus==3).Any())
                        {
                            return RedirectToAction("Index", "User");
                        }
                        else
                        {
                            id = UserReserve.ID.ToString();
                        }
                    }
                        

                  //  string callbackUrl = "https://localhost:44352/home/VerifyByHttpClient/"+id;
                    // string callbackUrl = "https://test.radicaltherapy.ir/home/VerifyByHttpClient/" + id;
                     string callbackUrl = "https://radicaltherapy.ir/home/VerifyByHttpClient/" + id;
                     string merchant = "63e6380b-a97a-495f-8cc6-e13c65247545";
                    string Reqparameters = $"merchant_id={merchant}&amount={amount}&callback_url={callbackUrl}&description={description}";

                    HttpContent content = new StringContent(Reqparameters, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(requesturl + Reqparameters, content);

                    string responseBody = await response.Content.ReadAsStringAsync();
                    Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(responseBody);
                    string errorscode = jo["errors"].ToString();

                    Newtonsoft.Json.Linq.JObject jodata = Newtonsoft.Json.Linq.JObject.Parse(responseBody);
                    string dataauth = jodata["data"].ToString();

                    if (dataauth != "[]")
                    {
                        authority = jodata["data"]["authority"].ToString();
                        string gatewayUrl = "https://www.zarinpal.com/pg/StartPay/" + authority;
                        return Redirect(gatewayUrl);
                    }
                    else
                    {
                        return View("ZarinPalNotAccessible");
                       // return BadRequest("error " + errorscode);
                    }

                }
            }
            catch (Exception ex)
            {
                Email.Send("zarinpal", ex.Message);
                return View("ZarinPalNotAccessible");
            }
        }
       

    }

}
