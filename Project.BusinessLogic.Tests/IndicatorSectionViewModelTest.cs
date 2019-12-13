using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project.BusinessLogic.Contract.Interface.Database;
using Project.BusinessLogic.Contract.Interface.Model;
using Project.BusinessLogic.Contract.Interface.View;
using Project.BusinessLogic.Contract.Interface.ViewModel;
using Project.BusinessLogic.Core.Model;
using Project.BusinessLogic.Core.ViewModel;
using Project.Presentation.View;

namespace Project.BusinessLogic.Tests
{
	[TestClass]
	[SuppressMessage("ReSharper", "PossibleUnintendedReferenceComparison")]
	public class IndicatorSectionViewModelTest
	{
		[TestMethod]
		public void IndicatorSectionIndicatorsCollection() {
			Indicator indicator = GetIndicator();
			var repositoryIndicatorMock = new Mock<IRepository<IIndicator>>();
			repositoryIndicatorMock
				.Setup(rim => rim.GetCollection())
				.Returns(new List<IIndicator> { indicator });

			var indicatorSectionViewModel 
				= new IndicatorSectionViewModel(Mock.Of<IIndicatorPageFactory>(), repositoryIndicatorMock.Object);

			Assert.IsTrue(indicatorSectionViewModel.Indicators.Count == 1, "Indicators count");
			Assert.IsTrue(indicatorSectionViewModel.Indicators[0].Id == indicator.Id, "Indicator Id");
			Assert.IsTrue(indicatorSectionViewModel.Indicators[0].Name == indicator.Name, "Indicator Name");
			Assert.IsTrue(indicatorSectionViewModel.Indicators[0].Type == indicator.Type, "Indicator Type");
		}

		[TestMethod]
		public void IndicatorSectionSelectedIndicatorProperty() {
			var indicatorSectionViewModel
				= new IndicatorSectionViewModel(Mock.Of<IIndicatorPageFactory>(), Mock.Of<IRepository<IIndicator>>());
			Indicator indicator = GetIndicator();

			indicatorSectionViewModel.SelectedIndicator = indicator;

			Assert.IsNotNull(indicatorSectionViewModel.SelectedIndicator, "SelectedIndiactor is null");
			Assert.IsTrue(indicatorSectionViewModel.SelectedIndicator.Id == indicator.Id, "SelectedIndiactor Id");
			Assert.IsTrue(indicatorSectionViewModel.SelectedIndicator.Name == indicator.Name, "SelectedIndiactor Name");
			Assert.IsTrue(indicatorSectionViewModel.SelectedIndicator.Type == indicator.Type, "SelectedIndiactor Type");
		}

		[TestMethod]
		public void IndicatorSectionAddCommand() {
			var indicatorPageViewModel = Mock.Of<IIndicatorPageViewModel>();
			var indicatorPage = new IndicatorPage(indicatorPageViewModel) { Visibility = Visibility.Hidden };
			var indicatorPageFactoryMock = new Mock<IIndicatorPageFactory>();
			indicatorPageFactoryMock.Setup(ipf => ipf.GetPage()).Returns(indicatorPage);
			var indicatorSectionViewModel
				= new IndicatorSectionViewModel(indicatorPageFactoryMock.Object, Mock.Of<IRepository<IIndicator>>());

			indicatorSectionViewModel.AddCommand.Execute(new object());
			
			Assert.IsFalse(indicatorPage.ShowInTaskbar, "IndicatorPage ShowInTaskbar is true");
			Assert.IsTrue(indicatorPage.IsLoaded, "IndicatorPage is not loaded");
		}

		[TestMethod]
		public void IndicatorSectionEditCommand() {
			var indicatorPageViewModel = Mock.Of<IIndicatorPageViewModel>();
			var indicatorPage = new IndicatorPage(indicatorPageViewModel) { Visibility = Visibility.Hidden };
			var indicatorPageFactoryMock = new Mock<IIndicatorPageFactory>();
			indicatorPageFactoryMock.Setup(ipf => ipf.GetPage()).Returns(indicatorPage);
			Indicator indicator = GetIndicator();
			var indicatorSectionViewModel
				= new IndicatorSectionViewModel(indicatorPageFactoryMock.Object, Mock.Of<IRepository<IIndicator>>()) {
					SelectedIndicator = indicator
				};

			indicatorSectionViewModel.EditCommand.Execute(new object());

			Assert.IsTrue(indicatorSectionViewModel.EditCommand.CanExecute(new object()), "Can not execute Edit command");
			Assert.IsFalse(indicatorPage.ShowInTaskbar, "IndicatorPage ShowInTaskbar is true");
			Assert.IsTrue(indicatorPage.IsLoaded, "IndicatorPage is not loaded");
			Assert.IsTrue(
				indicatorPageViewModel.Indicator == indicator,
				"IndicatorPageViewModel.Indicator is not SelectedIndicator");
		}

		[TestMethod]
		public void IndicatorSectionRemoveCommand() {
			var repositoryIndicatorMock = new Mock<IRepository<IIndicator>>();
			Indicator indicator = GetIndicator();
			var indicatorSectionViewModel
				= new IndicatorSectionViewModel(Mock.Of<IIndicatorPageFactory>(), repositoryIndicatorMock.Object) {
					SelectedIndicator = indicator
				};
			indicatorSectionViewModel.Indicators.Add(indicator);
			indicatorSectionViewModel.SelectedIndicator = indicator;

			indicatorSectionViewModel.RemoveCommand.Execute(new object());

			Assert.IsTrue(indicatorSectionViewModel.RemoveCommand.CanExecute(new object()), "Can not execute Remove command");
			Assert.IsFalse(indicatorSectionViewModel.Indicators.Contains(indicator), "Indicators contain indicator to delete");
			Assert.IsNull(indicatorSectionViewModel.SelectedIndicator, "SelectedIndicator is not null");
			repositoryIndicatorMock.Verify(ri => ri.Remove(indicator), Times.Once);
		}

		private static Indicator GetIndicator() {
			return new Indicator {
				Id = Guid.NewGuid(),
				Name = "TestIndicator",
				Type = "MyType"
			};
		}
	}
}