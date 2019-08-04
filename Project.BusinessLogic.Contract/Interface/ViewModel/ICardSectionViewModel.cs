using System.Collections.ObjectModel;
using System.Windows.Input;
using Project.BusinessLogic.Contract.Interface.Model;

namespace Project.BusinessLogic.Contract.Interface.ViewModel
{
	public interface ICardSectionViewModel
	{
		ObservableCollection<ICard> Cards { get; }
		ICard SelectedCard { get; set; }
		ICommand ShowCardCommand { get; }
	}
}