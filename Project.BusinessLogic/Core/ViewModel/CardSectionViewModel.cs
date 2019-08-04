using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Project.BusinessLogic.Contract.Interface.Database;
using Project.BusinessLogic.Contract.Interface.Model;
using Project.BusinessLogic.Contract.Interface.ViewModel;
using Project.BusinessLogic.Framework;
using Project.BusinessLogic.Framework.Base;

namespace Project.BusinessLogic.Core.ViewModel
{
	public class CardSectionViewModel: BaseViewModel, ICardSectionViewModel
	{
		private readonly Window _cardPage;
		private readonly IRepository<ICard> _cardRepository;

		public CardSectionViewModel(Window cardPage, IRepository<ICard> cardRepository) {
			_cardPage = cardPage ?? throw new ArgumentNullException(nameof(cardPage));
			_cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
			InitCardsCollection();
			InitCommands();
		}

		public ObservableCollection<ICard> Cards { get; private set; }

		public ICard SelectedCard { get; set; }

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
			Cards = new ObservableCollection<ICard>(_cardRepository.GetCollection());
		}
	}
}