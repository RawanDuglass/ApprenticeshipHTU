using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace ProjectHTU.Controllers
{
    public class EmailController : Controller
    {
        
        public async Task<IActionResult> SendEmail(int Id)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com", 587);
            mail.From = new MailAddress("Apprenticeship@gmail.com");
            smtp.Credentials = new NetworkCredential("Apprenticeship@gmail.com", "xxzk ikqv xrhe boic");

            if (User.IsInRole("TEAMLEADER"))
            {
                mail.To.Add("studentemail@gmail.com");
                mail.Subject = "Assignment";
                mail.Body = $"Dear Student \n \nYou have New Assignment \nCheck on it \n\n{DateTime.Now} ";
            }
            else if (User.IsInRole("STUDENT"))
            {
                mail.To.Add("teamleaderemail@gmail.com");
                mail.Subject = " Report ";
                mail.Body = $"Dear TeamLeader \n \nYou Recived a New Report \nCheck on it \n\n{DateTime.Now} ";
            }
            else
            {
                mail.To.Add("viitoremail@gmail.com");
                mail.Subject = " Visitor ";
                mail.Body = $"Dear Visitor \n \nWe will answer your question as soon as possible \n\n{DateTime.Now} ";
            }
            
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            try
            {
                await smtp.SendMailAsync(mail);
                if (User.IsInRole("TEAMLEADER"))
                {
                    return RedirectToAction("TeamleaderIndex", "Assignment", new { Id = Id });
                }
                else if (User.IsInRole("STUDENT"))
                {
                    return RedirectToAction("Report", "Student", new { Id = Id });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { Id = Id });

                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to send email: {ex.Message}");

            }
        }
    }
}
