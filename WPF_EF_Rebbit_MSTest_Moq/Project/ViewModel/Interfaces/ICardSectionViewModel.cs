using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_EF_Rebbit_MSTest_Moq.Project.Model;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel.Interfaces
{
	public interface ICardSectionViewModel
	{
		ObservableCollection<Card> Cards { get; }
		Card SelectedCard { get; set; }
		ICommand ShowCardCommand { get; }
	}
}