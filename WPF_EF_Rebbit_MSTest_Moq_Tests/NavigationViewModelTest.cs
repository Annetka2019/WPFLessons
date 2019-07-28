using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel;

namespace WPF_EF_Rebbit_MSTest_Moq_Tests
{
	[TestClass]
	public class NavigationViewModelTest
	{
		[TestMethod]
		public void IsCardSectionOpenCommandHasOpenCardsCallback() {
			var navigationViewModel = TestKernel.Instance.Get<NavigationViewModel>();
		}
	}
}