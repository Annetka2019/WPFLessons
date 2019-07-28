using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_EF_Rebbit_MSTest_Moq.Project.View.Interfaces;
using WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel.Interfaces;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.View
{
	/// <summary>
	/// Interaction logic for IndicatorPage.xaml
	/// </summary>
	public partial class IndicatorPage : Window, IIndicatorPage
	{
		public IndicatorPage(IIndicatorPageViewModel indicatorPageViewModel) {
			InitializeComponent();
			DataContext = indicatorPageViewModel;
		}
	}
}
