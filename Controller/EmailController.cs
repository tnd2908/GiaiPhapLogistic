using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using GiaiPhapLogistics.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GiaiPhapLogistics.Controller
{
    [Route("api/SendMail")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public object SendEmail([FromBody] ContactInfo contactInfo)
        {
            string fromMail = "giaiphaplogisticemailservice@gmail.com";
            string fromPassword = "dgbdrrqrftrrykut";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Khách hàng liên hệ";
            message.To.Add(new MailAddress("tnd.290800@gmail.com"));
            message.Body = "<html> " +
                "<body> " +
                    "<h3>Khách hàng liên hệ</h3>" +
                    "<p>Email: " + contactInfo.Email + "</p>" +
                    "<p>Tên KH: " + contactInfo.Name + "</p>" +
                    "<p>Số điện thoại: " + contactInfo.PhoneNumber + "</p>" +
                    "<p>Lời nhắn: " + contactInfo.Message + "</p>" +
                "<body> " +
            "</html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
            var result = new
            {
                message = "Send email successfully"
            };
            return result;
        }
    }
}

