using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Project.BusinessLogic.Contract.Interface.Database;
using Project.BusinessLogic.Contract.Interface.Event;
using Project.BusinessLogic.Contract.Interface.Model;
using Project.BusinessLogic.Contract.Interface.View;
using Project.BusinessLogic.Contract.Interface.ViewModel;
using Project.BusinessLogic.Enum;
using Project.BusinessLogic.Framework;
using Project.BusinessLogic.Framework.Base;

namespace Project.BusinessLogic.Core.ViewModel
{
	public class IndicatorSectionViewModel: BaseViewModel, IIndicatorSectionViewModel
	{
		private readonly IIndicatorPageFactory _indiactorPageFactory;
		private readonly IRepository<IIndicator> _indicatorRepository;

		public IndicatorSectionViewModel(
				IIndicatorPageFactory indiactorPageFactory, IRepository<IIndicator> indicatorRepository) {
			_indiactorPageFactory = indiactorPageFactory ?? 
				throw new ArgumentNullException(nameof(indiactorPageFactory));
			_indicatorRepository = indicatorRepository ?? 
				throw new ArgumentNullException(nameof(indicatorRepository));
			InitIndicatorsCollection();
			InitCommands();
		}

		public ObservableCollection<IIndicator> Indicators { get; private set; }
		public IIndicator SelectedIndicator { get; set; }
		public ICommand AddCommand { get; private set; }
		public ICommand EditCommand { get; private set; }
		public ICommand RemoveCommand { get; private set; }

		private void InitIndicatorsCollection() {
			Indicators = new ObservableCollection<IIndicator>(_indicatorRepository.GetCollection());
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
			var indicatorPageViewModel = (IIndicatorPageViewModel)indicatorPage.DataContext;
			indicatorPageViewModel.IndicatorSaved += OnIndicatorSaved;
			if (operation == PageOperation.Edit) {
				indicatorPageViewModel.Indicator = SelectedIndicator;
			}
			indicatorPage.ShowDialog();
		}

		private void OnIndicatorSaved(object sender, IIndicatorSavedEventArgs e) {
			Indicators.Add(e.Indicator);
		}

		private bool CanEditIndicator(object obj) {
			return SelectedIndicator != null;
		}

		private void RemoveIndicator(object obj) {
			_indicatorRepository.Remove(SelectedIndicator);
			Indicators.Remove(SelectedIndicator);
			SelectedIndicator = null;
		}

		private bool CanRemoveIndicator(object obj) {
			return SelectedIndicator != null;
		}
	}
}