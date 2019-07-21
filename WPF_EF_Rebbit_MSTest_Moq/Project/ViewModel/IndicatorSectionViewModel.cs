using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WPF_EF_Rebbit_MSTest_Moq.Database;
using WPF_EF_Rebbit_MSTest_Moq.Framework;
using WPF_EF_Rebbit_MSTest_Moq.Framework.Base;
using WPF_EF_Rebbit_MSTest_Moq.Project.Events;
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
		public Indicator SelectedIndicator { get; set; }
		public ICommand AddCommand { get; private set; }
		public ICommand EditCommand { get; private set; }
		public ICommand RemoveCommand { get; private set; }

		private void InitIndicatorsCollection() {
			using (var ctx = new ProjectDbContext()) {
				Indicators = new ObservableCollection<Indicator>(ctx.Indicators);
			}
		}

		private void InitCommands() {
			AddCommand = new DelegateCommand(AddIndicator);
			EditCommand = new DelegateCommand(EditIndicator, CanEditIndicator);
			RemoveCommand = new DelegateCommand(RemoveIndicator, CanRemoveIndicator);
		}

		private void AddIndicator(object obj) {
			ShowIndicatorPage("Add");
		}

		private void EditIndicator(object obj) {
			ShowIndicatorPage("Edit");
		}

		private void ShowIndicatorPage(string mode) {
			var indicatorPage = new IndicatorPage {
				ShowInTaskbar = false
			};
			if (!(indicatorPage.DataContext is IndicatorPageViewModel indicatorPageViewModel)) return;
			indicatorPageViewModel.IndicatorSaved += OnIndicatorSaved;
			if (mode == "Edit") {
				indicatorPageViewModel.Indicator = SelectedIndicator;
			} 
			indicatorPage.ShowDialog();
		}

		private void OnIndicatorSaved(object sender, IndicatorSavedEventArgs e) {
			Indicators.Add(e.Indicator);
		}

		private bool CanEditIndicator(object obj) {
			return SelectedIndicator != null;
		}

		private void RemoveIndicator(object obj) {
			using (var ctx = new ProjectDbContext()) {
				Indicator removedIndicator = ctx.Indicators.Find(SelectedIndicator.Id);
				if (removedIndicator == null) return;
				ctx.Indicators.Remove(removedIndicator);
				ctx.SaveChanges();
				Indicators.Remove(SelectedIndicator);
				SelectedIndicator = null;
			}
		}

		private bool CanRemoveIndicator(object obj) {
			return SelectedIndicator != null;
		}
	}
}