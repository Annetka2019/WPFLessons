using System.Windows;
using Ninject;
using Project.Presentation.View;
using Project.Startup.Configuration;

namespace Project.Startup
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static StandardKernel Kernel { get; }

		static App() {
			Kernel = new StandardKernel(new DiModule());
		}

		public App() {
			EntityFrameworkSetup.ConfigurateMigration();
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
