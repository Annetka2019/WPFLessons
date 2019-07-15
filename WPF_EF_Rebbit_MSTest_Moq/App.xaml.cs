using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using EF = System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_EF_Rebbit_MSTest_Moq.Database;
using WPF_EF_Rebbit_MSTest_Moq.Migrations;

namespace WPF_EF_Rebbit_MSTest_Moq
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App() {
			EF.Database.SetInitializer(new EF.MigrateDatabaseToLatestVersion<ProjectDbContext, Configuration>());
		}
	}
}
