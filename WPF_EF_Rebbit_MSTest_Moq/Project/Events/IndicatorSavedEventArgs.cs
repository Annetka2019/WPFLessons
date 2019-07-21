using System;
using WPF_EF_Rebbit_MSTest_Moq.Project.Model;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.Events
{
	public class IndicatorSavedEventArgs: EventArgs
	{
		public Indicator Indicator { get; set; }
	}
}