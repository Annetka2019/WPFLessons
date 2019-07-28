using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPF_EF_Rebbit_MSTest_Moq.Database;
using WPF_EF_Rebbit_MSTest_Moq.Framework;
using WPF_EF_Rebbit_MSTest_Moq.Framework.Base;
using WPF_EF_Rebbit_MSTest_Moq.Project.Core;
using WPF_EF_Rebbit_MSTest_Moq.Project.Events;
using WPF_EF_Rebbit_MSTest_Moq.Project.Model;
using WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel.Interfaces;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel
{
	public class IndicatorSectionViewModel: BaseViewModel, IIndicatorSectionViewModel
	{
		private readonly IIndicatorPageFactory _indiactorPageFactory;

		public IndicatorSectionViewModel(IIndicatorPageFactory indiactorPageFactory) {
			_indiactorPageFactory = indiactorPageFactory ?? throw new ArgumentNullException(nameof(indiactorPageFactory));
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
			ShowIndicatorPage(PageOperation.Add);
		}

		private void EditIndicator(object obj) {
			ShowIndicatorPage(PageOperation.Edit);
		}

		private void ShowIndicatorPage(PageOperation operation) {
			var indicatorPage = (Window)_indiactorPageFactory.GetPage();
			indicatorPage.ShowInTaskbar = false;
			var indicatorPageViewModel = (IndicatorPageViewModel)indicatorPage.DataContext;
			indicatorPageViewModel.IndicatorSaved += OnIndicatorSaved;
			if (operation == PageOperation.Edit) {
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