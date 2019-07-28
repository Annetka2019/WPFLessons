using EF = System.Data.Entity;
using System.Windows;
using Ninject;
using WPF_EF_Rebbit_MSTest_Moq.Database;
using WPF_EF_Rebbit_MSTest_Moq.Framework;
using WPF_EF_Rebbit_MSTest_Moq.Migrations;
using WPF_EF_Rebbit_MSTest_Moq.Project.View;

namespace WPF_EF_Rebbit_MSTest_Moq
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static StandardKernel Kernel { get; }

		static App() {
			Kernel = new StandardKernel(new ProjectModule());
		}

		public App() {
			EF.Database.SetInitializer(new EF.MigrateDatabaseToLatestVersion<ProjectDbContext, Configuration>());
		}

		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);
			ShowMainWindow();
		}

		private void ShowMainWindow() {
			Current.MainWindow = Kernel.Get<NavigationView>();
			Current.MainWindow.Show();
		}
	}
}