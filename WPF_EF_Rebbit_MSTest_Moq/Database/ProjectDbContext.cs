using System.Data.Entity;
using WPF_EF_Rebbit_MSTest_Moq.Project.Model;

namespace WPF_EF_Rebbit_MSTest_Moq.Database
{
	public class ProjectDbContext: DbContext
    {
	    public ProjectDbContext(string connectionString = "db"): base(connectionString) {}

	    public DbSet<Card> Cards { get; set; }

		public DbSet<Indicator> Indicators { get; set; }
    }
}