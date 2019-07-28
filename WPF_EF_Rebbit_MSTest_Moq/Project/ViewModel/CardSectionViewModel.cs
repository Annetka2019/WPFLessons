using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPF_EF_Rebbit_MSTest_Moq.Database;
using WPF_EF_Rebbit_MSTest_Moq.Framework;
using WPF_EF_Rebbit_MSTest_Moq.Framework.Base;
using WPF_EF_Rebbit_MSTest_Moq.Project.Model;
using WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel.Interfaces;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel
{
	public class CardSectionViewModel: BaseViewModel, ICardSectionViewModel
	{
		private readonly Window _cardPage;

		public CardSectionViewModel(Window cardPage) {
			_cardPage = cardPage ?? throw new ArgumentNullException(nameof(cardPage));
			InitCardsCollection();
			InitCommands();
		}

		public ObservableCollection<Card> Cards { get; private set; }

		public Card SelectedCard { get; set; }

		public ICommand ShowCardCommand { get; private set; }

		private void InitCommands() {
			ShowCardCommand = new DelegateCommand(ShowCard, CanShowCard);
		}
		
		private void ShowCard(object obj) {
			var cardPageViewModel = (CardPageViewModel)_cardPage.DataContext;
			cardPageViewModel.Card = SelectedCard;
			_cardPage.Show();
		}

		private bool CanShowCard(object obj) {
			return SelectedCard != null;
		}

		private void InitCardsCollection() {
			using (var db = new ProjectDbContext()) {
				Cards = new ObservableCollection<Card>(db.Cards);
			}
		}
	}
}