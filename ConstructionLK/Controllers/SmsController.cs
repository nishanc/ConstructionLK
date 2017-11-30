using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net;

namespace ConstructionLK.Controllers
{
    [AllowAnonymous]
    public class SmsController : Controller
    {
        public ActionResult SendSms()
        {
            String message = HttpUtility.UrlEncode("This is your message");
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                {
                    {"apikey" , "EXfapgBZ+4M-qSpQCEdOLhG6ZEc0y7esVVeTi6rL41"},
                    {"numbers" , "+94713871805"},
                    {"message" , message},
                    {"sender" , "CLK Alert"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return Content(result);
            }
            //var accountSid = "ACefbe50b7c60bf5a43f137fe14a2525d8";
            //var authToken = "b3f76688c8db3787be9bc03eec73a29d";
            //TwilioClient.Init(accountSid, authToken);

            //var from = new PhoneNumber("+14252151385");
            //var to = new PhoneNumber("+94713871805");

            //var message = MessageResource.Create(
            //    to: to,
            //    from: from,
            //    body: "This is the ship that made the Kessel Run in fourteen parsecs?");

            //return Content(message.Sid);
            //var mediaUrl = new List<Uri>() {
            //    new Uri( "https://c1.staticflickr.com/3/2899/14341091933_1e92e62d12_b.jpg" )
            //};
            //var to = new PhoneNumber("+15017250604");
            //var message = MessageResource.Create(
            //    to,
            //    from: new PhoneNumber("+15558675309"),
            //    body: "This is the ship that made the Kessel Run in fourteen parsecs?",
            //    mediaUrl: mediaUrl);
            //Console.WriteLine(message.Sid);
        }

    }
}