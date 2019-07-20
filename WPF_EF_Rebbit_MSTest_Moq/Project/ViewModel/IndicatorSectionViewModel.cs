using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_EF_Rebbit_MSTest_Moq.Database;
using WPF_EF_Rebbit_MSTest_Moq.Framework;
using WPF_EF_Rebbit_MSTest_Moq.Framework.Base;
using WPF_EF_Rebbit_MSTest_Moq.Project.Model;
using WPF_EF_Rebbit_MSTest_Moq.Project.View;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel
{
	public class IndicatorSectionViewModel: BaseViewModel
	{
		public IndicatorSectionViewModel() {
			InitIndicatorsCollection();
			InitCommands();
		}

		public ObservableCollection<Indicator> Indicators { get; private set; }
		public Indicator  SelectedIndicator { get; set; }
		public ICommand AddCommand { get; private set; }
		public ICommand EditCommand { get; private set; }

		private void InitIndicatorsCollection() {
			using (var ctx = new ProjectDbContext()) {
				Indicators = new ObservableCollection<Indicator>(ctx.Indicators);
			}
		}

		private void InitCommands() {
			AddCommand = new DelegateCommand(AddIndicator, CanAddIndicator);
			EditCommand = new DelegateCommand(EditIndicator, CanEditIndicator);
		}

		private void AddIndicator(object obj) {
			var indicatorPage = new IndicatorPage();
			var indicatorPageViewModel = new IndicatorPageViewModel();
			indicatorPage.DataContext = indicatorPageViewModel;
			indicatorPage.ShowDialog();
		}

		private bool CanAddIndicator(object obj) {
			return true;
		}

		private void EditIndicator(object obj) {
			var indicatorPage = new IndicatorPage();
			var indicatorPageViewModel = new IndicatorPageViewModel { Indicator = SelectedIndicator};
			indicatorPage.DataContext = indicatorPageViewModel;
			indicatorPage.ShowDialog();
		}

		private bool CanEditIndicator(object obj) {
			return SelectedIndicator != null;
		}

	}
}