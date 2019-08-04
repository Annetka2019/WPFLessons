using System;
using System.Collections.ObjectModel;
using Project.BusinessLogic.Contract.Interface.Database;
using Project.BusinessLogic.Contract.Interface.Model;
using Project.BusinessLogic.Contract.Interface.ViewModel;
using Project.BusinessLogic.Framework.Base;

namespace Project.BusinessLogic.Core.ViewModel
{
	public class CardPageViewModel: BaseViewModel, ICardPageViewModel
	{
		private readonly IRepository<ICard> _cardRepository;

		public CardPageViewModel(IRepository<ICard> cardRepository) {
			_cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
			InitCommands();
			InitDetails();
		}

		public ObservableCollection<IIndicator> IndicatorsInCard { get; set; }

		public ICard Card { get; set; }

		private void InitDetails() {
			
		}

		private void InitCommands() {
		}
	}
}