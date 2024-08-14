using System.ComponentModel.DataAnnotations;

namespace Mvccrudopration.Models
{
	public class ProductViewModel
	{
		[Key]
		public int Pid { get; set; }

		public string? PName { get; set; }

		public string? Pcat { get; set; }

		public IFormFile Picture { get; set; }

		public double Price { get; set; }
	}
}
