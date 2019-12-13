using AutoMapper;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Project.BusinessLogic.Contract.Interface.Database;
using Project.BusinessLogic.Contract.Interface.Model;
using Project.BusinessLogic.Contract.Interface.View;
using Project.BusinessLogic.Contract.Interface.ViewModel;
using Project.BusinessLogic.Core.ViewModel;
using Project.Database.Database;
using Project.Presentation.View;

namespace Project.Startup.Configuration
{
	public class DiModule: NinjectModule
	{
		public override void Load() {
			Bind<IMapper>().ToConstant(Mapper.Instance);
			Bind<IRepository<IIndicator>>().To<IndicatorRepository>();
			Bind<IRepository<ICard>>().To<CardRepository>();
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