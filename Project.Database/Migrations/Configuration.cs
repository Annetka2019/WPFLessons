using Project.Database.Database;

namespace Project.Database.Migrations
{
	using System.Data.Entity.Migrations;

	public sealed class Configuration : DbMigrationsConfiguration<EntityDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			AutomaticMigrationDataLossAllowed = false;
		}

		protected override void Seed(EntityDbContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.
		}
	}
}