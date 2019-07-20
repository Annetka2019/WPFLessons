using System.Linq;
using System.Windows.Input;
using WPF_EF_Rebbit_MSTest_Moq.Database;
using WPF_EF_Rebbit_MSTest_Moq.Framework;
using WPF_EF_Rebbit_MSTest_Moq.Framework.Base;
using WPF_EF_Rebbit_MSTest_Moq.Project.Model;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel
{
	public class IndicatorPageViewModel: BaseViewModel
	{
		public IndicatorPageViewModel() {
			InitCommands();
		}

		public Indicator Indicator { get; set; }

		public ICommand SaveCommand { get; private set; }

		private void InitCommands() {
			SaveCommand = new DelegateCommand(SaveIndicator, CanSaveIndicator);
		}

		private void SaveIndicator(object obj) {
			using (var ctx = new ProjectDbContext()) {
				var indicatorDb = ctx.Indicators.FirstOrDefault(i => i.Id == Indicator.Id);
				if (indicatorDb != null) {
					indicatorDb.Name = Indicator.Name;
					indicatorDb.Type = Indicator.Type;
				}
				else {
					ctx.Indicators.Add(Indicator);
				}
				ctx.SaveChanges();
			}
		}

		private bool CanSaveIndicator(object obj) {
			return Indicator.Name != string.Empty && Indicator.Type != string.Empty;
		}
	}
}