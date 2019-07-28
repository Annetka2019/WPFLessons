using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_EF_Rebbit_MSTest_Moq.Project.Model;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel.Interfaces
{
	public interface IIndicatorSectionViewModel
	{
		ObservableCollection<Indicator> Indicators { get; }
		Indicator SelectedIndicator { get; set; }
		ICommand AddCommand { get; }
		ICommand EditCommand { get; }
		ICommand RemoveCommand { get; }
	}
}