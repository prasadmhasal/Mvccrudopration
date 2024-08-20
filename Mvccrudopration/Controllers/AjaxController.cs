using Microsoft.AspNetCore.Mvc;
using Mvccrudopration.ApplicationDbContaxt;
using Mvccrudopration.Models;


namespace Mvccrudopration.Controllers
{
    public class AjaxController : Controller
    {

        private readonly ApplicationDbContext db;
        public AjaxController(ApplicationDbContext db) 
        { 
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(Emp p) 
        {
            db.emps.Add(p);
            db.SaveChanges();
            return Json("");
        
        }

        public IActionResult GetEmp(Emp e)
        {
            var data = db.emps.ToList();
            return Json(data);
        }



    }
}
