using System.Collections.ObjectModel;
using WPF_EF_Rebbit_MSTest_Moq.Database;
using WPF_EF_Rebbit_MSTest_Moq.Framework.Base;
using WPF_EF_Rebbit_MSTest_Moq.Project.Model;
using WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel.Interfaces;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel
{
	public class CardPageViewModel: BaseViewModel, ICardPageViewModel
	{
		public CardPageViewModel() {
			InitCommands();
			InitDetails();
		}

		public ObservableCollection<Indicator> IndicatorsInCard { get; set; }

		public Card Card { get; set; }

		private void InitDetails() {
			using (var db = new ProjectDbContext()) {
				IndicatorsInCard = new ObservableCollection<Indicator>();
			}
		}

		private void InitCommands() {
		}
	}
}