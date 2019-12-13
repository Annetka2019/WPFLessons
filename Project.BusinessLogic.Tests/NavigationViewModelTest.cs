using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Project.BusinessLogic.Contract.Interface.View;
using Project.BusinessLogic.Core.ViewModel;
using Project.Startup;

namespace Project.BusinessLogic.Tests
{
	[TestClass]
	public class NavigationViewModelTest
	{
		[TestMethod]
		public void CardSectionOpenCommandIsNotNull() {
			NavigationViewModel navigationViewModel = TestKernel.Instance.Get<NavigationViewModel>();
			Assert.IsNotNull(navigationViewModel.CardSectionOpenCommand);
		}

		[TestMethod]
		public void CardSectionViewInitialized() {
			NavigationViewModel navigationViewModel = TestKernel.Instance.Get<NavigationViewModel>();
			object obj = new object();
			navigationViewModel.CardSectionOpenCommand.Execute(obj);
			var cardSection = navigationViewModel.SectionView as ICardSection;
			Assert.IsNotNull(cardSection);
		}

		[TestMethod]
		public void IndicatorSectionOpenCommandIsNotNull() {
			NavigationViewModel navigationViewModel = TestKernel.Instance.Get<NavigationViewModel>();
			Assert.IsNotNull(navigationViewModel.IndicatorSectionOpenCommand);
		}

		[TestMethod]
		public void IndicatorSectionViewInitialized() {
			NavigationViewModel navigationViewModel = TestKernel.Instance.Get<NavigationViewModel>();
			object obj = new object();
			navigationViewModel.IndicatorSectionOpenCommand.Execute(obj);
			var indicatorSection = navigationViewModel.SectionView as IIndicatorSection;
			Assert.IsNotNull(indicatorSection);
		}

		[TestMethod]
		public void CloseOpenCommandIsNotNull() {
			NavigationViewModel navigationViewModel = TestKernel.Instance.Get<NavigationViewModel>();
			Assert.IsNotNull(navigationViewModel.CloseCommand);
		}

		//[TestMethod]
		//public void CloseCommandShutdownApplication() {
		//	var app = new App();
		//	app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
		//	NavigationViewModel navigationViewModel = TestKernel.Instance.Get<NavigationViewModel>();
		//	object obj = new object();
		//	Application.Current.Dispatcher.ShutdownStarted += (sender, args) => {
		//		Assert.IsTrue(Application.Current?.Dispatcher?.HasShutdownStarted ?? false);
		//	};
		//	navigationViewModel.CloseCommand.Execute(obj);
		//	Application.Current.Dispatcher.
		//}

		[TestMethod]
		public void SectionViewReturnsSameReference() {
			NavigationViewModel navigationViewModel = TestKernel.Instance.Get<NavigationViewModel>();
			var userControl = new UserControl();
			navigationViewModel.SectionView = userControl;
			Assert.IsTrue(ReferenceEquals(userControl, navigationViewModel.SectionView));
		}
	}
}