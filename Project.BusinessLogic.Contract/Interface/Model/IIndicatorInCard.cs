using System;

namespace Project.BusinessLogic.Contract.Interface.Model
{
	public interface IIndicatorInCard
	{
		Guid Id { get; set; }

		Guid CardId { get; set; }

		Guid IndicatorId { get; set; }

		byte Weight { get; set; }

		string Assessment { get; set; }
	}
}
