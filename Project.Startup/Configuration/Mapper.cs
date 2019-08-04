using AutoMapper;
using Project.BusinessLogic.Contract.Interface.Model;
using Project.BusinessLogic.Core.Model;
using Project.Database.Model;

namespace Project.Startup.Configuration
{
	internal sealed class Mapper
	{
		private static IMapper _instance;
		public static IMapper Instance {
			get {
				if (_instance != null) return _instance;
				var config = new MapperConfiguration(cfg => {
					cfg.CreateMap<IndicatorEntity, IIndicator>()
						.ForMember(destinationMember => destinationMember.IndicatorInCards, option => option.Ignore())
						.As<Indicator>();
					cfg.CreateMap<IIndicator, IndicatorEntity>()
						.ForMember(destinationMember => destinationMember.IndicatorInCards, option => option.Ignore());
					cfg.CreateMap<CardEntity, ICard>()
						.ForMember(destinationMember => destinationMember.IndicatorInCards, option => option.Ignore())
						.As<Card>();
					cfg.CreateMap<ICard, CardEntity>()
						.ForMember(destinationMember => destinationMember.IndicatorInCards, option => option.Ignore());
				});
				_instance = config.CreateMapper();
				return _instance;
			}
		}
	}
}
