using Microsoft.EntityFrameworkCore;
using Mvccrudopration.Models;

namespace Mvccrudopration.ApplicationDbContaxt
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<Emp>emps { get; set; }

        public DbSet<Product> Product {  get; set; }
    }
}
