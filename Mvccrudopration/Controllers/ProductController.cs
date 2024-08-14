using Microsoft.AspNetCore.Mvc;
using Mvccrudopration.ApplicationDbContaxt;
using Mvccrudopration.Models;
using System.Net;
namespace Mvccrudopration.Controllers
{
	public class ProductController : Controller
	{
		private readonly IWebHostEnvironment env;
		private readonly ApplicationDbContext db;
		

		public ProductController(ApplicationDbContext db , IWebHostEnvironment env) 
		{  
			this.db = db;
			this.env = env;
		}
		public IActionResult Index(Product p)
		{
		    var data = db.Product.ToList();
			return View(data);
		}

		public IActionResult AddProduct()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddProduct( ProductViewModel pm) 
		{

			var path = env.WebRootPath;
			var filepath = "/Content/Images/" + pm.Picture.FileName;
			var fullPath = Path.Combine(path + filepath);
			UploadFile(pm.Picture, fullPath);
			var obj = new Product()
			{
				Pname = pm.PName,
				Pcat = pm.Pcat,
				Price = pm.Price,
				Picture = filepath
			};
			db.Add(obj);
			db.SaveChanges();
			TempData["msg"] = "Product Added SucessFully !!";
			return RedirectToAction("Index");
		}

		private void UploadFile(IFormFile file, string fullPath)
		{
			FileStream stream = new FileStream(fullPath, FileMode.Create);
			file.CopyTo(stream);
		}
	}
}
