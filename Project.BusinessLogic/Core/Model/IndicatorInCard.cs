using System;
using Project.BusinessLogic.Contract.Interface.Model;

namespace Project.BusinessLogic.Core.Model
{
	public class IndicatorInCard: IIndicatorInCard
	{
		public Guid Id { get; set; }

		public Guid CardId { get; set; }

		public Guid IndicatorId { get; set; }

		public byte Weight { get; set; }

		public string Assessment { get; set; }
	}
}