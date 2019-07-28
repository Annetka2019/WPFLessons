using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_EF_Rebbit_MSTest_Moq.Database;
using WPF_EF_Rebbit_MSTest_Moq.Project.View.Interfaces;
using WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel.Interfaces;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class CardSection : UserControl, ICardSection
	{
		public CardSection(ICardSectionViewModel cardSectionViewModel) {
			InitializeComponent();
			DataContext = cardSectionViewModel;
		}
	}
}