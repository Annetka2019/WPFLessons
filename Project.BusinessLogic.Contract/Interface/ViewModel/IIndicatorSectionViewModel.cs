using System.Collections.ObjectModel;
using System.Windows.Input;
using Project.BusinessLogic.Contract.Interface.Model;

namespace Project.BusinessLogic.Contract.Interface.ViewModel
{
	public interface IIndicatorSectionViewModel
	{
		ObservableCollection<IIndicator> Indicators { get; }
		IIndicator SelectedIndicator { get; set; }
		ICommand AddCommand { get; }
		ICommand EditCommand { get; }
		ICommand RemoveCommand { get; }
	}
}