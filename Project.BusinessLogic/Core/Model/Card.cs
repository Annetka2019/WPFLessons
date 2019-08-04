using System;
using System.Collections.Generic;
using Project.BusinessLogic.Contract.Interface.Model;

namespace Project.BusinessLogic.Core.Model
{
    public class Card: ICard
	{
	    public Guid Id { get; set; }

	    public string Number { get; set; }

		public string Name { get; set; }

	    public DateTime? StartDate { get; set; }

	    public DateTime? DueDate { get; set; }

	    public decimal Assessment { get; set; }

	    public virtual ICollection<IIndicatorInCard> IndicatorInCards { get; set; } = new HashSet<IIndicatorInCard>();
    }
}