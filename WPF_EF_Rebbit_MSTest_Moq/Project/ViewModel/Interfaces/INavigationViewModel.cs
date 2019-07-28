using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel.Interfaces
{
	public interface INavigationViewModel
	{
		ICommand CardSectionOpenCommand { get; }
		ICommand IndicatorSectionOpenCommand { get; }
		ICommand CloseCommand { get; }
		UserControl SectionView { get; set; }
	}
}