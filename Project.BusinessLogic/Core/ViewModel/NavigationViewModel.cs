using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Project.BusinessLogic.Contract.Interface.View;
using Project.BusinessLogic.Contract.Interface.ViewModel;
using Project.BusinessLogic.Framework;
using Project.BusinessLogic.Framework.Base;

namespace Project.BusinessLogic.Core.ViewModel
{
	public class NavigationViewModel: BaseViewModel, INavigationViewModel
	{
		private readonly ICardSection _cardSection;
		private readonly IIndicatorSection _indicatorSection;

		public NavigationViewModel(ICardSection cardSection, IIndicatorSection indicatorSection) {
			_cardSection = cardSection ?? throw new ArgumentNullException(nameof(cardSection));
			_indicatorSection = indicatorSection ?? throw new ArgumentNullException(nameof(indicatorSection));
			InitCommands();
		}

		public ICommand CardSectionOpenCommand { get; private set; }
		public ICommand IndicatorSectionOpenCommand { get; private set; }
		public ICommand CloseCommand { get; private set; }

		private UserControl _sectionView;
		public UserControl SectionView {
			get => _sectionView;
			set {
				_sectionView = value; 
				OnPropertyChanged();
			}
		}

		private void InitCommands() {
			CardSectionOpenCommand = new DelegateCommand(OpenCards);
			IndicatorSectionOpenCommand = new DelegateCommand(OpenIndicators);
			CloseCommand = new DelegateCommand(Close);
		}

		private void OpenCards(object obj) {
			SectionView = (UserControl) _cardSection;
		}

		private void OpenIndicators(object obj) {
			SectionView = (UserControl)_indicatorSection;
		}

		private void Close(object obj) {
			Application.Current?.Shutdown();
		}
	}
}