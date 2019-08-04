using System.Windows.Controls;
using System.Windows.Input;

namespace Project.BusinessLogic.Contract.Interface.ViewModel
{
	public interface INavigationViewModel
	{
		ICommand CardSectionOpenCommand { get; }
		ICommand IndicatorSectionOpenCommand { get; }
		ICommand CloseCommand { get; }
		UserControl SectionView { get; set; }
	}
}