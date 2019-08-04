using System.Data.Entity;
using Project.Database.Model;

namespace Project.Database.Database
{
	public class EntityDbContext: DbContext
	{
		public EntityDbContext() : base("db") { }

		public DbSet<CardEntity> Cards { get; set; }

		public DbSet<IndicatorEntity> Indicators { get; set; }
	}
}