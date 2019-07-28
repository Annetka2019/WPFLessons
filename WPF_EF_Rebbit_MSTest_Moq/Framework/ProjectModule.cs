using Ninject.Extensions.Factory;
using Ninject.Modules;
using WPF_EF_Rebbit_MSTest_Moq.Project.Core;
using WPF_EF_Rebbit_MSTest_Moq.Project.View;
using WPF_EF_Rebbit_MSTest_Moq.Project.View.Interfaces;
using WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel;
using WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel.Interfaces;

namespace WPF_EF_Rebbit_MSTest_Moq.Framework
{
	public class ProjectModule: NinjectModule
	{
		public override void Load() {
			Bind<INavigationViewModel>().To<NavigationViewModel>();
			Bind<ICardSection>().To<CardSection>();
			Bind<IIndicatorSection>().To<IndicatorSection>();
			Bind<ICardSectionViewModel>().To<CardSectionViewModel>();
			Bind<IIndicatorSectionViewModel>().To<IndicatorSectionViewModel>();
			Bind<ICardPageViewModel>().To<CardPageViewModel>();
			Bind<IIndicatorPageFactory>().ToFactory();
			Bind<IIndicatorPage>().To<IndicatorPage>().NamedLikeFactoryMethod((IIndicatorPageFactory f) => f.GetPage());
			Bind<IIndicatorPageViewModel>().To<IndicatorPageViewModel>();
		}
	}
}