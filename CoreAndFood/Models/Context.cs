using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Models
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=LAPTOP-BBE25C4L\\SQLEXPRESS; database=DbCoreFood; integrated security=true; Encrypt=False; TrustServerCertificate=True;");
		}
		public DbSet<Food> Foods { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Admin> Admins { get; set; }
	}
}
