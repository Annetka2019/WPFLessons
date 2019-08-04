using System.Data.Entity;
using Project.Database.Database;

namespace Project.Startup.Configuration
{
	internal sealed class EntityFrameworkSetup
	{
		public static void ConfigurateMigration() {
			System.Data.Entity.Database.SetInitializer(
				new MigrateDatabaseToLatestVersion<EntityDbContext, Database.Migrations.Configuration>());
		}
	}
}