using Microsoft.AspNetCore.Mvc;
using Mvccrudopration.ApplicationDbContaxt;
using Mvccrudopration.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.IdentityModel.Tokens;

namespace Mvccrudopration.Controllers
{
    public class EmpController1 : Controller
    {
        private ApplicationDbContext db;

        

        public EmpController1(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public IActionResult Index(Emp e)
        {
            var empview = db.emps.ToList();

            return View(empview);
        }

        [HttpPost]
        public IActionResult Index(string Name)
        {
            if(Name.IsNullOrEmpty())
            {
                var empview = db.emps.ToList();

                return View(empview);
            }
            else
            {

              var search =  db.emps.Where(se => se.Name.Contains(Name)|| se.Email.Contains(Name) || se.salary.ToString().Contains(Name)).ToList();
               return View(search);
            }
        }
        public IActionResult AddEmp()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            db.emps.Add(e);
            db.SaveChanges();
            TempData["msg"] = "Emp Add successfully";
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult SendEmail(Emp e)
        //{

        //    var Email = e.Email;
        //    //Mail notification
        //    MailMessage message = new MailMessage();
        //    message.To.Add(new MailAddress(Email));
        //    message.Subject = "Email Subject ";
        //    message.Body = "Email Message";
        //    message.From = new MailAddress("prasadmhasal@gmail.com");

        //    // Email Address from where you send the mail
        //    var fromAddress = "prasadmhasal@gmail.com";

        //    //Password of your mail address
        //    const string fromPassword = "fxjuqdrhzmmeksyq";

        //    // smtp settings
        //    var smtp = new System.Net.Mail.SmtpClient();
        //    {
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.EnableSsl = true;
        //        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //        smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
        //        smtp.Timeout = 20000;
        //    }
        //    // Passing values to smtp object        
        //    smtp.Send(message);
        //    return View();

        //}

        public IActionResult DeleteEmp( int id )
        {
            var delete =  db.emps.Find(id);
            db.emps.Remove(delete);
            db.SaveChanges();
            TempData["deletemsg"] = "Delete successfully !!!";
            return RedirectToAction("Index");
                    
        }
        [HttpPost]
        public IActionResult DelecteEmp(int[] mulid)
        {
            if(mulid != null && mulid.Length > 0)
            {
                foreach(var a in  mulid)
                {
                    var data = db.emps.Find(a);
                    db.emps.RemoveRange(data);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }

        
        public IActionResult email(int id)
        {

            var data = db.emps.Find(id);
            var Email = data.Email;

            //Mail notification
            MailMessage message = new MailMessage();
            message.To.Add(new MailAddress(Email));
            message.Subject = "Email Subject ";
            message.Body = "Email Message";
            message.From = new MailAddress("prasadmhasal@gmail.com");

            // Email Address from where you send the mail
            var fromAddress = "prasadmhasal@gmail.com";

            //Password of your mail address
            const string fromPassword = "fxjuqdrhzmmeksyq";

            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object        
            smtp.Send(message);
            TempData["sendemail"] = "Email send successfully !!";
            return RedirectToAction("Index");
        }
        public IActionResult UpdateEmp(int id )
        {
            var data = db.emps.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateEmp(Emp e)
        {
            db.emps.Update(e);
            db.SaveChanges();
            TempData["update"] = "update successfully !!";
            return RedirectToAction("Index");
        }



        

    }
}
