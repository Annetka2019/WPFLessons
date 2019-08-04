using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Project.BusinessLogic.Contract.Interface.Model
{
	public interface IIndicator: INotifyPropertyChanged
	{
		Guid Id { get; set; }

		string Name { get; set; }

		string Type { get; set; }

		ICollection<IIndicatorInCard> IndicatorInCards { get; set; }
	}
}