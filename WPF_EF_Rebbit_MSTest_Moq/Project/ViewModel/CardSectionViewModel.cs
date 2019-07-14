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
	public class CardSectionViewModel: BaseViewModel
	{
		public CardSectionViewModel() {
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
			var cardPage = new CardPage();
			var cardPageViewModel = new CardPageViewModel();
			cardPage.DataContext = cardPageViewModel;
			cardPage.Show();
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