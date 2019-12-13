using System;
using Project.BusinessLogic.Contract.Interface.Event;
using Project.BusinessLogic.Contract.Interface.Model;

namespace Project.BusinessLogic.Event
{
	public class IndicatorSavedEventArgs: EventArgs, IIndicatorSavedEventArgs
	{
		public IIndicator Indicator { get; set; }
	}
}