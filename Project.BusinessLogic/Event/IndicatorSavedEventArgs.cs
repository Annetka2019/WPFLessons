using System;
using Project.BusinessLogic.Contract.Interface.Model;

namespace Project.BusinessLogic.Event
{
	public class IndicatorSavedEventArgs: EventArgs
	{
		public IIndicator Indicator { get; set; }
	}
}