using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_EF_Rebbit_MSTest_Moq.Database;
using WPF_EF_Rebbit_MSTest_Moq.Framework.Base;
using WPF_EF_Rebbit_MSTest_Moq.Project.Model;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel
{
	public class CardPageViewModel: BaseViewModel
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
			throw new NotImplementedException();
		}
	}
}