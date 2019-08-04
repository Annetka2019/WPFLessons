using System;
using System.Collections.Generic;

namespace Project.BusinessLogic.Contract.Interface.Model
{
	public interface ICard
	{
		Guid Id { get; set; }

		string Number { get; set; }

		string Name { get; set; }

		DateTime? StartDate { get; set; }

		DateTime? DueDate { get; set; }

		decimal Assessment { get; set; }

		ICollection<IIndicatorInCard> IndicatorInCards { get; set; }
	}
}
